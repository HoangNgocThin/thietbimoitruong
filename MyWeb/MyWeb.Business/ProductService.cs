using System;

        #region[Product_Paging_Where]
        public static List<Data.Product> Product_Paging_Where(string CurentPage, string PageSize, string where)
        {
            return db.Product_Paging_Where(CurentPage, PageSize,where);
        }
        #endregion