using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    class UserAccountsRepo : DbConnection, IUserAccounts
    {
        private SqlConnection conn;

        UserAccountsRepo()
        {
            conn = GetConnection();
        }

        ~UserAccountsRepo()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }

        public int AddUser(UserAccountsModel user)
        {
            throw new NotImplementedException();
        }

        public UserAccountsAuthenticateModel AuthenticateLogin(string pUserName, string pPassword)
        {
            UserAccountsAuthenticateModel UserAuthenticate = null;

            using (conn)
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spAuthenticateUserAccount";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);
                    cmd.Parameters.AddWithValue("@pUserPassword", pPassword);

                    SqlDataReader dr = cmd.ExecuteReader();

                    UserAuthenticate = new UserAccountsAuthenticateModel();
                    UserAuthenticate.UserAccountId = (int)dr["UserAccountId"];
                    UserAuthenticate.Active = (bool)dr["Active"];
                    UserAuthenticate.AccountLockedOut = (bool)dr["AccountLockedOut"];

                    dr.Close();
                    dr = null;
                }
            }

            return UserAuthenticate;
        }

        public UserAccountsModel GetUserById(int pUserAccountId)
        {
            UserAccountsModel user;
            using (conn)
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spGetUserAccountById";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserId", pUserAccountId);

                    SqlDataReader dr = cmd.ExecuteReader();

                    user = new UserAccountsModel();

                    user.UserAccountId = (int)dr["UserAccountId"];
                    user.UserName = (string)dr["UserName"];
                    user.FirstName = (string)dr["FirstName"];
                    user.LastName = (string)dr["LastName"];


                    dr.Close();
                    dr = null;
                }
            }

            return user;
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
