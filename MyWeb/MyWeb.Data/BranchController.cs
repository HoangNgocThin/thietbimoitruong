using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class BranchDAL : SqlDataProvider
	{
		#region[Branch_GetById]
		public List<Branch> Branch_GetById(string Id)
		{
			List<Data.Branch> list = new List<Data.Branch>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_GetById", GetConnection()))
			{
				Data.Branch obj = new Data.Branch();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.BranchIDataReader(dr));
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
		#region[Branch_GetByTop]
		public List<Branch> Branch_GetByTop(string Top, string Where, string Order)
		{
			List<Data.Branch> list = new List<Data.Branch>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_GetByTop", GetConnection()))
			{
				Data.Branch obj = new Data.Branch();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.BranchIDataReader(dr));
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
		#region[Branch_GetByAll]
		public List<Branch> Branch_GetByAll()
		{
			List<Data.Branch> list = new List<Data.Branch>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_GetByAll", GetConnection()))
			{
				Data.Branch obj = new Data.Branch();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.BranchIDataReader(dr));
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
		#region[Branch_Paging]
		public List<Branch> Branch_Paging(string CurentPage, string PageSize)
		{
			List<Data.Branch> list = new List<Data.Branch>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_Paging", GetConnection()))
			{
				Data.Branch obj = new Data.Branch();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.BranchIDataReader(dr));
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
		#region[Branch_Insert]
		public bool Branch_Insert(Branch data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Logo", data.Logo));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Branch");
			return true;
		}
		#endregion
		#region[Branch_Update]
		public bool Branch_Update(Branch data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Logo", data.Logo));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Branch");
			return true;
		}
		#endregion
		#region[Branch_Delete]
		public bool Branch_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Branch_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Branch");
			return true;
		}
		#endregion
		
	}
}