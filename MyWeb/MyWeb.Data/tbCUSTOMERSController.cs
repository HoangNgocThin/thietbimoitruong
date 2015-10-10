using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class tbCUSTOMERSDAL : SqlDataProvider
	{
		#region[tbCUSTOMERS_GetById]
		public List<tbCUSTOMERS> tbCUSTOMERS_GetById(string Id)
		{
			List<Data.tbCUSTOMERS> list = new List<Data.tbCUSTOMERS>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_GetById", GetConnection()))
			{
				Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@iusid", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbCUSTOMERSIDataReader(dr));
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
		#region[tbCUSTOMERS_GetByTop]
		public List<tbCUSTOMERS> tbCUSTOMERS_GetByTop(string Top, string Where, string Order)
		{
			List<Data.tbCUSTOMERS> list = new List<Data.tbCUSTOMERS>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_GetByTop", GetConnection()))
			{
				Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbCUSTOMERSIDataReader(dr));
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
		#region[tbCUSTOMERS_GetByAll]
		public List<tbCUSTOMERS> tbCUSTOMERS_GetByAll()
		{
			List<Data.tbCUSTOMERS> list = new List<Data.tbCUSTOMERS>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_GetByAll", GetConnection()))
			{
				Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbCUSTOMERSIDataReader(dr));
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
		#region[tbCUSTOMERS_Paging]
		public List<tbCUSTOMERS> tbCUSTOMERS_Paging(string CurentPage, string PageSize)
		{
			List<Data.tbCUSTOMERS> list = new List<Data.tbCUSTOMERS>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_Paging", GetConnection()))
			{
				Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbCUSTOMERSIDataReader(dr));
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
        #region[tbCUSTOMERS_Get_Customer_Order]

        public List<Data.tbCUSTOMERS> Get_Customer_Order_By_lang()
        {
            List<Data.tbCUSTOMERS> list = new List<Data.tbCUSTOMERS>();
            using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_Paging", GetConnection()))
            {
                Data.tbCUSTOMERS obj = new Data.tbCUSTOMERS();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.tbCUSTOMERSIDataReader(dr));
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

		#region[tbCUSTOMERS_Insert]
		public bool tbCUSTOMERS_Insert(tbCUSTOMERS data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@vusername", data.vusername));
				dbCmd.Parameters.Add(new SqlParameter("@vpassword", data.vpassword));
				dbCmd.Parameters.Add(new SqlParameter("@vcusname", data.vcusname));
				dbCmd.Parameters.Add(new SqlParameter("@dbirthday", data.dbirthday));
				dbCmd.Parameters.Add(new SqlParameter("@vaddress", data.vaddress));
				dbCmd.Parameters.Add(new SqlParameter("@vphone", data.vphone));
				dbCmd.Parameters.Add(new SqlParameter("@vemail", data.vemail));
				dbCmd.Parameters.Add(new SqlParameter("@dcreatedate", data.dcreatedate));
				dbCmd.Parameters.Add(new SqlParameter("@istatus", data.istatus));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbCUSTOMERS");
			return true;
		}
		#endregion
		#region[tbCUSTOMERS_Update]
		public bool tbCUSTOMERS_Update(tbCUSTOMERS data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@iusid", data.iusid));
				dbCmd.Parameters.Add(new SqlParameter("@vusername", data.vusername));
				dbCmd.Parameters.Add(new SqlParameter("@vpassword", data.vpassword));
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
			System.Web.HttpContext.Current.Cache.Remove("tbCUSTOMERS");
			return true;
		}
		#endregion
		#region[tbCUSTOMERS_Delete]
		public bool tbCUSTOMERS_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbCUSTOMERS_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@iusid", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbCUSTOMERS");
			return true;
		}
		#endregion
		
	}
}