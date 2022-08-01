using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListPropertyTypeRepo : DbConnection, IListPropertyTypeRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public ListPropertyTypeRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~ListPropertyTypeRepo()
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

        public ListPropertyTypeModel Find(int pPropertyTypeId)
        {
            ListPropertyTypeModel PropertyType = null;
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPropertyTypeById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pPropertyTypeId", pPropertyTypeId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    PropertyType = new ListPropertyTypeModel();
                    PropertyType.PropertyTypeId = (int)dr["PropertyTypeId"];
                    PropertyType.PropertyType = dr["PropertyType"].ToString();
                    PropertyType.CreatedByUserId = (int)dr["CreatedByUserId"];
                    PropertyType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                    PropertyType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                    PropertyType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                    PropertyType.CreatedByUser = user.Find(PropertyType.CreatedByUserId);
                    PropertyType.UpdatedByUser = user.Find(PropertyType.UpdatedByUserId);
                }

                dr.Close();
                dr = null;
            }
            return PropertyType;
        }

        public List<ListPropertyTypeModel> Find()
        {
            ListPropertyTypeModel PropertyType = null;
            List<ListPropertyTypeModel> ListPropertyType = new List<ListPropertyTypeModel>();
            UserAccountsRepo user = new UserAccountsRepo();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindPropertyType";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PropertyType = new ListPropertyTypeModel();
                        PropertyType.PropertyTypeId = (int)dr["PropertyTypeId"];
                        PropertyType.PropertyType = dr["PropertyType"].ToString();
                        PropertyType.CreatedByUserId = (int)dr["CreatedByUserId"];
                        PropertyType.UpdatedByUserId = (int)dr["UpdatedByUserId"];
                        PropertyType.CreationDateTime = (DateTime)dr["CreationDateTime"];
                        PropertyType.UpdatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        PropertyType.CreatedByUser = user.Find(PropertyType.CreatedByUserId);
                        PropertyType.UpdatedByUser = user.Find(PropertyType.UpdatedByUserId);
                        ListPropertyType.Add(PropertyType);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListPropertyType;
        }
    }
}
