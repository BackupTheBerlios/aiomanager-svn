using System;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOBook.
	/// </summary>
	public class AIOBook : AIOCommonInfo
	{
		public string title;
		public string authorID;
		public string genreID;
		public string publisherID;
		public int year;
		public byte [] cover = new byte[0];

		public AIOBook(AIOCommonInfo info) 
		{
			SetCommonInfo(info);
		}

		public void SetBookInfo(string title, string authorID, string genreID, string publisherID, int year, byte[] cover) 
		{
			this.title = title;
			this.authorID = authorID;
			this.genreID = genreID;
			this.publisherID = publisherID;
			this.year = year;
			this.cover = cover;
		}
	}
}
