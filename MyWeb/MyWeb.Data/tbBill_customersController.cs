using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Configuration;
namespace MyWeb.Data
{
	public class tbBill_customersDAL : SqlDataProvider
	{
		#region[tbBill_customers_GetById]
		public List<tbBill_customers> tbBill_customers_GetById(string Id)
		{
			List<Data.tbBill_customers> list = new List<Data.tbBill_customers>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_GetById", GetConnection()))
			{
				Data.tbBill_customers obj = new Data.tbBill_customers();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@billid", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBill_customersIDataReader(dr));
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
		#region[tbBill_customers_GetByTop]
		public List<tbBill_customers> tbBill_customers_GetByTop(string Top, string Where, string Order)
		{
			List<Data.tbBill_customers> list = new List<Data.tbBill_customers>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_GetByTop", GetConnection()))
			{
				Data.tbBill_customers obj = new Data.tbBill_customers();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBill_customersIDataReader(dr));
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
		#region[tbBill_customers_GetByAll]
		public List<tbBill_customers> tbBill_customers_GetByAll(string Lang)
		{
			List<Data.tbBill_customers> list = new List<Data.tbBill_customers>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_GetByAll", GetConnection()))
			{
				Data.tbBill_customers obj = new Data.tbBill_customers();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Lang", Lang));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBill_customersIDataReader(dr));
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
		#region[tbBill_customers_Paging]
		public List<tbBill_customers> tbBill_customers_Paging(string CurentPage, string PageSize, string Lang)
		{
			List<Data.tbBill_customers> list = new List<Data.tbBill_customers>();
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_Paging", GetConnection()))
			{
				Data.tbBill_customers obj = new Data.tbBill_customers();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				dbCmd.Parameters.Add(new SqlParameter("@Lang", Lang));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.tbBill_customersIDataReader(dr));
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
		#region[tbBill_customers_Insert]
		public bool tbBill_customers_Insert(tbBill_customers data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@userid", data.userid == "" || data.userid == "0" ? DBNull.Value : (object)data.userid));
				dbCmd.Parameters.Add(new SqlParameter("@totalmoney", data.totalmoney));
				dbCmd.Parameters.Add(new SqlParameter("@idate", data.idate));
				dbCmd.Parameters.Add(new SqlParameter("@xdate", data.xdate));
				dbCmd.Parameters.Add(new SqlParameter("@request", data.request));
				dbCmd.Parameters.Add(new SqlParameter("@typepay", data.typepay));
				dbCmd.Parameters.Add(new SqlParameter("@state", data.state));
				dbCmd.Parameters.Add(new SqlParameter("@lang", data.lang));
				dbCmd.Parameters.Add(new SqlParameter("@show", data.show));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBill_customers");
			return true;
		}
		#endregion

        #region[tbBill_customers_Insert1]
        public string tbBill_customers_Insert1(tbBill_customers data)
        {
            string sql = "INSERT INTO [tbBill_customers]([userid], [totalmoney], [idate], [xdate], [request], [typepay], [state], [lang], [show]) VALUES(" + data.userid + ", N'" + data.totalmoney + "', '"+data.idate+"', '"+data.xdate+"', N'"+data.request+"', '"+data.typepay+"', '"+data.state+"', N'"+data.lang+"', '"+data.show+"')";
            using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
            {
                cmd.Parameters.Add(new SqlParameter("@totalmoney", data.totalmoney));
                cmd.Parameters.Add(new SqlParameter("@idate", data.idate));
                cmd.Parameters.Add(new SqlParameter("@xdate", data.xdate));
                cmd.Parameters.Add(new SqlParameter("@request", data.request));
                cmd.Parameters.Add(new SqlParameter("@typepay", data.typepay));
                cmd.Parameters.Add(new SqlParameter("@state", data.state));
                cmd.Parameters.Add(new SqlParameter("@lang", data.lang));
                cmd.Parameters.Add(new SqlParameter("@show", data.show));
                cmd.Parameters.Add(new SqlParameter("@userid", int.Parse(data.userid)));
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString());
                    DataTable dt = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter("select isnull(max(billid),0) from  tbBill_customers ", con);
                    DA.Fill(dt);
                    return dt.Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd != null) cmd.Dispose();
                }
            }
        }
        #endregion
		#region[tbBill_customers_Update]
		public bool tbBill_customers_Update(tbBill_customers data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@billid", data.billid));
				dbCmd.Parameters.Add(new SqlParameter("@userid", data.userid == "" || data.userid == "0" ? DBNull.Value : (object)data.userid));
				dbCmd.Parameters.Add(new SqlParameter("@totalmoney", data.totalmoney));
				dbCmd.Parameters.Add(new SqlParameter("@idate", data.idate));
				dbCmd.Parameters.Add(new SqlParameter("@xdate", data.xdate));
				dbCmd.Parameters.Add(new SqlParameter("@request", data.request));
				dbCmd.Parameters.Add(new SqlParameter("@typepay", data.typepay));
				dbCmd.Parameters.Add(new SqlParameter("@state", data.state));
				dbCmd.Parameters.Add(new SqlParameter("@lang", data.lang));
				dbCmd.Parameters.Add(new SqlParameter("@show", data.show));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBill_customers");
			return true;
		}
		#endregion
		#region[tbBill_customers_Delete]
		public bool tbBill_customers_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_tbBill_customers_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@billid", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("tbBill_customers");
			return true;
		}
		#endregion
		
	}
}