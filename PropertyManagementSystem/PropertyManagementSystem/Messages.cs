using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PropertyManagementSystem
{
    public static class Messages
    {
        public static int Number;
        public static string Message;

        public static string Find(int Number)
        {
            string msg;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlDbCS"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spFindMessageByNumber";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pNumber", Number);

                    conn.Open();
                    msg = cmd.ExecuteScalar().ToString();

                    conn.Close();
                }
            }
            return msg;
        }
    }
}
