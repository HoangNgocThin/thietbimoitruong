using System;


        #region[Page_GetByPosition]
        public static List<ProductCategory> Page_GetByPosition(string position)
        {
            return ProductCategory_GetByPosition(position, 0);
        }
        public static List<ProductCategory> ProductCategory_GetByPosition(string position, int LevelLength)
        {
            List<ProductCategory> list = new List<ProductCategory>();
            list = db.ProductCategory_GetByAll();
            return list.FindAll(delegate(ProductCategory obj)
            {
                if (LevelLength > 0)
                {
                    return obj.Active.Equals("1") && obj.Level.Length == LevelLength;
                }
                else
                {
                    return obj.Active.Equals("1");
                }
            });
        }
        #endregion
        #region[ProductCategory_ExistByLevel]
        public static bool ProductCategory_ExistByLevel(string Level)
        {
            List<Data.ProductCategory> list = ProductCategory_GetByLevel(Level);
            bool strReturn = list.Count > 0 ? true : false;
            return strReturn;
        }
        public static bool ProductCategory_ExistByLevel(string Level, string Active)
        {
            List<Data.ProductCategory> list = ProductCategory_GetByLevel(Level, 1, Active);
            bool strReturn = list.Count > 0 ? true : false;
            return strReturn;
        }
        #endregion
        #region[Page_GetByLevel]
        public static List<Data.ProductCategory> ProductCategory_GetByLevel(string Level)
        {
            return ProductCategory_GetByLevel(Level, 0);
        }
        public static List<Data.ProductCategory> ProductCategory_GetByLevel(string Level, string Active)
        {
            List<Data.ProductCategory> list = new List<Data.ProductCategory>();
            list = ProductCategory_GetByLevel(Level);
            return list.FindAll(delegate(ProductCategory obj)
            {
                return obj.Active == Active;
            });
        }
        public static List<Data.ProductCategory> ProductCategory_GetByLevel(string Level, int LevelLength)
        {
            return db.ProductCategory_GetByLevel(Level, LevelLength);
        }
        public static List<Data.ProductCategory> ProductCategory_GetByLevel(string Level, int LevelLength, string Active)
        {
            List<Data.ProductCategory> list = new List<Data.ProductCategory>();
            list = ProductCategory_GetByLevel(Level, LevelLength);
            return list.FindAll(delegate(ProductCategory obj)
            {
                return obj.Active == Active;
            });
        }
        #endregion