using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwTextureNative : IRwBinaryStream, System.IDisposable
	{
		public RwTextureNative.TextureFormat Texture;
		public RwTextureNative.RasterFormat Raster;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public UnityEngine.Color32[] Palette;

		public UnityEngine.Color32[] Pixels;
		public byte[] Data;

		[System.NonSerialized]
		public UnityEngine.Texture2D Texture2D;

		public static RwTextureNative Read(RwBinaryReader reader)
		{
			var texture = new RwTextureNative
			{
				Texture = RwTextureNative.TextureFormat.Read(reader),
				Raster = RwTextureNative.RasterFormat.Read(reader)
			};

			var pal8 = ((texture.Raster.Flags & Types.RasterFormat.Pal8) == Types.RasterFormat.Pal8);

			if (pal8)
			{
				texture.Palette = reader.ReadColor(256);

				var size = reader.ReadInt();

				texture.Pixels = RwBinaryReader.Read(() => texture.Palette[reader.ReadByte()], size);
			}
			else
			{
					var size = reader.ReadInt();

					texture.Data = new byte[size];

					reader.BlockCopy(texture.Data, 0, size);

					for (var i = 1; i < texture.Raster.MipMapCount; i++)
					{
						size = reader.ReadInt();

						if (size == 0)
						{
							continue;
						}

						System.Array.Resize(ref texture.Data, texture.Data.Length + size);

						reader.BlockCopy(texture.Data, texture.Data.Length - size, size);
					}
			}

			try
			{
				texture.CreateTexture2D();
			}
			catch (System.Exception e)
			{
				UnityEngine.Debug.LogWarning(e.Message);
			}

			return texture;
		}

		private void CreateTexture2D()
		{
			UnityEngine.TextureFormat textureFormat;
			UnityEngine.FilterMode filterMode;

			switch (this.Raster.Flags)
			{
				case Types.RasterFormat.RGB24 | Types.RasterFormat.Pal8:
					textureFormat = UnityEngine.TextureFormat.RGB24;
					break;

				case Types.RasterFormat.RGBA32 | Types.RasterFormat.Pal8:
					textureFormat = UnityEngine.TextureFormat.RGBA32;
					break;

				case Types.RasterFormat.RGB24:
				case Types.RasterFormat.RGBA32:
					textureFormat = UnityEngine.TextureFormat.BGRA32;
					break;

				default:
					throw new InvalidDataException($"{this.Texture.Name}: Unsupported format '{this.Raster.Flags}'!");
			}

			switch (this.Texture.FilterMode)
			{
				case FilterMode.Nearest:
					filterMode = UnityEngine.FilterMode.Point;
					break;

				case FilterMode.Linear:
					filterMode = UnityEngine.FilterMode.Bilinear;
					break;

				case FilterMode.LinearMipLinear:
					filterMode = UnityEngine.FilterMode.Trilinear;
					break;

				default:
					throw new InvalidDataException(
						$"{this.Texture.Name}: Unsupported filtering '{this.Texture.FilterMode}'!");
			}

			this.Texture2D = new UnityEngine.Texture2D(this.Raster.Width, this.Raster.Height, textureFormat, (this.Raster.Flags & Types.RasterFormat.Mipmaps) == Types.RasterFormat.Mipmaps)
			{
				name = this.Texture.Name,
				filterMode = filterMode,
				hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild
			};

			if ((this.Raster.Flags & Types.RasterFormat.Pal8) == Types.RasterFormat.Pal8)
			{
				var colors = new UnityEngine.Color[this.Pixels.Length];

				for (var i = 0; i < this.Pixels.Length; i++)
				{
					colors[i] = this.Pixels[i];
				}
				
				this.Texture2D.SetPixels(colors);
			}
			else
			{
				this.Texture2D.LoadRawTextureData(this.Data);
			}

			this.Texture2D.Apply((this.Raster.Flags & Types.RasterFormat.AutoMipmaps) == Types.RasterFormat.AutoMipmaps, true);
		}

		public void Dispose()
		{
			if (this.Texture2D != null)
			{
				UnityEngine.Object.DestroyImmediate(this.Texture2D);
				this.Texture2D = null;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct TextureFormat
		{
			public PlatformId PlatformId;
			public FilterMode FilterMode;
			public AddressingMode Wrap;
			public short Padding;

			[MarshalAs(UnmanagedType.LPStr, SizeConst = 32)]
			public string Name;

			[MarshalAs(UnmanagedType.LPStr, SizeConst = 32)]
			public string AlphaName;

			public static TextureFormat Read(RwBinaryReader reader)
			{
				return new TextureFormat
				{
					PlatformId = (PlatformId)reader.ReadInt(),
					FilterMode = (FilterMode)reader.ReadByte(),
					Wrap = (AddressingMode)reader.ReadByte(),
					Padding = reader.ReadShort(),
					Name = reader.ReadString(32),
					AlphaName = reader.ReadString(32)
				};
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RasterFormat
		{
			public Types.RasterFormat Flags;

			[MarshalAs(UnmanagedType.Bool)] public bool HasAlpha;
			public short Width;
			public short Height;
			public byte BitsPerPixel;
			public byte MipMapCount;
			public byte RasterType;
			public byte Compression;

			public static RasterFormat Read(RwBinaryReader reader)
			{
				return new RasterFormat
				{
					Flags = (Types.RasterFormat)reader.ReadInt(),
					HasAlpha = reader.ReadBoolean(),
					Width = reader.ReadShort(),
					Height = reader.ReadShort(),
					BitsPerPixel = reader.ReadByte(),
					MipMapCount = reader.ReadByte(),
					RasterType = reader.ReadByte(),
					Compression = reader.ReadByte()
				};
			}
		}
	}
}