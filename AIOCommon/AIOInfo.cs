using System;
using System.IO;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOInfo.
	/// </summary>
	public class AIOInfo
	{
		public bool isFile; //Is file or category

		//Basic Node Info here
		public string ID;
		public string Name;
        
		public AIOInfo(string ID, string Name, bool isFile)
		{
			this.ID = ID;
			this.Name = Name;
			this.isFile = isFile;
		}

		public AIOInfo(string ID, bool isFile) : this(ID, "", isFile)
		{
		}
	}
}
