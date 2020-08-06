using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapGen.Hammer
{
	public abstract class VmfObject : IVmfObject
	{
		public abstract string Name { get; }

		public abstract IDictionary<string, string> Fields { get; }

		public abstract IEnumerable<IVmfObject> Children { get; }

		public string Serialize(int tabLevel)
		{
			var baseTab = "";
			for (int i = 0; i < tabLevel; i++) baseTab += "\t";

			var result = new StringBuilder();
			result
				.AppendLine(baseTab + Name)
				.AppendLine(baseTab + "{");
			if (Fields.Any())
			{
				result
					.Append(
						string.Join(
							"\n",
							Fields.Select(x => $"{baseTab}\t\"{x.Key}\" \"{x.Value}\"")
						))
					.Append("\n");
			}

			if (Children.Any())
			{
				result
					.Append(
						string.Join(
							"\n",
							Children.Select(x => x.Serialize(tabLevel + 1))
						)
					)
					.Append("\n");
			}

			result.Append($"{baseTab}}}");

			return result.ToString();
		}
	}
}
