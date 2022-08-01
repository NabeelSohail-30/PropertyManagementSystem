using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListPaymentMethodTypeRepo : DbConnection, IListPaymentMethodTypeRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListPaymentMethodTypeRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListPaymentMethodTypeRepo()
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

        public List<ListPaymentMethodTypeModel> Find()
        {
            ListPaymentMethodTypeModel PaymentMethodType = null;
            List<ListPaymentMethodTypeModel> ListPaymentMethodType = new List<ListPaymentMethodTypeModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPaymentMethodType";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PaymentMethodType = new ListPaymentMethodTypeModel();
                        PaymentMethodType.PaymentMethodTypeId = (int)dr["PaymentMethodTypeId"];
                        PaymentMethodType.PaymentMethodType = dr["PaymentMethodType"].ToString();
                        PaymentMethodType.CreatedByUserId = (int)dr["CreatedByUserId"];
                        PaymentMethodType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        PaymentMethodType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        PaymentMethodType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        PaymentMethodType.CreatedByUser = user.Find(PaymentMethodType.CreatedByUserId);
                        PaymentMethodType.UpdatedByUser = user.Find(PaymentMethodType.UpdatedByUserId);
                        ListPaymentMethodType.Add(PaymentMethodType);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListPaymentMethodType;
        }

        public ListPaymentMethodTypeModel Find(int pPaymentMethodTypeId)
        {
            ListPaymentMethodTypeModel PaymentMethodType = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPaymentMethodTypeById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pPaymentMethodTypeId", pPaymentMethodTypeId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    PaymentMethodType = new ListPaymentMethodTypeModel();
                    PaymentMethodType.PaymentMethodTypeId = (int)dr["PaymentMethodTypeId"];
                    PaymentMethodType.PaymentMethodType = dr["PaymentMethodType"].ToString();
                    PaymentMethodType.CreatedByUserId = (int)dr["CreatedByUserId"];
                    PaymentMethodType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    PaymentMethodType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    PaymentMethodType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    PaymentMethodType.CreatedByUser = user.Find(PaymentMethodType.CreatedByUserId);
                    PaymentMethodType.UpdatedByUser = user.Find(PaymentMethodType.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return PaymentMethodType;
        }
    }
}
