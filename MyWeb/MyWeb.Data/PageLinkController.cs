using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class PageLinkDAL : SqlDataProvider
	{
		#region[PageLink_GetById]
		public List<PageLink> PageLink_GetById(string Id)
		{
			List<Data.PageLink> list = new List<Data.PageLink>();
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_GetById", GetConnection()))
			{
				Data.PageLink obj = new Data.PageLink();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.PageLinkIDataReader(dr));
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
		#region[PageLink_GetByTop]
		public List<PageLink> PageLink_GetByTop(string Top, string Where, string Order)
		{
			List<Data.PageLink> list = new List<Data.PageLink>();
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_GetByTop", GetConnection()))
			{
				Data.PageLink obj = new Data.PageLink();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.PageLinkIDataReader(dr));
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
		#region[PageLink_GetByAll]
		public List<PageLink> PageLink_GetByAll()
		{
			List<Data.PageLink> list = new List<Data.PageLink>();
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_GetByAll", GetConnection()))
			{
				Data.PageLink obj = new Data.PageLink();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.PageLinkIDataReader(dr));
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
		#region[PageLink_Paging]
		public List<PageLink> PageLink_Paging(string CurentPage, string PageSize)
		{
			List<Data.PageLink> list = new List<Data.PageLink>();
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_Paging", GetConnection()))
			{
				Data.PageLink obj = new Data.PageLink();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.PageLinkIDataReader(dr));
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
		#region[PageLink_Insert]
		public bool PageLink_Insert(PageLink data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
				dbCmd.Parameters.Add(new SqlParameter("@Type", data.Type));
				dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
				dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
				dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("PageLink");
			return true;
		}
		#endregion
		#region[PageLink_Update]
		public bool PageLink_Update(PageLink data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
				dbCmd.Parameters.Add(new SqlParameter("@Type", data.Type));
				dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
				dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
				dbCmd.Parameters.Add(new SqlParameter("@Index", data.Index));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("PageLink");
			return true;
		}
		#endregion
		#region[PageLink_Delete]
		public bool PageLink_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("PageLink");
			return true;
		}
		#endregion
        #region[Page_GetByLevel]
        public List<PageLink> PageLink_GetByLevel(string Level, int LevelLength)
        {


            List<Data.PageLink> list = new List<Data.PageLink>();
            using (SqlCommand dbCmd = new SqlCommand("sp_PageLink_GetByLevel", GetConnection()))
            {
                Data.PageLink obj = new Data.PageLink();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Level", Level));
                dbCmd.Parameters.Add(new SqlParameter("@LevelLength", LevelLength));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.PageLinkIDataReader(dr));
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
	}
}