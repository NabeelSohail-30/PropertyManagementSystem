using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public class UserAccountsRepo : DbConnection, IUserAccounts
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public UserAccountsRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        ~UserAccountsRepo()
        {
            conn.Close();
            conn.Dispose();
            conn = null;

            cmd.Dispose();
            cmd = null;
        }

        public int AddUser(UserAccountsModel user)
        {
            int UserAccountId = 0;

            using (conn)
            {
                using (cmd)
                {
                    cmd.CommandText = "spAddUserAccount";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserName", user.UserName);
                    cmd.Parameters.AddWithValue("@pFirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@pLastName", user.LastName);
                    cmd.Parameters.AddWithValue("@pEmail", user.Email);
                    cmd.Parameters.AddWithValue("@pUserPassword", user.Password);
                    cmd.Parameters.AddWithValue("@pMobile", user.Mobile);
                    cmd.Parameters.AddWithValue("@pTwoFactorAuthentication", user.TwoFactorAuthentication);
                    cmd.Parameters.AddWithValue("@pAllowMultipleLogin", user.AllowMultipleLogin);

                    UserAccountId = (int)cmd.ExecuteScalar();
                }
            }

            return UserAccountId;
        }

        public UserAccountsAuthenticateModel AuthenticateLogin(string pUserName, string pPassword)
        {
            UserAccountsAuthenticateModel UserAuthenticate = null;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spAuthenticateUserAccount";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);
                    cmd.Parameters.AddWithValue("@pPassword", pPassword);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    UserAuthenticate = new UserAccountsAuthenticateModel();
                    dr.Read();
                    UserAuthenticate.UserAccountId = (int)dr["UserAccountId"];
                    UserAuthenticate.Active = (bool)dr["Active"];
                    UserAuthenticate.AccountLockedOut = (bool)dr["AccountLockedOut"];
                    UserAuthenticate.IsLogged = (bool)dr["IsLogged"];
                    UserAuthenticate.AllowMultipleLogin = (bool)dr["AllowMultipleLogin"];

                    dr.Close();
                    dr = null;
                }
            }

            return UserAuthenticate;
        }

        public UserAccountsModel Find(int pUserAccountId)
        {
            UserAccountsModel user;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand())
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
                    user.Email = (string)dr["Email"];
                    user.Mobile = (string)dr["Mobile"];
                    user.TwoFactorAuthentication = (bool)dr["TwoFactorAuthentication"];
                    user.Active = (bool)dr["Active"];
                    user.AccountLockedOut = (bool)dr["AccountLockedOut"];
                    user.WrongAttempts = (int)dr["WrongAttempts"];
                    user.LastLoginDateTime = (DateTime)dr["LastLoginDateTime"];
                    user.LastLoggedOutDateTime = (DateTime)dr["LastLoggedOutDateTime"];
                    user.IsLogged = (bool)dr["IsLogged"];
                    user.AllowMultipleLogin = (bool)dr["AllowMultipleLogin"];

                    dr.Close();
                    dr = null;
                }
            }

            return user;
        }

        public UserAccountsModel Find(string pUserName)
        {
            UserAccountsModel user;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spGetUserAccountByUserName";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserName", pUserName);

                    SqlDataReader dr = cmd.ExecuteReader();

                    user = new UserAccountsModel();

                    user.UserAccountId = (int)dr["UserAccountId"];
                    user.UserName = (string)dr["UserName"];
                    user.FirstName = (string)dr["FirstName"];
                    user.LastName = (string)dr["LastName"];
                    user.Email = (string)dr["Email"];
                    user.Mobile = (string)dr["Mobile"];
                    user.TwoFactorAuthentication = (bool)dr["TwoFactorAuthentication"];
                    user.Active = (bool)dr["Active"];
                    user.AccountLockedOut = (bool)dr["AccountLockedOut"];
                    user.WrongAttempts = (int)dr["WrongAttempts"];
                    user.LastLoginDateTime = (DateTime)dr["LastLoginDateTime"];
                    user.LastLoggedOutDateTime = (DateTime)dr["LastLoggedOutDateTime"];
                    user.IsLogged = (bool)dr["IsLogged"];
                    user.AllowMultipleLogin = (bool)dr["AllowMultipleLogin"];

                    dr.Close();
                    dr = null;
                }
            }

            return user;
        }

        public void SignOut(int pUserAccountId)
        {
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spSignOut";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pUserId", pUserAccountId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
