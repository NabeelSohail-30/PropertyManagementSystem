using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListAgreementTypeRepo : DbConnection, IListAgreementTypeRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListAgreementTypeRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListAgreementTypeRepo()
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

        public List<ListAgreementTypeModel> Find()
        {
            ListAgreementTypeModel AgreementType = null;
            List<ListAgreementTypeModel> ListAgreementType = new List<ListAgreementTypeModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindListAgreementType";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        AgreementType = new ListAgreementTypeModel();
                        AgreementType.AgreementTypeId = (int)dr["AgreementTypeId"];
                        AgreementType.AgreementType = dr["AgreementType"].ToString();
                        AgreementType.CreatedByUserId = (int)dr["CreatedByUserId"];
                        AgreementType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        AgreementType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        AgreementType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        AgreementType.CreatedByUser = user.Find(AgreementType.CreatedByUserId);
                        AgreementType.UpdatedByUser = user.Find(AgreementType.UpdatedByUserId);
                        ListAgreementType.Add(AgreementType);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListAgreementType;
        }

        public ListAgreementTypeModel Find(int AgreementTypeId)
        {
            ListAgreementTypeModel AgreementType = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindListAgreementTypeById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pAgreementTypeId", AgreementTypeId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    AgreementType = new ListAgreementTypeModel();
                    AgreementType.AgreementTypeId = (int)dr["AgreementTypeId"];
                    AgreementType.AgreementType = dr["AgreementType"].ToString();
                    AgreementType.CreatedByUserId = (int)dr["CreatedByUserId"];
                    AgreementType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    AgreementType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    AgreementType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    AgreementType.CreatedByUser = user.Find(AgreementType.CreatedByUserId);
                    AgreementType.UpdatedByUser = user.Find(AgreementType.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return AgreementType;
        }
    }
}
