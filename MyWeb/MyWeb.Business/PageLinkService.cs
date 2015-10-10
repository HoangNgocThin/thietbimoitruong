using System;using System.Collections.Generic;using System.Text;using MyWeb.Data;namespace MyWeb.Business{	public class PageLinkService	{		private static PageLinkDAL db = new PageLinkDAL();		#region[PageLink_GetById]		public static List<Data.PageLink> PageLink_GetById(string Id)		{			return db.PageLink_GetById(Id);		}		#endregion		#region[PageLink_GetByTop]		public static List<Data.PageLink> PageLink_GetByTop(string Top, string Where, string Order)		{			return db.PageLink_GetByTop(Top, Where, Order);		}		#endregion		#region[PageLink_GetByAll]		public static List<Data.PageLink> PageLink_GetByAll()		{			return db.PageLink_GetByAll();		}		#endregion		#region[PageLink_Paging]		public static List<Data.PageLink> PageLink_Paging(string CurentPage, string PageSize)		{			return db.PageLink_Paging(CurentPage, PageSize);		}		#endregion		#region[PageLink_Insert]		public static bool PageLink_Insert(PageLink data)		{			return db.PageLink_Insert(data);		}		#endregion		#region[PageLink_Update]		public static bool PageLink_Update(PageLink data)		{			return db.PageLink_Update(data);		}		#endregion		#region[PageLink_Delete]		public static bool PageLink_Delete(string Id)		{			return db.PageLink_Delete(Id);		}		#endregion
        #region[Page_GetByPosition]
        public static List<PageLink> Page_GetByPosition(string position)
        {
            return PageLink_GetByPosition(position, 0);
        }
        public static List<PageLink> PageLink_GetByPosition(string position, int LevelLength)
        {
            List<PageLink> list = new List<PageLink>();
            list = db.PageLink_GetByAll();
            return list.FindAll(delegate(PageLink obj)
            {
                if (LevelLength > 0)
                {
                    return obj.Active.Equals("1") && obj.Position == position && obj.Level.Length == LevelLength;
                }
                else
                {
                    return obj.Active.Equals("1") && obj.Position == position;
                }
            });
        }
        #endregion
        #region[PageLink_ExistByLevel]
        public static bool PageLink_ExistByLevel(string Level)
        {
            List<Data.PageLink> list = PageLink_GetByLevel(Level);
            bool strReturn = list.Count > 0 ? true : false;
            return strReturn;
        }
        public static bool PageLink_ExistByLevel(string Level, string Active)
        {
            List<Data.PageLink> list = PageLink_GetByLevel(Level, 1, Active);
            bool strReturn = list.Count > 0 ? true : false;
            return strReturn;
        }
        #endregion
        #region[Page_GetByLevel]
        public static List<Data.PageLink> PageLink_GetByLevel(string Level)
        {
            return PageLink_GetByLevel(Level, 0);
        }
        public static List<Data.PageLink> PageLink_GetByLevel(string Level,string Active)
        {
            List<Data.PageLink> list = new List<Data.PageLink>();
            list = PageLink_GetByLevel(Level);
            return list.FindAll(delegate(PageLink obj)
            {
                return obj.Active == Active;
            });
        }
        public static List<Data.PageLink> PageLink_GetByLevel(string Level, int LevelLength)
        {
            return db.PageLink_GetByLevel(Level, LevelLength);
        }
        public static List<Data.PageLink> PageLink_GetByLevel(string Level, int LevelLength, string Active)
        {
            List<Data.PageLink> list = new List<Data.PageLink>();
            list = PageLink_GetByLevel(Level, LevelLength);
            return list.FindAll(delegate(PageLink obj)
            {
                return obj.Active == Active;
            });
        }
        #endregion	}}