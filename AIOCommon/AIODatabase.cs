/*
 * Author: Son Hua
 * songuke@yahoo.com
 * 
 * This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version.
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

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
		

		private Queue queueCommand = new Queue();

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

		public void ExecuteCommand(OleDbCommand cmd) 
		{
			if (cmd.Connection == null) 
				cmd.Connection = cn;

			cmd.ExecuteNonQuery();			
		}

		//Fill the sql string with sql parameters
		public OleDbCommand CreateSqlWithParam(string sql, object [] param)
		{			
			OleDbCommand cmd = new OleDbCommand(sql);						
			for (int i = 0;i<param.Length;i++) 
			{
				cmd.Parameters.Add(""+i, param[i]);				
			}
            return cmd;
		}

		//Empty Module
		public void ClearAll(AIOModule moduleType) 
		{
			string sql = "DELETE * FROM Common WHERE ID LIKE '"+AIOConstant.modulePrefix[(int)moduleType]+"%'";
			ExecuteDelete(sql);
		}

		//Get each item's common information
		public object[] GetCommonInfo(string ID) 
		{
			string sql = "SELECT Ratings, Comment, Path FROM Common WHERE ID = '" + ID + "'";
			DataTable table = ExecuteSelect(sql);
			if (table != null)
				return table.Rows[0].ItemArray;

			return null;
		}

		//SubInfo------------------------------------------------------
		public bool IsDuplicateName(string name, AIOSubInfoType subInfoType) 
		{
			string table = AIOConstant.GetTableName(subInfoType);
			string column = AIOConstant.GetColumnName(subInfoType);

			string sql = "SELECT COUNT(*) FROM " + table + " WHERE " + column + " = ?";

			OleDbCommand cmd = CreateSqlWithParam(sql, new string[] {name});
			cmd.Connection = cn;

			int num = (int)cmd.ExecuteScalar();
			if (num > 0) return true;
			else return false;
		}

		public string GenerateSubInfoID(AIOSubInfoType subInfoType) 
		{
			string table = AIOConstant.GetTableName(subInfoType);

			string sql = "SELECT MAX(ID) FROM " + table;
			OleDbCommand cmd = new OleDbCommand(sql, cn);
			object res = cmd.ExecuteScalar();
			int id;
			if (Convert.IsDBNull(res) == false)
				id = Convert.ToInt32(res);
			else id = 0;
			id++;
			return id.ToString("000000");
		}

		public void InsertName(string name, AIOSubInfoType subInfoType) 
		{
			string table = AIOConstant.GetTableName(subInfoType);

			string id = GenerateSubInfoID(subInfoType);
			string sql = "INSERT INTO " + table + " VALUES(?, ?)";
			OleDbCommand cmd = CreateSqlWithParam(sql, new string[] {id, name});

			ExecuteCommand(cmd);
		}
	
		public void UpdateName(string ID, string name, AIOSubInfoType subInfoType)
		{
			string table = AIOConstant.GetTableName(subInfoType);
			string column = AIOConstant.GetColumnName(subInfoType);

			string sql = "UPDATE " + table + " SET " + column + " = ? WHERE ID = ?";
			OleDbCommand cmd = CreateSqlWithParam(sql, new string[] {name, ID});

			ExecuteCommand(cmd);
		}

		public void DeleteName(string ID, AIOSubInfoType subInfoType) 
		{
			string table = AIOConstant.GetTableName(subInfoType);				

			string sql = "DELETE FROM " + table + " WHERE ID = '" + ID + "'";
			
			try 
			{
				ExecuteDelete(sql);
			}
			catch (Exception e) 
			{
				MessageBox.Show(e.Message);
			}
		}

		public DataTable GetAllName(AIOSubInfoType subInfoType) 
		{
			string table = AIOConstant.GetTableName(subInfoType);
			string column = AIOConstant.GetColumnName(subInfoType);
			
			string sql = "SELECT * FROM " + table + " ORDER BY " + column + " ASC";

			return ExecuteSelect(sql);
		}

		//Queue--------------------------------------------------
		public void QueueCommand(OleDbCommand cmd) 
		{
			queueCommand.Enqueue(cmd);
		}

		public void ExecuteQueueCommand() 
		{
			OleDbCommand sqlCmd;
			while (queueCommand.Count > 0) 
			{
				sqlCmd = (OleDbCommand)queueCommand.Dequeue();

				ExecuteCommand(sqlCmd);
			}
		}
	}
}
