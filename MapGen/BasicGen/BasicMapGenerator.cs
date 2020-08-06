using MapGen.Hammer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.BasicGen
{
	class BasicMapGenerator
	{
		public Hammer.World Generate()
		{
			var world = new World();
			
			// Create world boundary
			var worldSize = 512f;
			var worldPadding = 16f;

			world.Brushes.Add(AACubeBrush.FromExtents(-worldPadding, 0, 0, worldSize, 0, worldSize));
			world.Brushes.Add(AACubeBrush.FromExtents(worldSize, worldSize + worldPadding, 0, worldSize, 0, worldSize));

			world.Brushes.Add(AACubeBrush.FromExtents(0, worldSize, 0, worldSize, -worldPadding, 0));
			world.Brushes.Add(AACubeBrush.FromExtents(0, worldSize, 0, worldSize, worldSize, worldSize + worldPadding));

			world.Brushes.Add(AACubeBrush.FromExtents(0, worldSize, -worldPadding, 0, 0, worldSize));
			world.Brushes.Add(AACubeBrush.FromExtents(0, worldSize, worldSize, worldSize + worldPadding, 0, worldSize));

			return world;
		}
	}
} 
