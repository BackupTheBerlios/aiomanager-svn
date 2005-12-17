using System;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOBookController.
	/// </summary>
	public class AIOBookController : AIOCommonController
	{
		public AIOBookController(AIODatabase aioDb) : base(aioDb) {}
		
		//Database Access
		public override void InsertQueue(string ID, string path)
		{
			base.InsertQueue (ID, path);

			string sql = "INSERT INTO Book VALUES(?, ?, ?, ?, ?, ?, ?)";
			OleDbCommand cmd = aioDb.CreateSqlWithParam(sql, new object[] {ID, "(Untitled)", "000001", "000001", 0, "000001", ""});

			aioDb.QueueCommand(cmd);
		}

		public override void UpdateInfo(AIOCommonInfo info)
		{
			base.UpdateInfo (info);

			AIOBook book = (AIOBook)info;
			//Be careful: year is a SQL Keyword. Put it into square brackets.
			string sql = "UPDATE Book SET title = ?, authorID = ?, genreID = ?, publisherID = ?, [year] = ? WHERE ID = ?";
			OleDbCommand cmd = aioDb.CreateSqlWithParam(sql, new object[] {book.title, book.authorID, book.genreID, book.publisherID, book.year, book.ID});

			//Execute it
			aioDb.ExecuteCommand(cmd);
		}

		public override AIOCommonInfo Select(string ID)
		{
			AIOBook book = new AIOBook(base.Select(ID));

			string sql = "SELECT * FROM Book WHERE ID = '" + ID + "'";
			DataTable table = aioDb.ExecuteSelect(sql);
			//ID - Title - AuthorID - GenreID - Year - PublisherID - Cover
			object [] obj = table.Rows[0].ItemArray;
			book.title = obj[1].ToString();
			book.authorID = obj[2].ToString();
			book.genreID = obj[3].ToString();
			book.year = Convert.ToInt32(obj[4]);
			book.publisherID = obj[5].ToString();
			book.cover = Encoding.UTF8.GetBytes(obj[6].ToString());

			return book;
		}
	}
}
