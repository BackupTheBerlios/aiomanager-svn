/*
 * Author: Son Hua
 * songuke@yahoo.com
 * 
 * This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version.
 */
using System;
using System.Data;
using System.Data.OleDb;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIODatabase.
	/// </summary>
	public enum DatabaseType {Access, SQL};
	public class AIODatabase
	{		
		private OleDbConnection cn;
		private OleDbCommand cmd;
		private OleDbDataAdapter adapter;
		private OleDbDataReader reader;
		
		public AIODatabase()
		{
			cn = new OleDbConnection();			
		}

		//In case Access, dbName = dbPath
		public bool ConnectToDB(DatabaseType type, string dbName) 
		{
			string cnString = "";
			switch (type) 
			{
				case DatabaseType.Access:
					cnString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+dbName;

					break;
				case DatabaseType.SQL:
					cnString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog="+dbName+";Integrated Security=SSPI;";					
					break;
			}
			cn.ConnectionString = cnString;
			cmd = cn.CreateCommand();
			cn.Open();
			if (cn.State.Equals(ConnectionState.Closed)) 
				return false;
			else 
				return true;
		}

		public DataTable ExecuteSelect(string selectCmd) 
		{
			DataTable dtTable = new DataTable();
			cmd.CommandText = selectCmd;
			adapter = new OleDbDataAdapter( selectCmd, cn );
			adapter.Fill( dtTable);
			return dtTable;
		}

		public int ExecuteInsert(string insertCmd) 
		{
			int effects;
			cmd.CommandText = insertCmd;
			effects = cmd.ExecuteNonQuery();
			return effects;
		}

		public int ExecuteUpdate(string updateCmd) 
		{
			int effects;
			cmd.CommandText = updateCmd;
			effects = cmd.ExecuteNonQuery();
			return effects;
		}

		public int ExecuteDelete(string deleteCmd) 
		{
			int effects;
			cmd.CommandText = deleteCmd;
			effects = cmd.ExecuteNonQuery();
			return effects;
		}

		public void DisconnectDB() 
		{
			if (cn != null) 
			{
				if ( ! cn.State.Equals(ConnectionState.Closed) )
				{					
					cn.Close();
				}
			}
		}
	}
}
