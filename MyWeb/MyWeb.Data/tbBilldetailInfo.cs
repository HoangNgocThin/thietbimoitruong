using System;
        private string _ProductName;
        private string _Image;
        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
            obj.ProductName = (dr["ProductName"] is DBNull) ? string.Empty : dr["ProductName"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();