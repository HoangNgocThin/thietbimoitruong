using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class ProductCategory
	{
		#region[Declare variables]
		private string  _ID;
		private string  _Name;
		private string  _Title;
		private string  _Tag;
		private string  _Level;
		private string  _Ord;
		private string  _Description;
		private string  _MetaKeyword;
		private string  _Active;
        private string _Type;
        private string _IsDisplayInHome;
		#endregion
		#region[Public Properties]
		public string ID{ get { return _ID; } set { _ID = value; } }
		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Title{ get { return _Title; } set { _Title = value; } }
		public string Tag{ get { return _Tag; } set { _Tag = value; } }
		public string Level{ get { return _Level; } set { _Level = value; } }
		public string Ord{ get { return _Ord; } set { _Ord = value; } }
		public string Description{ get { return _Description; } set { _Description = value; } }
		public string MetaKeyword{ get { return _MetaKeyword; } set { _MetaKeyword = value; } }
		public string Active{ get { return _Active; } set { _Active = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string IsDisplayInHome { get { return _IsDisplayInHome; } set { _IsDisplayInHome = value; } }
		#endregion
		#region[ProductCategory IDataReader]
		public ProductCategory ProductCategoryIDataReader(IDataReader dr)
		{
			Data.ProductCategory obj = new Data.ProductCategory();
			obj.ID = (dr["ID"] is DBNull) ? string.Empty : dr["ID"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
			obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
			obj.Level = (dr["Level"] is DBNull) ? string.Empty : dr["Level"].ToString();
			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
			obj.MetaKeyword = (dr["MetaKeyword"] is DBNull) ? string.Empty : dr["MetaKeyword"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Type = (dr["Type"] is DBNull) ? string.Empty : dr["Type"].ToString();
            obj.IsDisplayInHome = (dr["IsDisplayInHome"] is DBNull) ? string.Empty : dr["IsDisplayInHome"].ToString();
			return obj;
		}
		#endregion
	}
}