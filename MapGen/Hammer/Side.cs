using MapGen.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Hammer
{
	public class Side : VmfObjectWithId
	{
		public Plane Plane { get; set; }
		public string Material { get; set; } = "DEV/DEV_MEASURECRATE01";

		public float Rotation { get; set; } = 0;
		public int LightMapScale { get; set; } = 16;
		public int SmoothingGroups { get; set; } = 0;

		public override string Name => "side";

		public override IDictionary<string, string> Fields => new Dictionary<string, string>
		{
			{ "id", Id.ToString() },
			{ "plane", Plane.ToHammerString() },
			{ "material", Material },
			{ "rotation", Rotation.ToString() },
			{ "lightmapscale", LightMapScale.ToString() },
			{ "smoothing_groups", SmoothingGroups.ToString() },
			{ "uaxis", $"[{Plane.UAxis.Normal()} 0] 0.25" },
			{ "vaxis", $"[{Plane.VAxis.Normal()} 0] 0.25" },
		};

		public override IEnumerable<IVmfObject> Children => new IVmfObject[0];

		public Side(Plane plane)
		{
			Plane = plane;
		}

		public Side Clone()
		{
			return new Side(Plane)
			{
				Material = (string) Material.Clone(),
				Rotation = Rotation,
				LightMapScale = LightMapScale,
				SmoothingGroups = SmoothingGroups,
			};
		}
	}
}
