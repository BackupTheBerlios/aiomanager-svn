using System;
using System.IO;
using System.Collections;

namespace AIOCommon
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AIOCommonInfo
	{
		//Data
		public string ID;
		public int ratings;
		public int icon;
		public string comment;
		public string path;
		public string createdDate;

		public AIOCommonInfo() {}

		public void SetCommonInfo(AIOCommonInfo info) 
		{
			SetCommonInfo(info.ID, info.ratings, info.icon, info.comment, info.path, info.createdDate);
		}

		public void SetCommonInfo(string ID, int ratings, int icon, string comment, string path, string createdDate)
		{
			this.ID = ID;
			this.ratings = ratings;
			this.icon = icon;
			this.comment = comment;
			this.path = path;
			this.createdDate = createdDate;
		}

		/*
		public void Synchronize() 
		{

		}

		public static ArrayList Synchronize(string path, string pattern, bool bRecursive) 
		{
			DirectoryInfo di = new DirectoryInfo(path);
			if (di.Exists) 
			{
				ArrayList list = new ArrayList();
				DirectoryInfo [] subDi = di.GetDirectories(pattern);
				if (subDi.Length > 0) //Co thu muc con
				{
					if (bRecursive) 
					{
						for (int i = 0;i<subDi.Length;i++)
						{
							ArrayList subList = Synchronize(subDi[i].FullName, pattern, bRecursive);
							list.AddRange(subList);
						}
					}
				} 
				else //Khong co thu muc con
				{
					//Duyet het file va tra ve
					FileInfo [] fileInfo = di.GetFiles();
					//Check xem file na`o thoa
					for (int i = 0;i<fileInfo.Length;i++)
					{
						list.Add(fileInfo[i].Name);
					}
				 }
				
				//Return
				return list;
			}
			else //Khong ton tai thu muc nay
			{
				return null;
			}
		}*/
	}
}
