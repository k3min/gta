using System.Collections;
using System.Collections.Generic;
using RenderWare.SCM.Structures;
using RenderWare.SCM.Types;

namespace RenderWare.SCM
{
	public class OpCodes : IEnumerable<TCommand>
	{
		public const int MaxCommands = 1154;
		
		private readonly TCommand[] commands = new TCommand[OpCodes.MaxCommands];
		
		public void Add(TCommand command)
		{
			
		}

		public void Add(bool isHandled, string name)
		{
			
		}
		
		public void Add(bool isHandled, string name,  Arg[] args)
		{
			
		}

		private OpCodes.Enumerator GetEnumerator()
		{
			return new OpCodes.Enumerator(this);
		}
		
		IEnumerator<TCommand> IEnumerable<TCommand>.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public struct Enumerator : IEnumerator<TCommand>
		{
			private int position;
			private readonly OpCodes parent;

			public Enumerator(OpCodes parent)
			{
				this.position = -1;
				this.parent = parent;
			}

			public bool MoveNext()
			{
				return (++this.position < OpCodes.MaxCommands);
			}

			public void Reset()
			{
				this.position = -1;
			}

			private TCommand Current => this.parent.commands[this.position];

			object IEnumerator.Current => this.Current;
			
			TCommand IEnumerator<TCommand>.Current => this.Current;
			
			public void Dispose()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}