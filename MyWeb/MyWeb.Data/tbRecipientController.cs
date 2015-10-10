using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class tbRecipientDAL : SqlDataProvider
	{
		#region[tbRecipient_GetById]
		public List<tbRecipient> tbRecipient_GetById(string Id)
		{
			List<Data.tbRecipient> list = new List<Data.tbRecipient>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_GetById", GetConnection()))
			{
				Data.tbRecipient obj = new Data.tbRecipient();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ireid", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbRecipientIDataReader(dr));
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
		#region[tbRecipient_GetByTop]
		public List<tbRecipient> tbRecipient_GetByTop(string Top, string Where, string Order)
		{
			List<Data.tbRecipient> list = new List<Data.tbRecipient>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_GetByTop", GetConnection()))
			{
				Data.tbRecipient obj = new Data.tbRecipient();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbRecipientIDataReader(dr));
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
		#region[tbRecipient_GetByAll]
		public List<tbRecipient> tbRecipient_GetByAll()
		{
			List<Data.tbRecipient> list = new List<Data.tbRecipient>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_GetByAll", GetConnection()))
			{
				Data.tbRecipient obj = new Data.tbRecipient();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbRecipientIDataReader(dr));
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
		#region[tbRecipient_Paging]
		public List<tbRecipient> tbRecipient_Paging(string CurentPage, string PageSize)
		{
			List<Data.tbRecipient> list = new List<Data.tbRecipient>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_Paging", GetConnection()))
			{
				Data.tbRecipient obj = new Data.tbRecipient();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbRecipientIDataReader(dr));
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
		#region[tbRecipient_Insert]
		public bool tbRecipient_Insert(tbRecipient data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@iusid", data.iusid));
				dbCmd.Parameters.Add(new SqlParameter("@vcusname", data.vcusname));
				dbCmd.Parameters.Add(new SqlParameter("@dbirthday", data.dbirthday));
				dbCmd.Parameters.Add(new SqlParameter("@vprovince", data.vprovince));
				dbCmd.Parameters.Add(new SqlParameter("@vaddress", data.vaddress));
				dbCmd.Parameters.Add(new SqlParameter("@vphone", data.vphone));
				dbCmd.Parameters.Add(new SqlParameter("@vmobile", data.vmobile));
				dbCmd.Parameters.Add(new SqlParameter("@vemail", data.vemail));
				dbCmd.Parameters.Add(new SqlParameter("@dcreatedate", data.dcreatedate));
				dbCmd.Parameters.Add(new SqlParameter("@istatus", data.istatus));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbRecipient");
			return true;
		}
		#endregion
		#region[tbRecipient_Update]
		public bool tbRecipient_Update(tbRecipient data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ireid", data.ireid));
				dbCmd.Parameters.Add(new SqlParameter("@iusid", data.iusid));
				dbCmd.Parameters.Add(new SqlParameter("@vcusname", data.vcusname));
				dbCmd.Parameters.Add(new SqlParameter("@dbirthday", data.dbirthday));
				dbCmd.Parameters.Add(new SqlParameter("@vprovince", data.vprovince));
				dbCmd.Parameters.Add(new SqlParameter("@vaddress", data.vaddress));
				dbCmd.Parameters.Add(new SqlParameter("@vphone", data.vphone));
				dbCmd.Parameters.Add(new SqlParameter("@vmobile", data.vmobile));
				dbCmd.Parameters.Add(new SqlParameter("@vemail", data.vemail));
				dbCmd.Parameters.Add(new SqlParameter("@dcreatedate", data.dcreatedate));
				dbCmd.Parameters.Add(new SqlParameter("@istatus", data.istatus));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbRecipient");
			return true;
		}
		#endregion
		#region[tbRecipient_Delete]
		public bool tbRecipient_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbRecipient_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ireid", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbRecipient");
			return true;
		}
		#endregion
		
	}
}