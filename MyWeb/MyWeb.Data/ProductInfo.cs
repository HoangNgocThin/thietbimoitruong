using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class Product
	{
		#region[Declare variables]
		private string  _ID;
		private string  _Name;
		private string  _Title;
		private string  _Tag;
		private string  _Content;
		private string  _Ord;
		private string  _Decription;
		private string  _MetaKeyword;
		private string  _Active;
		private string  _SalePrice;
		private string  _Image;
		private string  _CreatedDate;
		private string  _ProductCategoryID;
		private string  _ModifiedDate;
		private string  _Priority;
		private string  _Image1;
		private string  _Image2;
		private string  _Image3;
		private string  _Image4;
		private string  _Image5;
		private string  _Detail;
		private string  _CapacityID;
		private string  _BranchID;
		private string  _ProductCode;
		private string  _UnitPrice;
        private string _CountSale;
        private string _CategoryName;
        private string _CapacityName;
        private string _BranchName;
        private string _PageCount;
        private string _Unit;
		#endregion
		#region[Public Properties]
		public string ID{ get { return _ID; } set { _ID = value; } }
		public string Name{ get { return _Name; } set { _Name = value; } }
		public string Title{ get { return _Title; } set { _Title = value; } }
		public string Tag{ get { return _Tag; } set { _Tag = value; } }
		public string Content{ get { return _Content; } set { _Content = value; } }
		public string Ord{ get { return _Ord; } set { _Ord = value; } }
		public string Decription{ get { return _Decription; } set { _Decription = value; } }
		public string MetaKeyword{ get { return _MetaKeyword; } set { _MetaKeyword = value; } }
		public string Active{ get { return _Active; } set { _Active = value; } }
		public string SalePrice{ get { return _SalePrice; } set { _SalePrice = value; } }
		public string Image{ get { return _Image; } set { _Image = value; } }
		public string CreatedDate{ get { return _CreatedDate; } set { _CreatedDate = value; } }
		public string ProductCategoryID{ get { return _ProductCategoryID; } set { _ProductCategoryID = value; } }
		public string ModifiedDate{ get { return _ModifiedDate; } set { _ModifiedDate = value; } }
		public string Priority{ get { return _Priority; } set { _Priority = value; } }
		public string Image1{ get { return _Image1; } set { _Image1 = value; } }
		public string Image2{ get { return _Image2; } set { _Image2 = value; } }
		public string Image3{ get { return _Image3; } set { _Image3 = value; } }
		public string Image4{ get { return _Image4; } set { _Image4 = value; } }
		public string Image5{ get { return _Image5; } set { _Image5 = value; } }
		public string Detail{ get { return _Detail; } set { _Detail = value; } }
		public string CapacityID{ get { return _CapacityID; } set { _CapacityID = value; } }
		public string BranchID{ get { return _BranchID; } set { _BranchID = value; } }
		public string ProductCode{ get { return _ProductCode; } set { _ProductCode = value; } }
		public string UnitPrice{ get { return _UnitPrice; } set { _UnitPrice = value; } }
        public string CountSale { get { return _CountSale; } set { _CountSale = value; } }
        public string CategoryName { get { return _CategoryName; } set { _CategoryName = value; } }
        public string CapacityName { get { return _CapacityName; } set { _CapacityName = value; } }
        public string BranchName { get { return _BranchName; } set { _BranchName = value; } }
        public string PageCount { get { return _PageCount; } set { _PageCount = value; } }
        public string Unit { get { return _Unit; } set { _Unit = value; } }
		#endregion
		#region[Product IDataReader]
		public Product ProductIDataReader(IDataReader dr)
		{
			Data.Product obj = new Data.Product();
			obj.ID = (dr["ID"] is DBNull) ? string.Empty : dr["ID"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
			obj.Tag = (dr["Tag"] is DBNull) ? string.Empty : dr["Tag"].ToString();
			obj.Content = (dr["Content"] is DBNull) ? string.Empty : dr["Content"].ToString();
			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Decription = (dr["Decription"] is DBNull) ? string.Empty : dr["Decription"].ToString();
			obj.MetaKeyword = (dr["MetaKeyword"] is DBNull) ? string.Empty : dr["MetaKeyword"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.SalePrice = (dr["SalePrice"] is DBNull) ? string.Empty : dr["SalePrice"].ToString();
			obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
			obj.CreatedDate = (dr["CreatedDate"] is DBNull) ? string.Empty : dr["CreatedDate"].ToString();
			obj.ProductCategoryID = (dr["ProductCategoryID"] is DBNull) ? string.Empty : dr["ProductCategoryID"].ToString();
			obj.ModifiedDate = (dr["ModifiedDate"] is DBNull) ? string.Empty : dr["ModifiedDate"].ToString();
			obj.Priority = (dr["Priority"] is DBNull) ? string.Empty : dr["Priority"].ToString();
			obj.Image1 = (dr["Image1"] is DBNull) ? string.Empty : dr["Image1"].ToString();
			obj.Image2 = (dr["Image2"] is DBNull) ? string.Empty : dr["Image2"].ToString();
			obj.Image3 = (dr["Image3"] is DBNull) ? string.Empty : dr["Image3"].ToString();
			obj.Image4 = (dr["Image4"] is DBNull) ? string.Empty : dr["Image4"].ToString();
			obj.Image5 = (dr["Image5"] is DBNull) ? string.Empty : dr["Image5"].ToString();
			obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
			obj.CapacityID = (dr["CapacityID"] is DBNull) ? string.Empty : dr["CapacityID"].ToString();
			obj.BranchID = (dr["BranchID"] is DBNull) ? string.Empty : dr["BranchID"].ToString();
			obj.ProductCode = (dr["ProductCode"] is DBNull) ? string.Empty : dr["ProductCode"].ToString();
			obj.UnitPrice = (dr["UnitPrice"] is DBNull) ? string.Empty : dr["UnitPrice"].ToString();
            obj.CountSale = (dr["CountSale"] is DBNull) ? string.Empty : dr["CountSale"].ToString();
            obj.CategoryName = (dr["CategoryName"] is DBNull) ? string.Empty : dr["CategoryName"].ToString();
            obj.CapacityName = (dr["CapacityName"] is DBNull) ? string.Empty : dr["CapacityName"].ToString();
            obj.BranchName = (dr["BranchName"] is DBNull) ? string.Empty : dr["BranchName"].ToString();
            obj.PageCount = (dr["PageCount"] is DBNull) ? string.Empty : dr["PageCount"].ToString();
            obj.Unit = (dr["Unit"] is DBNull) ? string.Empty : dr["Unit"].ToString();
			return obj;
		}
		#endregion
	}
}