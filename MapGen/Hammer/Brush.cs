using MapGen.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Hammer
{
	public abstract class Brush : VmfObjectWithId
	{
		public override string Name => "solid";

		public abstract IList<Side> Sides { get; }

		public override IDictionary<string, string> Fields => new Dictionary<string, string>
		{
			{ "id", Id.ToString() }
		};

		public override IEnumerable<IVmfObject> Children => Sides;

		public abstract Brush Clone();
	}
}
