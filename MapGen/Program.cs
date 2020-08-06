using MapGen.BasicGen;
using MapGen.Hammer;
using System;
using System.IO;

namespace MapGen
{
	class Program
	{
		static void Main(string[] args)
		{
			var outputFile = "./output.vmf";

			var world = new BasicMapGenerator().Generate();
			world.FixIds();

			var file = new VmfFile(world);

			System.IO.File.WriteAllText(outputFile, file.Serialize());
		}
	}
}
