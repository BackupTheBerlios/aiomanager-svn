using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOUtil.
	/// </summary>
	public class AIOUtil
	{
		public AIOUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public static long ByteToKB(long bytes) 
		{
			long kb = (long)(Math.Ceiling(bytes / 1024));
			return kb;
		}

		public static string ByteToKB_String(long bytes) 
		{
			return ToNumberFormat(ByteToKB(bytes));
		}
	

		public static string ToNumberFormat(long num) 
		{
			return num.ToString("N0");
		}

		public static string GetNameFromPath(string path) 
		{
			int pos = path.LastIndexOf('\\');
			if (pos != -1)
				return path.Substring(pos+1);
			pos = path.LastIndexOf('/');
			if (pos != -1)
				return path.Substring(pos+1);

			return path;
		}
	}
}
