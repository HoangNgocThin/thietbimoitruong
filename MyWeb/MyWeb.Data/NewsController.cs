using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class NewsDAL : SqlDataProvider
	{
		#region[News_GetById]
		public List<News> News_GetById(string Id)
		{
			List<Data.News> list = new List<Data.News>();
			using (SqlCommand dbCmd = new SqlCommand("sp_News_GetById", GetConnection()))
			{
				Data.News obj = new Data.News();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.NewsIDataReader(dr));
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
		#region[News_GetByTop]
		public List<News> News_GetByTop(string Top, string Where, string Order)
		{
			List<Data.News> list = new List<Data.News>();
			using (SqlCommand dbCmd = new SqlCommand("sp_News_GetByTop", GetConnection()))
			{
				Data.News obj = new Data.News();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.NewsIDataReader(dr));
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
		#region[News_GetByAll]
		public List<News> News_GetByAll()
		{
			List<Data.News> list = new List<Data.News>();
			using (SqlCommand dbCmd = new SqlCommand("sp_News_GetByAll", GetConnection()))
			{
				Data.News obj = new Data.News();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.NewsIDataReader(dr));
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
		#region[News_Paging]
		public List<News> News_Paging(string CurentPage, string PageSize)
		{
			List<Data.News> list = new List<Data.News>();
			using (SqlCommand dbCmd = new SqlCommand("sp_News_Paging", GetConnection()))
			{
				Data.News obj = new Data.News();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.NewsIDataReader(dr));
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
		#region[News_Insert]
		public bool News_Insert(News data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_News_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@PostedDate", data.PostedDate));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
				dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
				dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@NewsCategoryID", data.NewsCategoryID == "" || data.NewsCategoryID == "0" ? DBNull.Value : (object)data.NewsCategoryID));
				dbCmd.Parameters.Add(new SqlParameter("@IsHotNews", data.IsHotNews));
                dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("News");
			return true;
		}
		#endregion
		#region[News_Update]
		public bool News_Update(News data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_News_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@PostedDate", data.PostedDate));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
				dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
				dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@NewsCategoryID", data.NewsCategoryID == "" || data.NewsCategoryID == "0" ? DBNull.Value : (object)data.NewsCategoryID));
				dbCmd.Parameters.Add(new SqlParameter("@IsHotNews", data.IsHotNews));
                dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("News");
			return true;
		}
		#endregion
		#region[News_Delete]
		public bool News_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_News_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("News");
			return true;
		}
		#endregion
		
	}
}