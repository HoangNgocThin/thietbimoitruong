using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class CapacityDAL : SqlDataProvider
	{
		#region[Capacity_GetById]
		public List<Capacity> Capacity_GetById(string Id)
		{
			List<Data.Capacity> list = new List<Data.Capacity>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_GetById", GetConnection()))
			{
				Data.Capacity obj = new Data.Capacity();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.CapacityIDataReader(dr));
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
		#region[Capacity_GetByTop]
		public List<Capacity> Capacity_GetByTop(string Top, string Where, string Order)
		{
			List<Data.Capacity> list = new List<Data.Capacity>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_GetByTop", GetConnection()))
			{
				Data.Capacity obj = new Data.Capacity();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.CapacityIDataReader(dr));
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
		#region[Capacity_GetByAll]
		public List<Capacity> Capacity_GetByAll()
		{
			List<Data.Capacity> list = new List<Data.Capacity>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_GetByAll", GetConnection()))
			{
				Data.Capacity obj = new Data.Capacity();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.CapacityIDataReader(dr));
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
		#region[Capacity_Paging]
		public List<Capacity> Capacity_Paging(string CurentPage, string PageSize)
		{
			List<Data.Capacity> list = new List<Data.Capacity>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_Paging", GetConnection()))
			{
				Data.Capacity obj = new Data.Capacity();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.CapacityIDataReader(dr));
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
		#region[Capacity_Insert]
		public bool Capacity_Insert(Capacity data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@CreatedDate", data.CreatedDate));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Capacity");
			return true;
		}
		#endregion
		#region[Capacity_Update]
		public bool Capacity_Update(Capacity data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@CreatedDate", data.CreatedDate));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Capacity");
			return true;
		}
		#endregion
		#region[Capacity_Delete]
		public bool Capacity_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Capacity_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Capacity");
			return true;
		}
		#endregion
		
	}
}