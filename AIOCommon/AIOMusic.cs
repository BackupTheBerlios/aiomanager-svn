using System;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOMusic.
	/// </summary>
	public class AIOMusic : AIOCommonInfo
	{
		public string fileName;
		public string fileType;
		public string name;
		public float size;
		public int length;
		public int bitrate;
		public string artist;
		public string album;
		public AIOMusic( AIOCommonInfo info )
		{
			//
			// TODO: Add constructor logic here
			//
			SetCommonInfo( info );
		}

		public void setMusicInfo( string name, string artist, string album )
		{
			this.name = name;
			this.album = album;
			this.artist = artist;
		}
	}
}
