using System.Runtime.InteropServices;
using RenderWare.SCM.Types;

namespace RenderWare.SCM.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TCommand
	{
		public const int MaxArgs = 18;

		[MarshalAs(UnmanagedType.I1)] public bool IsHandled;

		[MarshalAs(UnmanagedType.LPStr, SizeConst = 48)]
		public string Name;

		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = TCommand.MaxArgs)]
		public Arg[] Args;
		
		public TCommand(bool isHandled, string name, params Arg[] args)
		{
			this.IsHandled = isHandled;
			this.Name = name;
			
			this.Args = new Arg[TCommand.MaxArgs];

			for (var i = 0; i < args.Length; i++)
			{
				this.Args[i] = args[i];
			}
		}
	}
}