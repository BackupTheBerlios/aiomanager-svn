using System;
using System.Data;
using System.Data.OleDb;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOMusicController.
	/// </summary>
	public class AIOMusicController : AIOCommonController
	{
		public AIOMusicController( AIODatabase aiodb ) : base( aiodb )
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override void InsertQueue(string ID, string path)
		{
			base.InsertQueue (ID, path);
			string sql = "insert into Music values( ?, ?, ?, ? )";
			OleDbCommand cmd = aioDb.CreateSqlWithParam( sql, new object[] { ID, "noname", "000001", "000001" } );
			aioDb.QueueCommand( cmd );
		}

		public override void UpdateInfo(AIOCommonInfo info)
		{
			base.UpdateInfo (info);
			AIOMusic music = (AIOMusic)info;
			string sql = "update Music set Name = ?, ArtistID = ?, AlbumID = ? where ID =?";
			OleDbCommand cmd = aioDb.CreateSqlWithParam( sql, new object[] {music.name, music.artist, music.album, music.ID} );
			aioDb.ExecuteCommand( cmd );
		}

		public override AIOCommonInfo Select(string ID)
		{
			AIOMusic music = new AIOMusic( base.Select( ID ) );
			string sql = "SELECT * FROM Music WHERE ID='" + ID + "'";
			DataTable DTMusic = aioDb.ExecuteSelect( sql );
			object[] obj = DTMusic.Rows[0].ItemArray;
			music.name = obj[1].ToString();
			music.album = obj[2].ToString();
			music.artist = obj[3].ToString();
			return music;
		}


	}
}
