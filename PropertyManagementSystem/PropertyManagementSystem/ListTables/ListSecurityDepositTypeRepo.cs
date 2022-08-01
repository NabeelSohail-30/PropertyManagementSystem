using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListSecurityDepositTypeRepo : DbConnection, IListSecurityDepositTypeRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListSecurityDepositTypeRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListSecurityDepositTypeRepo()
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

        public List<ListSecurityDepositTypeModel> Find()
        {
            ListSecurityDepositTypeModel SecurityDepositType = null;
            List<ListSecurityDepositTypeModel> ListSecurityDepositType = new List<ListSecurityDepositTypeModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindSecurityDepositType";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SecurityDepositType = new ListSecurityDepositTypeModel();
                        SecurityDepositType.SecurityDepositTypeId = (int)dr["SecurityDepositTypeId"];
                        SecurityDepositType.SecurityDepositType = dr["SecurityDepositType"].ToString();
                        SecurityDepositType.CreatedByUserId = (int)dr["CreatedByUserId"];
                        SecurityDepositType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        SecurityDepositType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        SecurityDepositType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        SecurityDepositType.CreatedByUser = user.Find(SecurityDepositType.CreatedByUserId);
                        SecurityDepositType.UpdatedByUser = user.Find(SecurityDepositType.UpdatedByUserId);
                        ListSecurityDepositType.Add(SecurityDepositType);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListSecurityDepositType;
        }

        public ListSecurityDepositTypeModel Find(int pSecurityDepositTypeId)
        {
            ListSecurityDepositTypeModel SecurityDepositType = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindSecurityDepositTypeById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pSecurityDepositTypeId", pSecurityDepositTypeId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    SecurityDepositType = new ListSecurityDepositTypeModel();
                    SecurityDepositType.SecurityDepositTypeId = (int)dr["SecurityDepositTypeId"];
                    SecurityDepositType.SecurityDepositType = dr["SecurityDepositType"].ToString();
                    SecurityDepositType.CreatedByUserId = (int)dr["CreatedByUserId"];
                    SecurityDepositType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    SecurityDepositType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    SecurityDepositType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    SecurityDepositType.CreatedByUser = user.Find(SecurityDepositType.CreatedByUserId);
                    SecurityDepositType.UpdatedByUser = user.Find(SecurityDepositType.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return SecurityDepositType;
        }
    }
}
