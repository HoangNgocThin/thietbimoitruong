using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyWeb.Data
{
    public class DataAccess
    {
        static string strConStr = "";
        
        public DataAccess(string constr)
        {
         strConStr = constr;
        }
        static SqlDataReader datareader;
        #region DB Access Functions
        public string ConnectingString
        {
            get
            {
                if (!strConStr.Equals(""))
                    return strConStr;
                else
                    return null;
            }
            set
            {
                strConStr = value;
            }
        }
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(strConStr);
            con.Open();
            return con;
        }

        public DataTable GetData(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection != null)
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }
            finally
            {

            }
        }

        /// <summary>
        /// Get DataReader Data
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public SqlDataReader GetReadOnlyData(SqlCommand cmd)
        {
            try
            {

                if (cmd.Connection != null)
                {
                    return cmd.ExecuteReader();
                }
                else
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        cmd.Connection = conn;
                        datareader = cmd.ExecuteReader();
                        return cmd.ExecuteReader();
                    }
                }
            }
            finally
            {

            }
        }



        public DataSet GetDsData(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection != null)
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                                return ds;
                            }
                        }
                    }
                }
            }
            finally { }
        }

        public DataTable GetData(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        using (DataSet ds = new DataSet())
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }
            finally
            {

            }
        }
        public void ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {

            }
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    return cmd.ExecuteScalar();
                }
            }
            finally
            {

            }
        }
        public int DBSize()
        {
            using (SqlCommand cmd = new SqlCommand("select sum(size) * 8 * 1024 from sysfiles"))
            {
                cmd.CommandType = CommandType.Text;
                return (int)ExecuteScalar(cmd);
            }
        }

        public bool CheckConnect()
        {
            SqlCommand cmd = new SqlCommand("select getdate()");
            if (GetData(cmd).Rows.Count > 0)
                return true;
            return false;
        }
        #endregion
    }

    
}
