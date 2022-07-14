using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public class PagesRepo : DbConnection, IPagesRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public PagesRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~PagesRepo()
        {
            DBConnectionClose();
        }

        private void DbConnectionOpen()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        private void DBConnectionClose()
        {
            cmd.Dispose();
            cmd = null;

            conn.Close();
            conn.Dispose();
            conn = null;

        }

        public List<PagesModel> Find()
        {
            PagesModel page = null;
            List<PagesModel> ListPages = new List<PagesModel>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        page = new PagesModel();
                        page.PageId = (int)dr["PageId"];
                        page.PageName = dr["PageName"].ToString();
                        ListPages.Add(page);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListPages;
        }
        public PagesModel Find(int pPageId)
        {
            PagesModel page = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPageByPageId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pPageId", pPageId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    page = new PagesModel();
                    page.PageId = (int)dr["PageId"];
                    page.PageName = dr["PageName"].ToString();
                }

                dr.Close();
                dr = null;
            }
            return page;
        }
    }
}
