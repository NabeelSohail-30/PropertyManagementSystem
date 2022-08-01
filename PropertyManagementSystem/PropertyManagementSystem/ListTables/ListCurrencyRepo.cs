using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListCurrencyRepo : DbConnection, IListCurrencyRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListCurrencyRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListCurrencyRepo()
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

        public List<ListCurrencyModel> Find()
        {
            ListCurrencyModel Currency = null;
            List<ListCurrencyModel> ListCurrency = new List<ListCurrencyModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindCurrency";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Currency = new ListCurrencyModel();
                        Currency.CurrencyId = (int)dr["CurrencyId"];
                        Currency.Currency = dr["Currency"].ToString();
                        Currency.Symbol = dr["Symbol"].ToString();
                        Currency.CreatedByUserId = (int)dr["CreatedByUserId"];
                        Currency.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        Currency.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        Currency.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        Currency.CreatedByUser = user.Find(Currency.CreatedByUserId);
                        Currency.UpdatedByUser = user.Find(Currency.UpdatedByUserId);
                        ListCurrency.Add(Currency);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListCurrency;
        }

        public ListCurrencyModel Find(int CurrencyId)
        {
            ListCurrencyModel Currency = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindCurrencyById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCurrencyId", CurrencyId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    Currency = new ListCurrencyModel();
                    Currency.CurrencyId = (int)dr["CurrencyId"];
                    Currency.Currency = dr["Currency"].ToString();
                    Currency.Symbol = dr["Symbol"].ToString();
                    Currency.CreatedByUserId = (int)dr["CreatedByUserId"];
                    Currency.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    Currency.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    Currency.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    Currency.CreatedByUser = user.Find(Currency.CreatedByUserId);
                    Currency.UpdatedByUser = user.Find(Currency.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return Currency;
        }
    }
}
