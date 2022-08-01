using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManagementSystem.Module_Login;
using PropertyManagementSystem;

namespace PropertyManagementSystem
{
    public class UserAccountsRepo : DbConnection, IUserAccountsRepo
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public UserAccountsRepo()
        {
            conn = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
        }

        ~UserAccountsRepo()
        {
            DBConnectionClose();
        }

        public int AddUser(UserAccountsModel user)
        {
            int UserAccountId = 0;

            //using (conn)
            //{
            using (cmd)
            {
                cmd.Connection = conn;
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

                DbConnectionOpen();
                UserAccountId = (int)cmd.ExecuteScalar();
            }
            //}

            return UserAccountId;
        }

        //done
        public UserAccountsModel AuthenticateLogin(string pUserName, string pPassword)
        {

            UserAccountsModel valUser = null;

            //Validations
            if (pUserName == null || string.IsNullOrEmpty(pUserName))
            {
                throw new NullReferenceException();
            }
            else if (pPassword == null || string.IsNullOrEmpty(pPassword))
            {
                throw new NullReferenceException();
            }

            valUser = this.Find(pUserName);

            if (valUser == null)
            {
                throw new Exception("User Account does not Exists");
            }
            else if (valUser.Active == false)
            {
                throw new Exception("User Account is not Active");
            }
            else if (valUser.AccountLockedOut == true)
            {
                throw new Exception("User Account is Locked Out");
            }


            UserAccountsModel UserAuthenticate = null;
            int Number;

            //using (conn)
            //{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spAuthenticateUserAccount";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserName", pUserName);
                cmd.Parameters.AddWithValue("@pPassword", pPassword);

                cmd.Parameters.Add("@pNumber", SqlDbType.Int);
                cmd.Parameters["@pNumber"].Direction = ParameterDirection.ReturnValue;

                DbConnectionOpen();

                cmd.ExecuteNonQuery();
                //conn.Close();

                Number = int.Parse(cmd.Parameters["@pNumber"].Value.ToString());
                Messages.Number = Number;
                Messages.Message = Messages.Find(Number);

                if (Number == 1)
                {
                    UserAuthenticate = this.Find(pUserName);
                }
                else
                {
                    throw new Exception($"{Messages.Message}");
                }

            }
            //}
            return UserAuthenticate;
        }

        private void DbConnectionOpen()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public UserAccountsModel Find(int pUserAccountId)
        {
            UserAccountsModel user = null;
            //using (conn)
            //{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spGetUserAccountById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserId", pUserAccountId);

                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    UserRolesRepo userRole = new UserRolesRepo();
                    user = new UserAccountsModel();
                    dr.Read();
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
                    user.UserRoles = userRole.Find(pUserAccountId);
                }

                dr.Close();
                dr = null;
            }
            //}

            return user;
        }

        public UserAccountsModel Find(string pUserName)
        {
            UserAccountsModel user = null;
            //using (conn)
            //{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spGetUserAccountByUserName";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserName", pUserName);

                //conn.Open();
                DbConnectionOpen();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    UserRolesRepo userRole = new UserRolesRepo();
                    user = new UserAccountsModel();
                    dr.Read();
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

                    if (!DBNull.Value.Equals(dr["LastLoginDateTime"]))
                        user.LastLoginDateTime = (DateTime)dr["LastLoginDateTime"];

                    if (!DBNull.Value.Equals(dr["LastLoggedOutDateTime"]))
                        user.LastLoggedOutDateTime = (DateTime)dr["LastLoggedOutDateTime"];

                    user.IsLogged = (bool)dr["IsLogged"];
                    user.AllowMultipleLogin = (bool)dr["AllowMultipleLogin"];
                    user.UserRoles = userRole.Find(user.UserAccountId);
                }

                dr.Close();
                dr = null;
                //conn.Close();
            }
            //}

            return user;
        }
        public string GetDefaultPage(int pRoleId)
        {
            var defaultPage = string.Empty;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spGetDefaultPageByRoleId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pRoleId", pRoleId);

                //get return value (message id) and find message

                DbConnectionOpen();
                defaultPage = cmd.ExecuteScalar().ToString();
            }
            return defaultPage;
        }

        public string GetDefaultPage(string pUserAccountId)
        {
            var defaultPage = string.Empty;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                int UserId = int.Parse(pUserAccountId);
                cmd.CommandText = "spGetDefaultPageByUserAccountId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserAccountId", UserId);

                //get return value (message id) and find message

                DbConnectionOpen();
                defaultPage = cmd.ExecuteScalar().ToString();
            }
            return defaultPage;
        }

        //done
        public void SignOut(int pUserAccountId)
        {
            //using (conn)
            //{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "spSignOut";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUserId", pUserAccountId);

                DbConnectionOpen();
                cmd.ExecuteNonQuery();
                DBConnectionClose();
            }
            //}
        }

        private void DBConnectionClose()
        {
            cmd.Dispose();
            cmd = null;

            conn.Close();
            conn.Dispose();
            conn = null;

        }
    }
}
