using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class ProductCategoryDAL : SqlDataProvider
	{
		#region[ProductCategory_GetById]
		public List<ProductCategory> ProductCategory_GetById(string Id)
		{
			List<Data.ProductCategory> list = new List<Data.ProductCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_GetById", GetConnection()))
			{
				Data.ProductCategory obj = new Data.ProductCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductCategoryIDataReader(dr));
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
		#region[ProductCategory_GetByTop]
		public List<ProductCategory> ProductCategory_GetByTop(string Top, string Where, string Order)
		{
			List<Data.ProductCategory> list = new List<Data.ProductCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_GetByTop", GetConnection()))
			{
				Data.ProductCategory obj = new Data.ProductCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
				dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
				dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductCategoryIDataReader(dr));
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
		#region[ProductCategory_GetByAll]
		public List<ProductCategory> ProductCategory_GetByAll()
		{
			List<Data.ProductCategory> list = new List<Data.ProductCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_GetByAll", GetConnection()))
			{
				Data.ProductCategory obj = new Data.ProductCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductCategoryIDataReader(dr));
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
		#region[ProductCategory_Paging]
		public List<ProductCategory> ProductCategory_Paging(string CurentPage, string PageSize)
		{
			List<Data.ProductCategory> list = new List<Data.ProductCategory>();
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_Paging", GetConnection()))
			{
				Data.ProductCategory obj = new Data.ProductCategory();
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
				dbCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize));
				SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductCategoryIDataReader(dr));
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
		#region[ProductCategory_Insert]
		public bool ProductCategory_Insert(ProductCategory data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_Insert", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.Parameters.Add(new SqlParameter("@IsDisplayInHome", data.IsDisplayInHome));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("ProductCategory");
			return true;
		}
		#endregion
		#region[ProductCategory_Update]
		public bool ProductCategory_Update(ProductCategory data)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_Update", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", data.ID));
				dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
				dbCmd.Parameters.Add(new SqlParameter("@Title", data.Title));
				dbCmd.Parameters.Add(new SqlParameter("@Tag", data.Tag));
				dbCmd.Parameters.Add(new SqlParameter("@Level", data.Level));
				dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
				dbCmd.Parameters.Add(new SqlParameter("@Description", data.Description));
				dbCmd.Parameters.Add(new SqlParameter("@MetaKeyword", data.MetaKeyword));
				dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.Parameters.Add(new SqlParameter("@IsDisplayInHome", data.IsDisplayInHome));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("ProductCategory");
			return true;
		}
		#endregion
		#region[ProductCategory_Delete]
		public bool ProductCategory_Delete(string Id)
		{
			using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_Delete", GetConnection()))
			{
				dbCmd.CommandType = CommandType.StoredProcedure;
				dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
				dbCmd.ExecuteNonQuery();
			}
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("ProductCategory");
			return true;
		}
		#endregion
        #region[ProductCategory_GetByLevel]
        public List<ProductCategory> ProductCategory_GetByLevel(string Level, int LevelLength)
        {


            List<Data.ProductCategory> list = new List<Data.ProductCategory>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ProductCategory_GetByLevel", GetConnection()))
            {
                Data.ProductCategory obj = new Data.ProductCategory();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Level", Level));
                dbCmd.Parameters.Add(new SqlParameter("@LevelLength", LevelLength));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ProductCategoryIDataReader(dr));
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