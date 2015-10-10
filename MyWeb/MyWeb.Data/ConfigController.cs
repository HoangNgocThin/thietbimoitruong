using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class ConfigDAL : SqlDataProvider
	{
		#region[Config_GetById]
		public List<Config> Config_GetById(string Id)
		{
			List<Data.Config> list = new List<Data.Config>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_GetById", GetConnection()))
			{
				Data.Config obj = new Data.Config();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ConfigIDataReader(dr));
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
		#region[Config_GetByTop]
		public List<Config> Config_GetByTop(string Top, string Where, string Order)
		{
			List<Data.Config> list = new List<Data.Config>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_GetByTop", GetConnection()))
			{
				Data.Config obj = new Data.Config();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ConfigIDataReader(dr));
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
		#region[Config_GetByAll]
		public List<Config> Config_GetByAll()
		{
			List<Data.Config> list = new List<Data.Config>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_GetByAll", GetConnection()))
			{
				Data.Config obj = new Data.Config();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ConfigIDataReader(dr));
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
		#region[Config_Paging]
		public List<Config> Config_Paging(string CurentPage, string PageSize)
		{
			List<Data.Config> list = new List<Data.Config>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_Paging", GetConnection()))
			{
				Data.Config obj = new Data.Config();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ConfigIDataReader(dr));
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
		#region[Config_Insert]
		public bool Config_Insert(Config data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@SendGmail", data.SendGmail));
				dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
				dbCmd.Parameters.Add(new SqlParameter("@ReceiveGmail", data.ReceiveGmail));
				dbCmd.Parameters.Add(new SqlParameter("@Banner", data.Banner));
				dbCmd.Parameters.Add(new SqlParameter("@Footer", data.Footer));
				dbCmd.Parameters.Add(new SqlParameter("@PageTitle", data.PageTitle));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@ModifiedDate", data.ModifiedDate));
				dbCmd.Parameters.Add(new SqlParameter("@IsApply", data.IsApply));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Config");
			return true;
		}
		#endregion
		#region[Config_Update]
		public bool Config_Update(Config data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@SendGmail", data.SendGmail));
				dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
				dbCmd.Parameters.Add(new SqlParameter("@ReceiveGmail", data.ReceiveGmail));
				dbCmd.Parameters.Add(new SqlParameter("@Banner", data.Banner));
				dbCmd.Parameters.Add(new SqlParameter("@Footer", data.Footer));
				dbCmd.Parameters.Add(new SqlParameter("@PageTitle", data.PageTitle));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@ModifiedDate", data.ModifiedDate));
				dbCmd.Parameters.Add(new SqlParameter("@IsApply", data.IsApply));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Config");
			return true;
		}
		#endregion
		#region[Config_Delete]
		public bool Config_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Config_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Config");
			return true;
		}
		#endregion
		
	}
}