using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    public class UserRolesRepo : DbConnection, IUserRolesRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public UserRolesRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }
        ~UserRolesRepo()
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

        public List<UserRolesModel> Find(int pUserAccountId)
        {
            UserRolesModel userRole = null;
            List<UserRolesModel> ListUser = new List<UserRolesModel>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spFindUserRolesByUserAccountId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserAccountId", pUserAccountId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RolesRepo role = new RolesRepo();
                        RolesAuthorizationRepo roleAuthorization = new RolesAuthorizationRepo();
                        userRole = new UserRolesModel();
                        userRole.UserRoleId = (int)dr["UserRoleId"];
                        userRole.UserAccountId = (int)dr["UserAccountId"];
                        userRole.RoleId = (int)dr["RoleId"];
                        userRole.DefaultPageRole = (bool)dr["DefaultPageRole"];
                        userRole.Role = role.Find(userRole.RoleId);
                        userRole.RoleAuthorizations = roleAuthorization.Find(userRole.RoleId);
                        ListUser.Add(userRole);
                    }
                }

                dr.Close();
                dr = null;
            }
            return ListUser;
        }
    }
}
