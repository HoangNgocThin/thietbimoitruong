using System;
        #region[User_Validate]
        public static List<User> User_Validate(string UserName, string Password)
        {
            List<User> list = new List<User>();
            list = db.User_GetByAll();
            return list.FindAll(delegate(User obj)
            {
                return obj.Username == UserName && obj.Password == Password;
            });
        }
        #endregion
        #region[User_Paging]
        public static List<Data.User> User_Paging(string CurentPage, string PageSize)