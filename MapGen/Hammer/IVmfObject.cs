using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Hammer
{
	public interface IVmfObject
	{
		public string Name { get; }
		public IDictionary<string, string> Fields { get; } 
		public IEnumerable<IVmfObject> Children { get; }

		public string Serialize(int tabLevel);
	}
}
