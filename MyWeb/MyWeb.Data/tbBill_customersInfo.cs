using System;
        private string _CustomerName;
        private string _BirthDate;
        private string _Mobile;
        private string _Address;
        private string _Email;
		#endregion
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }
        public string Mobile { get { return _Mobile; } set { _Mobile = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
            obj.CustomerName = (dr["CustomerName"] is DBNull) ? string.Empty : dr["CustomerName"].ToString();
            obj.BirthDate = (dr["BirthDate"] is DBNull) ? string.Empty : dr["BirthDate"].ToString();
            obj.Mobile = (dr["Mobile"] is DBNull) ? string.Empty : dr["Mobile"].ToString();
            obj.Address = (dr["Address"] is DBNull) ? string.Empty : dr["Address"].ToString();
            obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();