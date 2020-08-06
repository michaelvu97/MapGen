using MapGen.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapGen.Hammer
{
	public class World : VmfObjectWithId
	{
		public override string Name => "world";

		public string ClassName { get; set; } = "worldspawn";

		public override IDictionary<string, string> Fields => new Dictionary<string, string>
		{
			{ "id", Id.ToString() },
			{ "classname", ClassName },
			{ "mapversion", "1" }
		};

		public override IEnumerable<IVmfObject> Children => Brushes;

		public IList<Brush> Brushes { get; set; } = new List<Brush>();

		public void FixIds()
		{
			int id = 1;
			Id = id++;
			Brushes.ForEach(x =>
			{
				x.Id = id++;
				x.Sides.ForEach(y => y.Id = id++);
				return;
			});
		}
	}
}
