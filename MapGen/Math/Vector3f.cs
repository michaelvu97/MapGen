using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MapGen.Math
{
	public struct Vector3f
	{
		public Vector3f(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }

		public Vector3f Clone()
		{
			return new Vector3f(X, Y, Z);
		}

		public Vector3f Add(Vector3f other)
		{
			return new Vector3f(X + other.X, Y + other.Y, Z + other.Z);
		}

		public static Vector3f operator+(Vector3f lhs, Vector3f rhs)
		{
			return lhs.Add(rhs);
		}

		public Vector3f Subtract(Vector3f rhs)
		{
			return Add(rhs.Scale(-1));
		}

		public static Vector3f operator-(Vector3f lhs, Vector3f rhs)
		{
			return lhs.Subtract(rhs);
		}

		public Vector3f Scale(float scale)
		{
			return new Vector3f(X * scale, Y * scale, Z * scale);
		}

		public static Vector3f operator*(Vector3f vec, float scale)
		{
			return vec.Scale(scale);
		}

		public static Vector3f operator*(float scale, Vector3f vec)
		{
			return vec.Scale(scale);
		}

		public float Dot(Vector3f other)
		{
			return X * other.X +  Y * other.Y + Z * other.Z;
		}

		public static float operator*(Vector3f a, Vector3f b)
		{
			return a.Dot(b);
		}

		public Vector3f Normal()
		{
			return this * (float) ( 1.0f / System.Math.Sqrt(this * this));
		}
		
		public override string ToString()
		{
			return $"{X} {Y} {Z}";
		}
	}
}
