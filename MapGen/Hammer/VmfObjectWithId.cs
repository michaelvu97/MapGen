using System;
using System.Collections.Generic;
using System.Text;

namespace MapGen.Hammer
{
	public abstract class VmfObjectWithId : VmfObject
	{
		public int Id { get; set; }
	}
}
