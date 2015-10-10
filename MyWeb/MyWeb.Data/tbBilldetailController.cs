using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class tbBilldetailDAL : SqlDataProvider
	{
		#region[tbBilldetail_GetById]
		public List<tbBilldetail> tbBilldetail_GetById(string Id)
		{
			List<Data.tbBilldetail> list = new List<Data.tbBilldetail>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_GetById", GetConnection()))
			{
				Data.tbBilldetail obj = new Data.tbBilldetail();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBilldetailIDataReader(dr));
					}
					dr.Close();
					//conn.Close();
				}
                else
                {
                    dr.Close();
                }
			}
			return list;
		}
		#endregion
		#region[tbBilldetail_GetByTop]
		public List<tbBilldetail> tbBilldetail_GetByTop(string Top, string Where, string Order)
		{
			List<Data.tbBilldetail> list = new List<Data.tbBilldetail>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_GetByTop", GetConnection()))
			{
				Data.tbBilldetail obj = new Data.tbBilldetail();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBilldetailIDataReader(dr));
					}
					dr.Close();
					//conn.Close();
				}
                else
                {
                    dr.Close();
                }
			}
			return list;
		}
		#endregion
		#region[tbBilldetail_GetByAll]
		public List<tbBilldetail> tbBilldetail_GetByAll()
		{
			List<Data.tbBilldetail> list = new List<Data.tbBilldetail>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_GetByAll", GetConnection()))
			{
				Data.tbBilldetail obj = new Data.tbBilldetail();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBilldetailIDataReader(dr));
					}
					dr.Close();
					//conn.Close();
				}
                else
                {
                    dr.Close();
                }
			}
			return list;
		}
		#endregion
		#region[tbBilldetail_Paging]
		public List<tbBilldetail> tbBilldetail_Paging(string CurentPage, string PageSize)
		{
			List<Data.tbBilldetail> list = new List<Data.tbBilldetail>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_Paging", GetConnection()))
			{
				Data.tbBilldetail obj = new Data.tbBilldetail();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBilldetailIDataReader(dr));
					}
					dr.Close();
					//conn.Close();
				}
                else
                {
                    dr.Close();
                }
			}
		return list;
		}
		#endregion
		#region[tbBilldetail_Insert]
		public bool tbBilldetail_Insert(tbBilldetail data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@bilid", data.bilid == "" || data.bilid == "0" ? DBNull.Value : (object)data.bilid));
				dbCmd.Parameters.Add(new SqlParameter("@proid", data.proid == "" || data.proid == "0" ? DBNull.Value : (object)data.proid));
				dbCmd.Parameters.Add(new SqlParameter("@sizeid", data.sizeid));
				dbCmd.Parameters.Add(new SqlParameter("@colorid", data.colorid));
				dbCmd.Parameters.Add(new SqlParameter("@quantity", data.quantity));
				dbCmd.Parameters.Add(new SqlParameter("@bilprice", data.bilprice));
				dbCmd.Parameters.Add(new SqlParameter("@bilpricevnd", data.bilpricevnd));
				dbCmd.Parameters.Add(new SqlParameter("@bilmoney", data.bilmoney));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBilldetail");
			return true;
		}
		#endregion
		#region[tbBilldetail_Update]
		public bool tbBilldetail_Update(tbBilldetail data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@id", data.id));
				dbCmd.Parameters.Add(new SqlParameter("@bilid", data.bilid == "" || data.bilid == "0" ? DBNull.Value : (object)data.bilid));
				dbCmd.Parameters.Add(new SqlParameter("@proid", data.proid == "" || data.proid == "0" ? DBNull.Value : (object)data.proid));
				dbCmd.Parameters.Add(new SqlParameter("@sizeid", data.sizeid));
				dbCmd.Parameters.Add(new SqlParameter("@colorid", data.colorid));
				dbCmd.Parameters.Add(new SqlParameter("@quantity", data.quantity));
				dbCmd.Parameters.Add(new SqlParameter("@bilprice", data.bilprice));
				dbCmd.Parameters.Add(new SqlParameter("@bilpricevnd", data.bilpricevnd));
				dbCmd.Parameters.Add(new SqlParameter("@bilmoney", data.bilmoney));
				dbCmd.Parameters.Add(new SqlParameter("@billlocation", data.billlocation));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBilldetail");
			return true;
		}
		#endregion
		#region[tbBilldetail_Delete]
		public bool tbBilldetail_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBilldetail_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBilldetail");
			return true;
		}
		#endregion
		
	}
}