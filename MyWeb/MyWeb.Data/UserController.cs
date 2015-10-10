using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class UserDAL : SqlDataProvider
	{
		#region[User_GetById]
		public List<User> User_GetById(string Id)
		{
			List<Data.User> list = new List<Data.User>();
			using (SqlCommand dbCmd = new SqlCommand("sp_User_GetById", GetConnection()))
			{
				Data.User obj = new Data.User();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.UserIDataReader(dr));
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
		#region[User_GetByTop]
		public List<User> User_GetByTop(string Top, string Where, string Order)
		{
			List<Data.User> list = new List<Data.User>();
			using (SqlCommand dbCmd = new SqlCommand("sp_User_GetByTop", GetConnection()))
			{
				Data.User obj = new Data.User();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.UserIDataReader(dr));
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
		#region[User_GetByAll]
		public List<User> User_GetByAll()
		{
			List<Data.User> list = new List<Data.User>();
			using (SqlCommand dbCmd = new SqlCommand("sp_User_GetByAll", GetConnection()))
			{
				Data.User obj = new Data.User();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.UserIDataReader(dr));
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
		#region[User_Paging]
		public List<User> User_Paging(string CurentPage, string PageSize)
		{
			List<Data.User> list = new List<Data.User>();
			using (SqlCommand dbCmd = new SqlCommand("sp_User_Paging", GetConnection()))
			{
				Data.User obj = new Data.User();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.UserIDataReader(dr));
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
		#region[User_Insert]
		public bool User_Insert(User data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_User_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Username", data.Username));
				dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		#region[User_Update]
		public bool User_Update(User data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_User_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Username", data.Username));
				dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		#region[User_Delete]
		public bool User_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_User_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("User");
			return true;
		}
		#endregion
		
	}
}