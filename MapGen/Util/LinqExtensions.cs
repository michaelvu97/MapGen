using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Util
{
	public static class LinqExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (func == null)
				throw new ArgumentNullException(nameof(func));

			foreach (var item in source)
				func(item);
		}
	}
}
