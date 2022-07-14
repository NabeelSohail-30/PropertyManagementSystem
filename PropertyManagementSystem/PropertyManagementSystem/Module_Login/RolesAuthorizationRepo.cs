using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    class RolesAuthorizationRepo : DbConnection, IRoleAuthorizationRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public RolesAuthorizationRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~RolesAuthorizationRepo()
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

        public List<RoleAuthorizationModel> Find(int pRoleId)
        {
            RoleAuthorizationModel roleAuthorization = null;
            List<RoleAuthorizationModel> ListRole = new List<RoleAuthorizationModel>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindRoleAuthorizationByRoleId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pRoleId", pRoleId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        roleAuthorization = new RoleAuthorizationModel();
                        RolesRepo role = new RolesRepo();
                        PagesRepo page = new PagesRepo();
                        roleAuthorization.RoleAuthorizationId = (int)dr["RoleAuthorizationId"];
                        roleAuthorization.RoleId = (int)dr["RoleId"];
                        roleAuthorization.PageId = (int)dr["PageId"];
                        roleAuthorization.AllowCreate = (bool)dr["AllowCreate"];
                        roleAuthorization.AllowDelete = (bool)dr["AllowDelete"];
                        roleAuthorization.AllowRead = (bool)dr["AllowRead"];
                        roleAuthorization.AllowUpdate = (bool)dr["AllowUpdate"];
                        roleAuthorization.Role = role.Find(roleAuthorization.RoleId);
                        roleAuthorization.Page = page.Find(roleAuthorization.PageId);
                        ListRole.Add(roleAuthorization);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListRole;
        }
    }
}
