using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class ProductDAL : SqlDataProvider
	{
		#region[Product_GetById]
		public List<Product> Product_GetById(string Id)
		{
			List<Data.Product> list = new List<Data.Product>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetById", GetConnection()))
			{
				Data.Product obj = new Data.Product();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ProductIDataReader(dr));
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
		#region[Product_GetByTop]
		public List<Product> Product_GetByTop(string Top, string Where, string Order)
		{
			List<Data.Product> list = new List<Data.Product>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetByTop", GetConnection()))
			{
				Data.Product obj = new Data.Product();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ProductIDataReader(dr));
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
		#region[Product_GetByAll]
		public List<Product> Product_GetByAll()
		{
			List<Data.Product> list = new List<Data.Product>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetByAll", GetConnection()))
			{
				Data.Product obj = new Data.Product();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ProductIDataReader(dr));
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
		#region[Product_Paging]
		public List<Product> Product_Paging(string CurentPage, string PageSize)
		{
			List<Data.Product> list = new List<Data.Product>();
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Paging", GetConnection()))
			{
				Data.Product obj = new Data.Product();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						list.Add(obj.ProductIDataReader(dr));
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

        #region[Product_Paging_Where]
        public List<Product> Product_Paging_Where(string CurentPage, string PageSize, string where)
        {
            List<Data.Product> list = new List<Data.Product>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Product_Paging_Where", GetConnection()))
            {
                Data.Product obj = new Data.Product();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
                dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
                dbCmd.Parameters.Add(new SqlParameter("@Where", where));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductIDataReader(dr));
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
		#region[Product_Insert]
		public bool Product_Insert(Product data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Decription", data.Decription));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@SalePrice", data.SalePrice));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@ProductCategoryID", data.ProductCategoryID == "" || data.ProductCategoryID == "0" ? DBNull.Value : (object)data.ProductCategoryID));
				dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
				dbCmd.Parameters.Add(new SqlParameter("@Image1", data.Image1));
				dbCmd.Parameters.Add(new SqlParameter("@Image2", data.Image2));
				dbCmd.Parameters.Add(new SqlParameter("@Image3", data.Image3));
				dbCmd.Parameters.Add(new SqlParameter("@Image4", data.Image4));
				dbCmd.Parameters.Add(new SqlParameter("@Image5", data.Image5));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@CapacityID", data.CapacityID == "" || data.CapacityID == "0" ? DBNull.Value : (object)data.CapacityID));
				dbCmd.Parameters.Add(new SqlParameter("@BranchID", data.BranchID == "" || data.BranchID == "0" ? DBNull.Value : (object)data.BranchID));
				dbCmd.Parameters.Add(new SqlParameter("@ProductCode", data.ProductCode));
				dbCmd.Parameters.Add(new SqlParameter("@UnitPrice", data.UnitPrice));
                dbCmd.Parameters.Add(new SqlParameter("@Unit", data.Unit));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		#region[Product_Update]
		public bool Product_Update(Product data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", data.ID));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Content", data.Content));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Decription", data.Decription));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
				dbCmd.Parameters.Add(new SqlParameter("@SalePrice", data.SalePrice));
				dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
				dbCmd.Parameters.Add(new SqlParameter("@ProductCategoryID", data.ProductCategoryID == "" || data.ProductCategoryID == "0" ? DBNull.Value : (object)data.ProductCategoryID));
				dbCmd.Parameters.Add(new SqlParameter("@Priority", data.Priority));
				dbCmd.Parameters.Add(new SqlParameter("@Image1", data.Image1));
				dbCmd.Parameters.Add(new SqlParameter("@Image2", data.Image2));
				dbCmd.Parameters.Add(new SqlParameter("@Image3", data.Image3));
				dbCmd.Parameters.Add(new SqlParameter("@Image4", data.Image4));
				dbCmd.Parameters.Add(new SqlParameter("@Image5", data.Image5));
				dbCmd.Parameters.Add(new SqlParameter("@Detail", data.Detail));
				dbCmd.Parameters.Add(new SqlParameter("@CapacityID", data.CapacityID == "" || data.CapacityID == "0" ? DBNull.Value : (object)data.CapacityID));
				dbCmd.Parameters.Add(new SqlParameter("@BranchID", data.BranchID == "" || data.BranchID == "0" ? DBNull.Value : (object)data.BranchID));
				dbCmd.Parameters.Add(new SqlParameter("@ProductCode", data.ProductCode));
				dbCmd.Parameters.Add(new SqlParameter("@UnitPrice", data.UnitPrice));
                dbCmd.Parameters.Add(new SqlParameter("@Unit", data.Unit));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		#region[Product_Delete]
		public bool Product_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_Product_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Product");
			return true;
		}
		#endregion
		
	}
}