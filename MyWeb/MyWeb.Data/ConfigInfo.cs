using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace MyWeb.Data{	public class Config	{		#region[Declare variables]		private string  _Id;		private string  _SendGmail;		private string  _Password;		private string  _ReceiveGmail;		private string  _Banner;		private string  _Footer;		private string  _PageTitle;		private string  _Description;		private string  _MetaKeyword;		private string  _ModifiedDate;		private string  _IsApply;		#endregion		#region[Public Properties]		public string Id{ get { return _Id; } set { _Id = value; } }		public string SendGmail{ get { return _SendGmail; } set { _SendGmail = value; } }		public string Password{ get { return _Password; } set { _Password = value; } }		public string ReceiveGmail{ get { return _ReceiveGmail; } set { _ReceiveGmail = value; } }		public string Banner{ get { return _Banner; } set { _Banner = value; } }		public string Footer{ get { return _Footer; } set { _Footer = value; } }		public string PageTitle{ get { return _PageTitle; } set { _PageTitle = value; } }		public string Description{ get { return _Description; } set { _Description = value; } }		public string MetaKeyword{ get { return _MetaKeyword; } set { _MetaKeyword = value; } }		public string ModifiedDate{ get { return _ModifiedDate; } set { _ModifiedDate = value; } }		public string IsApply{ get { return _IsApply; } set { _IsApply = value; } }		#endregion		#region[Config IDataReader]		public Config ConfigIDataReader(IDataReader dr)		{			Data.Config obj = new Data.Config();			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();			obj.SendGmail = (dr["SendGmail"] is DBNull) ? string.Empty : dr["SendGmail"].ToString();			obj.Password = (dr["Password"] is DBNull) ? string.Empty : dr["Password"].ToString();			obj.ReceiveGmail = (dr["ReceiveGmail"] is DBNull) ? string.Empty : dr["ReceiveGmail"].ToString();			obj.Banner = (dr["Banner"] is DBNull) ? string.Empty : dr["Banner"].ToString();			obj.Footer = (dr["Footer"] is DBNull) ? string.Empty : dr["Footer"].ToString();			obj.PageTitle = (dr["PageTitle"] is DBNull) ? string.Empty : dr["PageTitle"].ToString();			obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();			obj.MetaKeyword = (dr["MetaKeyword"] is DBNull) ? string.Empty : dr["MetaKeyword"].ToString();			obj.ModifiedDate = (dr["ModifiedDate"] is DBNull) ? string.Empty : dr["ModifiedDate"].ToString();			obj.IsApply = (dr["IsApply"] is DBNull) ? string.Empty : dr["IsApply"].ToString();			return obj;		}		#endregion	}}