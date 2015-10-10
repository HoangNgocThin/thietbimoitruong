using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class AdvertiseDAL : SqlDataProvider
	{
		#region[Advertise_GetById]
		public List<Advertise> Advertise_GetById(string Id)
		{
			List<Data.Advertise> list = new List<Data.Advertise>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetById", GetConnection()))
			{
				Data.Advertise obj = new Data.Advertise();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.AdvertiseIDataReader(dr));
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
		#region[Advertise_GetByTop]
		public List<Advertise> Advertise_GetByTop(string Top, string Where, string Order)
		{
			List<Data.Advertise> list = new List<Data.Advertise>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByTop", GetConnection()))
			{
				Data.Advertise obj = new Data.Advertise();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.AdvertiseIDataReader(dr));
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
		#region[Advertise_GetByAll]
		public List<Advertise> Advertise_GetByAll()
		{
			List<Data.Advertise> list = new List<Data.Advertise>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByAll", GetConnection()))
			{
				Data.Advertise obj = new Data.Advertise();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.AdvertiseIDataReader(dr));
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
		#region[Advertise_Paging]
		public List<Advertise> Advertise_Paging(string CurentPage, string PageSize)
		{
			List<Data.Advertise> list = new List<Data.Advertise>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Paging", GetConnection()))
			{
				Data.Advertise obj = new Data.Advertise();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.AdvertiseIDataReader(dr));
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
		#region[Advertise_Insert]
		public bool Advertise_Insert(Advertise data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
				dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
				dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
				dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
				dbCmd.Parameters.Add(new SqlParameter("@PageLinkId", data.PageLinkId == "" || data.PageLinkId == "0" ? DBNull.Value : (object)data.PageLinkId));
				dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Advertise");
			return true;
		}
		#endregion
		#region[Advertise_Update]
		public bool Advertise_Update(Advertise data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
				dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
				dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
				dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
				dbCmd.Parameters.Add(new SqlParameter("@PageLinkId", data.PageLinkId == "" || data.PageLinkId == "0" ? DBNull.Value : (object)data.PageLinkId));
				dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Advertise");
			return true;
		}
		#endregion
		#region[Advertise_Delete]
		public bool Advertise_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Advertise");
			return true;
		}
		#endregion
		
	}
}