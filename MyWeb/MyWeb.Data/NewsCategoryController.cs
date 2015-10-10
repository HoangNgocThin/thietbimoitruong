using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class NewsCategoryDAL : SqlDataProvider
	{
		#region[NewsCategory_GetById]
		public List<NewsCategory> NewsCategory_GetById(string Id)
		{
			List<Data.NewsCategory> list = new List<Data.NewsCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_GetById", GetConnection()))
			{
				Data.NewsCategory obj = new Data.NewsCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.NewsCategoryIDataReader(dr));
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
		#region[NewsCategory_GetByTop]
		public List<NewsCategory> NewsCategory_GetByTop(string Top, string Where, string Order)
		{
			List<Data.NewsCategory> list = new List<Data.NewsCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_GetByTop", GetConnection()))
			{
				Data.NewsCategory obj = new Data.NewsCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.NewsCategoryIDataReader(dr));
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
		#region[NewsCategory_GetByAll]
		public List<NewsCategory> NewsCategory_GetByAll()
		{
			List<Data.NewsCategory> list = new List<Data.NewsCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_GetByAll", GetConnection()))
			{
				Data.NewsCategory obj = new Data.NewsCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.NewsCategoryIDataReader(dr));
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
		#region[NewsCategory_Paging]
		public List<NewsCategory> NewsCategory_Paging(string CurentPage, string PageSize)
		{
			List<Data.NewsCategory> list = new List<Data.NewsCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_Paging", GetConnection()))
			{
				Data.NewsCategory obj = new Data.NewsCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.NewsCategoryIDataReader(dr));
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
		#region[NewsCategory_Insert]
		public bool NewsCategory_Insert(NewsCategory data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("NewsCategory");
			return true;
		}
		#endregion
		#region[NewsCategory_Update]
		public bool NewsCategory_Update(NewsCategory data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("NewsCategory");
			return true;
		}
		#endregion
		#region[NewsCategory_Delete]
		public bool NewsCategory_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_NewsCategory_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("NewsCategory");
			return true;
		}
		#endregion
		
	}
}