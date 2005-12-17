using System;
using System.Data;
using System.Data.OleDb;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOCommonController.
	/// </summary>
	public class AIOCommonController
	{
		protected AIODatabase aioDb;

		public AIOCommonController(AIODatabase aioDb)
		{
			this.aioDb = aioDb;
		}

		//Insert Info into Database
		public virtual void InsertQueue(string ID, string path)
		{
			string createdDate = DateTime.Now.ToShortDateString();
			//string sql = "INSERT INTO Common VALUES('" + ID + "', 0, '' ,0, '" + path + "', '" + createdDate + "')";
			string sqlbase = "INSERT INTO Common VALUES(?, ?, ?, ?, ?, ?)";
			OleDbCommand sqlCmd = aioDb.CreateSqlWithParam(sqlbase, new object[] {ID, 0, "", 0, path, createdDate});
			//QueueIt
			aioDb.QueueCommand(sqlCmd);
		}

		public virtual void UpdateInfo(AIOCommonInfo info)
		{
			string sql = "UPDATE Common SET ratings = ?, comment = ?, icon = ?, path = ? WHERE ID = ?";
			OleDbCommand cmd = aioDb.CreateSqlWithParam(sql, new object[] {info.ratings, info.comment, info.icon, info.path, info.ID});
			//ExecuteIt
			aioDb.ExecuteCommand(cmd);
		}

		public virtual void DeleteQueue(string ID) 
		{
			string sql = "DELETE FROM Common WHERE ID = '" + ID + "'";
			OleDbCommand sqlCmd = new OleDbCommand(sql);
			//QueueIt
			aioDb.QueueCommand(sqlCmd);
		}

		public virtual void CopyQueue(string srcID, string destID) 
		{
			string createdDate = DateTime.Now.ToShortDateString();			

			string sql = "SELECT * FROM Common WHERE ID = '" + srcID + "'";
			DataTable table = aioDb.ExecuteSelect(sql);
			object [] obj = table.Rows[0].ItemArray;
			//Change the ID
			obj[0] = destID;
			//Change the date
			obj[5] = createdDate;
						
			string sqlbase = "INSERT INTO Common VALUES(?, ?, ?, ?, ?, ?)";
			OleDbCommand sqlCmd = aioDb.CreateSqlWithParam(sqlbase, obj);
			//QueueIt
			aioDb.QueueCommand(sqlCmd);
		}

		public virtual AIOCommonInfo Select(string ID) 
		{
			string sql = "SELECT * FROM Common WHERE ID = '" + ID + "'";
			DataTable table = aioDb.ExecuteSelect(sql);
			object [] obj = table.Rows[0].ItemArray;
			//ID - ratings - comment - icon - path - createdDate
			//0 - 1 - 2 - 3 - 4 - 5
			AIOCommonInfo info = new AIOCommonInfo();

			info.ID = ID;
			info.ratings = Convert.ToInt32(obj[1]);
			info.comment = obj[2].ToString();
			info.icon = Convert.ToInt32(obj[3]);
			info.path = obj[4].ToString();
			info.createdDate = obj[5].ToString();
			
			return info;
		}
	}
}
