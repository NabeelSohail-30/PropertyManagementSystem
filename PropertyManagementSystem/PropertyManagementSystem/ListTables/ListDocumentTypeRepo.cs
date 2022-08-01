using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListDocumentTypeRepo : DbConnection, IListDocumentTypeRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListDocumentTypeRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListDocumentTypeRepo()
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
        public List<ListDocumentTypeModel> Find()
        {
            ListDocumentTypeModel DocumentType = null;
            List<ListDocumentTypeModel> ListDocumentType = new List<ListDocumentTypeModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindDocumentType";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DocumentType = new ListDocumentTypeModel();
                        DocumentType.DocumentTypeId = (int)dr["DocumentTypeId"];
                        DocumentType.DocumentType = dr["DocumentType"].ToString();
                        DocumentType.CreatedByUserId = (int)dr["CreatedByUserId"];
                        DocumentType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        DocumentType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        DocumentType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        DocumentType.CreatedByUser = user.Find(DocumentType.CreatedByUserId);
                        DocumentType.UpdatedByUser = user.Find(DocumentType.UpdatedByUserId);
                        ListDocumentType.Add(DocumentType);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListDocumentType;
        }

        public ListDocumentTypeModel Find(int pDocumentTypeId)
        {
            ListDocumentTypeModel DocumentType = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindDocumentTypeById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pDocumentTypeId", pDocumentTypeId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    DocumentType = new ListDocumentTypeModel();
                    DocumentType.DocumentTypeId = (int)dr["DocumentTypeId"];
                    DocumentType.DocumentType = dr["DocumentType"].ToString();
                    DocumentType.CreatedByUserId = (int)dr["CreatedByUserId"];
                    DocumentType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    DocumentType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    DocumentType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    DocumentType.CreatedByUser = user.Find(DocumentType.CreatedByUserId);
                    DocumentType.UpdatedByUser = user.Find(DocumentType.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return DocumentType;
        }
    }
}
