using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Hammer
{
	public class VmfFile
	{
		public World World { get; }

		public VmfFile(World world)
		{
			World = world ?? throw new ArgumentNullException(nameof(world));
		}

		public string Serialize()
		{
			// TODO other things
			return World.Serialize(0);
		}
	}
}
