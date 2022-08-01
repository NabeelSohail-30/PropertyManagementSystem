using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListRentPeriodRepo : DbConnection, IListRentPeriodRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListRentPeriodRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListRentPeriodRepo()
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

        public List<ListRentPeriodModel> Find()
        {
            ListRentPeriodModel RentPeriod = null;
            List<ListRentPeriodModel> ListRentPeriod = new List<ListRentPeriodModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindRentPeriod";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RentPeriod = new ListRentPeriodModel();
                        RentPeriod.RentPeriodId = (int)dr["RentPeriodId"];
                        RentPeriod.RentPeriod = dr["RentPeriod"].ToString();
                        RentPeriod.CreatedByUserId = (int)dr["CreatedByUserId"];
                        RentPeriod.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        RentPeriod.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        RentPeriod.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        RentPeriod.CreatedByUser = user.Find(RentPeriod.CreatedByUserId);
                        RentPeriod.UpdatedByUser = user.Find(RentPeriod.UpdatedByUserId);
                        ListRentPeriod.Add(RentPeriod);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListRentPeriod;
        }

        public ListRentPeriodModel Find(int pRentPeriodId)
        {
            ListRentPeriodModel RentPeriod = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindRentPeriodById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pRentPeriodId", pRentPeriodId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    RentPeriod = new ListRentPeriodModel();
                    RentPeriod.RentPeriodId = (int)dr["RentPeriodId"];
                    RentPeriod.RentPeriod = dr["RentPeriod"].ToString();
                    RentPeriod.CreatedByUserId = (int)dr["CreatedByUserId"];
                    RentPeriod.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    RentPeriod.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    RentPeriod.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    RentPeriod.CreatedByUser = user.Find(RentPeriod.CreatedByUserId);
                    RentPeriod.UpdatedByUser = user.Find(RentPeriod.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return RentPeriod;
        }
    }
}
