using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public class RolesRepo : DbConnection, IRolesRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public RolesRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~RolesRepo()
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

        public List<RolesModel> Find()
        {
            RolesModel role = null;
            List<RolesModel> ListRoles = new List<RolesModel>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindRoles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        role = new RolesModel();
                        role.RolesId = (int)dr["RolesId"];
                        role.RoleDescription = dr["RoleDescription"].ToString();
                        role.DefaultPage = dr["DefaultPage"].ToString();
                        ListRoles.Add(role);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListRoles;
        }

        public RolesModel Find(int pRoleId)
        {
            RolesModel role = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindRoleByRoleId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pRoleId", pRoleId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    role = new RolesModel();
                    role.RolesId = (int)dr["RolesId"];
                    role.RoleDescription = dr["RoleDescription"].ToString();
                    role.DefaultPage = dr["DefaultPage"].ToString();

                }

                dr.Close();
                dr = null;
            }
            return role;
        }
    }
}
