using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListCountryRepo : DbConnection, IListCountryRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListCountryRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListCountryRepo()
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

        public List<ListCountryModel> Find()
        {
            ListCountryModel Country = null;
            List<ListCountryModel> ListCountry = new List<ListCountryModel>();
            UserAccountsRepo user = new UserAccountsRepo();
            ListCurrencyRepo currency = new ListCurrencyRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindCountry";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Country = new ListCountryModel();
                        Country.CountryId = (int)dr["CountryId"];
                        Country.Country = dr["Country"].ToString();
                        Country.CurrencyId = (int)dr["CurrencyId"];
                        Country.Currency = currency.Find(Country.CurrencyId);
                        Country.CreatedByUserId = (int)dr["CreatedByUserId"];
                        Country.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        Country.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        Country.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        Country.CreatedByUser = user.Find(Country.CreatedByUserId);
                        Country.UpdatedByUser = user.Find(Country.UpdatedByUserId);
                        ListCountry.Add(Country);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListCountry;
        }

        public ListCountryModel Find(int pCountryId)
        {
            ListCountryModel Country = null;
            UserAccountsRepo user = new UserAccountsRepo();
            ListCurrencyRepo currency = new ListCurrencyRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindCountryById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCountryId", pCountryId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    Country = new ListCountryModel();
                    Country.CountryId = (int)dr["CountryId"];
                    Country.Country = dr["Country"].ToString();
                    Country.CurrencyId = (int)dr["CurrencyId"];
                    Country.Currency = currency.Find(Country.CurrencyId);
                    Country.CreatedByUserId = (int)dr["CreatedByUserId"];
                    Country.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    Country.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    Country.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    Country.CreatedByUser = user.Find(Country.CreatedByUserId);
                    Country.UpdatedByUser = user.Find(Country.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return Country;
        }
    }
}
