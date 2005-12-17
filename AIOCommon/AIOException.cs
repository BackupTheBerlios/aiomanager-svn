using System;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOException.
	/// </summary>
	public enum AIOExceptionType {CANNOT_DELETE_ROOT};
	public class AIOException : Exception
	{		
		public static string [] exception = {"Can't delete root!"};
		public AIOException(AIOExceptionType type)
		{
			throw new Exception(exception[(int)type]);
		}
	}
}
