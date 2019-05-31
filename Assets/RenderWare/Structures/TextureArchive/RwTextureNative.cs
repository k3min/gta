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

		[System.NonSerialized] public UnityEngine.Texture2D Texture2D;

		public static RwTextureNative Read(RwBinaryReader reader)
		{
			var texture = new RwTextureNative
			{
				Texture = RwTextureNative.TextureFormat.Read(reader),
			};

			reader.Read(RwTextureNative.RasterFormat.SizeOf, ref texture.Raster);

			var pal8 = ((texture.Raster.Flags & Types.RasterFormat.Pal8) == Types.RasterFormat.Pal8);

			if (pal8)
			{
				texture.Palette = new UnityEngine.Color32[256];
				reader.Read(256, 4, ref texture.Palette);

				var size = reader.ReadInt();
				texture.Pixels = new UnityEngine.Color32[size];
				for (var i = 0; i < size; i++)
				{
					texture.Pixels[i] = texture.Palette[reader.ReadByte()];
				}
			}
			else
			{
				var offset = 0;
				var size = reader.ReadInt();

				texture.Data = new byte[size + (size / 3)];

				reader.Read(size, 1, ref texture.Data, offset);

				for (var i = 1; i < texture.Raster.MipMapCount; i++)
				{
					size = reader.ReadInt();

					if (size == 0)
					{
						continue;
					}

					reader.Read(size, 1, ref texture.Data, offset);

					offset += size;
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

			this.Texture2D = new UnityEngine.Texture2D(this.Raster.Width, this.Raster.Height, textureFormat,
				(this.Raster.Flags & Types.RasterFormat.Mipmaps) == Types.RasterFormat.Mipmaps)
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

			this.Texture2D.Apply((this.Raster.Flags & Types.RasterFormat.AutoMipmaps) == Types.RasterFormat.AutoMipmaps,
				true);
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
			public const int NameLength = 32;
			public const int SizeOf = 4 + 1 + 1 + 2 + TextureFormat.NameLength + TextureFormat.NameLength;

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
			public const int SizeOf = 4 + 4 + 2 + 2 + 1 + 1 + 1 + 1;

			public Types.RasterFormat Flags;
			[MarshalAs(UnmanagedType.Bool)] public bool HasAlpha;
			public short Width;
			public short Height;
			public byte BitsPerPixel;
			public byte MipMapCount;
			public byte RasterType;
			public byte Compression;
		}
	}
}