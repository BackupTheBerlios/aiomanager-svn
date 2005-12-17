using System;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOEvent.
	/// </summary>
	public class AIOEvent
	{
		//SynchronizeEvent
		public delegate void SynchronizeDele(string path, string pattern, bool bRecursive);
		public static event SynchronizeDele SynchronizeEvent;

		public AIOEvent()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
