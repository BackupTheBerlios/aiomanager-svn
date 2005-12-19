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
			OleDbCommand cmd = aioDb.CreateSqlWithParam( sql, new object[] { ID, "noname", "noname", "noname" } );
			aioDb.QueueCommand( cmd );
		}

		public override void UpdateInfo(AIOCommonInfo info)
		{
			base.UpdateInfo (info);
			AIOMusic music = (AIOMusic)info;
			string sql = "update Music set Name = ?, ArtistID = ?, AlbumID = ? where ID =?";

		}

	}
}
