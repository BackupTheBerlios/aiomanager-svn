using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AIOValidation
	{
		public AIOValidation()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		int convertString ( string str )
		{
			return System.Convert.ToInt32( str );
		}

		bool isNummeric( string str )
		{
			int num;
			try
			{
				num = System.Convert.ToInt32( str );
				return true;
			}
			catch( Exception e )
			{
				return false;
			}
		}

		bool isPositiveNumber( string str )
		{
			int num;
			if ( isNummeric( str ) )
			{
				num = convertString( str );
				if ( num > 0 )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		bool isDay( string str )
		{
			int num;
			if ( isNummeric( str ) )
			{
				num = convertString( str );
				if ( ( 1 <= num ) && ( num <= 31 ) )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		bool isMonth( string str )
		{
			int num;
			if ( isNummeric( str ) )
			{
				num = convertString( str );
				if ( ( 1 <= num ) && ( num <= 12 ) )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		bool isYear( string str )
		{
			int num;
			if ( isNummeric( str ) )
			{
				num = convertString( str );
				if ( ( 1900 <= num ) && ( num <= 2099 ) )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		bool isDate( string str, string splitter, string mode )
		{
			int day;
			int month;
			int year;
			string[] date = new string[3];
			str.Trim();
			date = splitToDayMonthYear( str, splitter );
			if ( mode.Equals( "mm/dd/yyyy" ) )
			{
				if( isDay( date[1] ) )
				{
					day = convertString( date[1] );
				}
				else
				{
					return false;
				}
				if ( isMonth( date[0] ) )
				{
					month = convertString( date[0] );
				}
				else
				{
					return false;
				}
			}
			else
			{
				if( isDay( date[0] ) )
				{
					day = convertString( date[0] );
				}
				else
				{
					return false;
				}
				if ( isMonth( date[1] ) )
				{
					month = convertString( date[1] );
				}
				else
				{
					return false;
				}
			}
			if ( isYear( date[2] ) )
			{
				year = convertString( date[2] );
			}
			else
			{
				return false;
			}
			switch( month )
			{
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					return true;
				case 4:
				case 6:
				case 9:
				case 11:
					if ( 30 <= day )
					{
						return true;
					}
					else
					{
						return false;
					}
				case 2:
					if ( ( (year % 4 == 0) && ( year % 100 == 0 ) ) || ( year % 4 != 0 ) ) //ko phai nam nhuan
					{
						if ( 28 <= day )
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else //la nam nhuan
					{
						if ( 29 <= day )
						{
							return true;
						}
						else
						{
							return false;
						}
					}
			}
			return true;
		}

		bool isDateBefore( string strdate, string compareDate, string splitter, string mode )
		{
			int day, month, year;
			int Cday, Cmonth, Cyear;
			string[] date = new string[3];
			strdate.Trim();
			compareDate.Trim();
			date = splitToDayMonthYear( strdate, splitter );
			if ( mode.Equals( "mm/dd/yyyy" ) )
			{
				day = convertString( date[1] );
				month = convertString( date[0] );
			}
			else
			{
				day = convertString( date[0] );
				month = convertString( date[1] );
			}
			year = convertString( date[2] );
			date = splitToDayMonthYear( compareDate, splitter );
			if ( mode.Equals( "mm/dd/yyyy" ) )
			{
				Cday = convertString( date[1] );
				Cmonth = convertString( date[0] );
			}
			else
			{
				Cday = convertString( date[0] );
				Cmonth = convertString( date[1] );
			}
			Cyear = convertString( date[2] );
			if ( year == Cyear )
			{
				if ( month == Cmonth )
				{
					if ( ( day == Cday ) || ( day > Cday ) )
					{
						return false;
					}
					else
					{
						return true;
					}
				}
				if ( month > Cmonth )
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			if ( year > Cyear )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		string[] splitToDayMonthYear( string strdate, string splitter )
		{
			char[] split = splitter.ToCharArray();
			string[] date = new string[3];
			strdate.Trim();
			date = strdate.Split( split );
			return date;
		}

		bool isBlank( string str )
		{
			str.Trim();
			if ( str.Equals( "" ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		bool isInList( string str, string[] list )
		{
			for ( int i = 0; i < list.Length; i++ )
			{
				if ( str == list[i] )
				{
					return true;
				}
			}
			return false;
		}

		bool isInList( string str, ArrayList list )
		{
			for ( int i = 0; i < list.Count; i++ )
			{
				if ( str == list[i] )
				{
					return true;
				}
			}
			return false;
		}

		bool isValidEmail( string email )
		{
			string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
				@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
				@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			Regex re = new Regex(strRegex);
			if ( re.IsMatch( email ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
