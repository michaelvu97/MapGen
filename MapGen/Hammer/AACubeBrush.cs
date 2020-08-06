using MapGen.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapGen.Hammer
{
	public class AACubeBrush : Brush
	{
		public override IList<Side> Sides { get; }

		public AACubeBrush(IEnumerable<Side> sides)
		{
			if (sides == null)
				throw new ArgumentNullException(nameof(sides));
			if (sides.Count() != 6)
				throw new ArgumentOutOfRangeException(nameof(sides) + " invalid number of sides");

			Sides = sides.ToArray();
		}

		public override Brush Clone()
		{
			return new AACubeBrush(Sides.Select(x => x.Clone()));
		}

		public static AACubeBrush AABBFromCOM(Vector3f centre, float widthX, float widthY, float widthZ)
		{
			var halfX = widthX / 2;
			var halfY = widthY / 2;
			var halfZ = widthZ / 2;

			return FromExtents(
				centre.X - halfX, centre.X + halfX,
				centre.Y - halfY, centre.Y + halfY,
				centre.Z - halfZ, centre.Z + halfZ
			);
		}

		public static AACubeBrush FromExtents(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
		{
			var sides = new Side[]
			{
				// Left
				new Side(Plane.XZPlane(minY, minX, maxX, minZ, maxZ)),

				// Right
				new Side(Plane.XZPlane(maxY, maxX, minX, minZ, maxZ)),

				// Front
				new Side(Plane.YZPlane(maxX, minY, maxY, minZ, maxZ)),

				// Back
				new Side(Plane.YZPlane(minX, maxY, minY, minZ, maxZ)),

				// Top
				new Side(Plane.XYPlane(maxZ, minX, maxX, minY, maxY)),

				// Bottom
				new Side(Plane.XYPlane(minZ, maxX, minX, minY, maxY))
			};

			return new AACubeBrush(sides);
		}
	}
}
