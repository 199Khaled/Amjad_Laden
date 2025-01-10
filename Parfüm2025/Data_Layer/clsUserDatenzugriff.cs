using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class clsUserDatenzugriff
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static bool GetUserByUsernameAndPasswort(ref int userID, ref int mitarbeiterID, string userRolle, string userPasswort,
                              ref int permissionNum, ref bool istAktive)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Benutzer Where userRolle = @userRolle And userPasswort = @userPasswort";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@userRolle", userRolle);
                        command.Parameters.AddWithValue("@userPasswort", userPasswort);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                userID = (int)reader["userID"];
                                mitarbeiterID = (int)reader["mitarbeiterID"];
                                permissionNum = (int)reader["permissionNum"];
                                istAktive = (bool)reader["istAktive"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw;
            }

            return isfound;
        }
        public static bool GetUserbyID(int userID, ref int mitarbeiterID, ref string userRolle, ref string userPasswort, 
                              ref int permissionNum, ref bool istAktive)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Benutzer Where userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@userID", userID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                mitarbeiterID = (int)reader["mitarbeiterID"];
                                userRolle = (string)reader["userRolle"];

                                //string entschlüsseltsPasswort = clsVerschlüsselungHelfer.Encrypt((string)reader["userPasswort"]);
                                userPasswort = (string)reader["userPasswort"];

                                permissionNum = (int)reader["permissionNum"];
                                istAktive = (bool)reader["istAktive"];
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw;
            }

            return isfound;
        }

        public static bool GetUserByMitarbeiterID(ref int userID, int mitarbeiterID, ref string userRolle, ref string userPasswort,
                              ref int permissionNum, ref bool istAktive)
        {

            bool isfound = false;

            string abfrage = @"SELECT * From Benutzer Where mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                userID = (int)reader["userID"];
                                userRolle = (string)reader["userRolle"];

                                //string entschlüsseltsPasswort = clsVerschlüsselungHelfer.Decrypt((string)reader["userPasswort"]);
                                userPasswort = (string)reader["userPasswort"];

                                permissionNum = (int)reader["permissionNum"];
                                istAktive = (bool)reader["istAktive"];

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw;
            }

            return isfound;
        }



        public static DataTable GetAllUser()
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select * From  Benutzer
                                                  Order by userID Desc";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return dt;
        }
        public static bool DoesUserExistForThisMitarbeiterID(int mitarbeiterID)
        {
            bool isFound = false;
            string abfrage = "Select 1 From Benutzer Where mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        isFound = (result != null && (int)result == 1);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return isFound;
        }

        public static bool ExistUserForThisMitarbeiterID(int mitarbeiterID)
        {
            bool isActive = false;
            string abfrage = "Select 1 From Benutzer Where mitarbeiterID = @mitarbeiterID ";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        isActive = (result != null && (int)result == 1);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return isActive;
        }
        public static int AddNewUser(int mitarbeiterID, string userRolle, string userPasswort,
                              int permissionNum,  bool istAktive)
        {
            int userID = -1;

            string abfrage = @"Insert into Benutzer (mitarbeiterID, userRolle, userPasswort, permissionNum, istAktive)
                                        Values  (@mitarbeiterID, @userRolle, @userPasswort, @permissionNum, @istAktive)
                               Select Scope_Identity()";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@mitarbeiteriD",mitarbeiterID);
                        command.Parameters.AddWithValue("@userRolle", userRolle);

                       // string verschlüsseltsPasswort = clsVerschlüsselungHelfer.Encrypt(userPasswort);
                        command.Parameters.AddWithValue("@userPasswort",userPasswort);

                        command.Parameters.AddWithValue("@permissionNum",permissionNum);
                        command.Parameters.AddWithValue("@istAktive", istAktive);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            userID = insertedID;
                        }


                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return userID;
        }

        public static bool UpdateUserByMitarbeiterID(int mitarbeiterID, string userRolle, string userPasswort,
                              int permissionNum, bool istAktive)
        {
            //string verschlüsseltesPasswort = clsVerschlüsselungHelfer.Encrypt(userPasswort);
            int RowAffected = 0;
            string abfrage = @"Update Benutzer Set 
                                                       userRolle = @userRolle,
                                                       userPasswort = @userPasswort,
                                                       permissionNum = @permissionNum,
                                                       istAktive  = @istAktive
                                           Where mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);
                        command.Parameters.AddWithValue("@userRolle", userRolle);
                        command.Parameters.AddWithValue("@userPasswort", userPasswort);
                        command.Parameters.AddWithValue("@permissionNum", permissionNum);
                        command.Parameters.AddWithValue("@istAktive", istAktive);

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }


            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }

        public static bool UpdatePermission(int userID, int permissionNum )
        {
            int RowAffected = 0;
            string abfrage = @"Update Benutzer  Set 
                                                       permissionNum = @permissionNum,
                                           Where userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@permissionNum", permissionNum);

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }


            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }

        public static bool UpdateUser(int userID, string userRolle, string userPasswort,
                             int permissionNum, bool istAktive)
        {
            //string verschlüsseltesPasswort = clsVerschlüsselungHelfer.Encrypt(userPasswort);

            int RowAffected = 0;
            string abfrage = @"Update Benutzer Set 
                                                       userRolle = @userRolle,
                                                       userPasswort = @userPasswort,
                                                       permissionNum = @permissionNum,
                                                       istAktive  = @istAktive
                                           Where userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@userRolle", userRolle);
                        command.Parameters.AddWithValue("@userPasswort", userPasswort);
                        command.Parameters.AddWithValue("@permissionNum", permissionNum);
                        command.Parameters.AddWithValue("@istAktive", istAktive);

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }


            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }

        public static bool DeleteUser(int userID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Benutzer Where userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);

                        //Öffene die verbindung und ausführe den Befehl
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }
        public static bool DeleteUserByMitarbeiterID(int mitarbeiterID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Benutzer Where mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

                        //Öffene die verbindung und ausführe den Befehl
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return RowAffected > 0;
        }
        public static bool deaktiviereUser(int userID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Benutzer
                                  set istAktive = 0
                                      where  istAktive = 1 And userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);

                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public static bool aktiviereUser(int userID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Benutzer
                                  set istAktive = 1
                                      where  istAktive = 0 And  userID = @userID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);

                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return rowAffected > 0;
        } 
    }
}
