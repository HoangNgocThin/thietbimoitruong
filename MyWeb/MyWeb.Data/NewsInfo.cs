using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class News
	{
		#region[Declare variables]
		private string  _Id;
		private string  _Name;
		private string  _Tag;
		private string  _Image;
		private string  _Content;
		private string  _Detail;
		private string  _PostedDate;
		private string  _Description;
		private string  _Keyword;
		private string  _Priority;
		private string  _Index;
		private string  _Active;
		private string  _NewsCategoryID;
		private string  _IsHotNews;
        private string _PageCount;
        private string _Title;
		#endregion
		#region[Public Properties]
		public string Id{ get { return _Id; } set { _Id = value; } }
		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Tag{ get { return _Tag; } set { _Tag = value; } }
		public string Image{ get { return _Image; } set { _Image = value; } }
		public string Content{ get { return _Content; } set { _Content = value; } }
		public string Detail{ get { return _Detail; } set { _Detail = value; } }
		public string PostedDate{ get { return _PostedDate; } set { _PostedDate = value; } }
		public string Description{ get { return _Description; } set { _Description = value; } }
		public string Keyword{ get { return _Keyword; } set { _Keyword = value; } }
		public string Priority{ get { return _Priority; } set { _Priority = value; } }
		public string Index{ get { return _Index; } set { _Index = value; } }
		public string Active{ get { return _Active; } set { _Active = value; } }
		public string NewsCategoryID{ get { return _NewsCategoryID; } set { _NewsCategoryID = value; } }
		public string IsHotNews{ get { return _IsHotNews; } set { _IsHotNews = value; } }
        public string PageCount { get { return _PageCount; } set { _PageCount = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
		#endregion
		#region[News IDataReader]
		public News NewsIDataReader(IDataReader dr)
		{
			Data.News obj = new Data.News();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
			obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
			obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
			obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
			obj.PostedDate = (dr["PostedDate"] is DBNull) ? string.Empty : dr["PostedDate"].ToString();
			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
			obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
			obj.Priority = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();
			obj.Index = (dr["Index"] is DBNull) ? string.Empty : dr["Index"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.NewsCategoryID = (dr["NewsCategoryID"] is DBNull) ? string.Empty : dr["NewsCategoryID"].ToString();
			obj.IsHotNews = (dr["IsHotNews"] is DBNull) ? string.Empty : dr["IsHotNews"].ToString();
            obj.PageCount = (dr["PageCount"] is DBNull) ? string.Empty : dr["PageCount"].ToString();
            obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
			return obj;
		}
		#endregion
	}
}