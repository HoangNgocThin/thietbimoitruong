using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class GroupVideo
	{
		#region[Declare variables]
		private string  _Id;
		private string  _Name;
		private string  _Tag;
		private string  _Level;
		private string  _Title;
		private string  _Description;
		private string  _Keyword;
		private string  _Ord;
		private string  _Active;
		private string  _Lang;
		#endregion
		#region[Public Properties]
		public string Id{ get { return _Id; } set { _Id = value; } }
		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Tag{ get { return _Tag; } set { _Tag = value; } }
		public string Level{ get { return _Level; } set { _Level = value; } }
		public string Title{ get { return _Title; } set { _Title = value; } }
		public string Description{ get { return _Description; } set { _Description = value; } }
		public string Keyword{ get { return _Keyword; } set { _Keyword = value; } }
		public string Ord{ get { return _Ord; } set { _Ord = value; } }
		public string Active{ get { return _Active; } set { _Active = value; } }
		public string Lang{ get { return _Lang; } set { _Lang = value; } }
		#endregion
		#region[GroupVideo IDataReader]
		public GroupVideo GroupVideoIDataReader(IDataReader dr)
		{
			Data.GroupVideo obj = new Data.GroupVideo();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
			obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
			obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
			obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
			return obj;
		}
		#endregion
	}
}