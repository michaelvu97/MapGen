using MapGen.Hammer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Math
{
	public struct Matrix4f
	{
		public Vector3f RowX { get; set; }
		public float XOffset { get; set; }

		public Vector3f RowY { get; set; }
		public float YOffset { get; set; }

		public Vector3f RowZ { get; set; }
		public float ZOffset { get; set; }

		public Vector3f RowW { get; set; }
		public float WOffset { get; set; }

		public Vector3f VecMul(Vector3f input)
		{
			var x = input.Dot(RowX) + XOffset;
			var y = input.Dot(RowY) + YOffset;
			var z = input.Dot(RowZ) + ZOffset;
			var w = input.Dot(RowW) + WOffset;

			return new Vector3f(x / w, y / w, z / w);
		}
	}
}
