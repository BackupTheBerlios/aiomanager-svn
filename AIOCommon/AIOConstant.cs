using System;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for AIOConstant.
	/// </summary>
	
	public enum AIOModule {MODULE_BOOK, MODULE_MUSIC, MODULE_MOVIE, MODULE_CDDVD, MODULE_PHOTO};
	public enum AIOSubInfoType {BOOK_AUTHOR, BOOK_GENRE, BOOK_PUBLISHER, CD_GENRE, MOVIE_DIRECTOR, MOVIE_ACTOR, MOVIE_ACTRESS, MUSIC_ALBUM, MUSIC_ARTIST, PHOTO_ALBUM};
	
	public class AIOConstant
	{
		public static string [] modulePrefix = {"B", "M", "F", "C", "P"};
		public static string [] moduleName = {"Book", "Music", "Movie", "Disc", "Photo"};
																				 
		public static string directoryPrefix = "#";		

		//Constant				
		private static string [] TableName = {"BookAuthor", "BookGenre", "BookPublisher"};
		private static string [] ColumnName = {"AuthorName", "GenreName", "PublisherName"};

		public static string GetTableName(AIOSubInfoType subInfoType) 
		{	
			return AIOConstant.TableName[(int)subInfoType];
		}
		public static string GetColumnName(AIOSubInfoType subInfoType) 
		{
			return AIOConstant.ColumnName[(int)subInfoType];
		}
		public static string GetModuleName(AIOModule module) 
		{
			return moduleName[(int)module];
		}
	}
}
