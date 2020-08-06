using System;
using System.Numerics;
using System.Text;

namespace MapGen.Math
{
	public struct Plane
	{
		public Vector3f BottomLeft { get; set; }
		public Vector3f TopLeft { get; set; }
		public Vector3f TopRight { get; set; }

		public string ToHammerString()
		{
			return $"({BottomLeft.X} {BottomLeft.Y} {BottomLeft.Z}) " +
				$"({TopLeft.X} {TopLeft.Y} {TopLeft.Z}) " + 
				$"({TopRight.X} {TopRight.Y} {TopRight.Z})";
		}

		public static Plane YZPlane(float x, float yLeft, float yRight, float zBottom, float zTop)
		{ 
			return new Plane
			{
				BottomLeft = new Vector3f(x, yLeft, zBottom),
				TopLeft = new Vector3f(x, yLeft, zTop),
				TopRight = new Vector3f(x, yRight, zTop)
			};
		}

		public static Plane XZPlane(float y, float xLeft, float xRight, float zBottom, float zTop)
		{
			return new Plane
			{
				BottomLeft = new Vector3f(xLeft, y, zBottom),
				TopLeft = new Vector3f(xLeft, y, zTop),
				TopRight = new Vector3f(xRight, y, zTop)
			};
		}

		public static Plane XYPlane(float z, float xLeft, float xRight, float yBottom, float yTop)
		{
			return new Plane
			{
				BottomLeft = new Vector3f(xLeft, yBottom, z),
				TopLeft = new Vector3f(xLeft, yTop, z),
				TopRight = new Vector3f(xRight, yTop, z)
			};
		}

		public Vector3f UAxis => TopLeft - BottomLeft;
		public Vector3f VAxis => TopRight - TopLeft;

	}
}
