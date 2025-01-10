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
    public class clsKundeDatenzugriff
    {

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static bool GetKundebyID(int kundeID, ref int personID, ref string firmaName,
                            ref DateTime regestriertAm, ref bool istAktive)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Kunde Where kundeID = @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@kundeID", kundeID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                personID = (int)reader["PersonID"];
                                firmaName = (string)reader["firmaName"];
                                regestriertAm = (DateTime)reader["regestriertAm"];
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

        public static bool GetKundebyPersonID(ref int kundeID,  int personID, ref string firmaName,
                            ref DateTime regestriertAm, ref bool istAktive)
        {

            bool isfound = false;

            string abfrage = @"SELECT * From Kunde Where personID = @personID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@personID", personID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                kundeID = (int)reader["kundeID"];
                                firmaName = (string)reader["firmaName"];
                                regestriertAm = (DateTime)reader["regestriertAm"];
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

        public static bool GetKundebyPersonName(string vollName, ref int kundeID, ref int personID, ref string firmaName,
                          ref DateTime regestriertAm, ref bool istAktive)
        {

            bool isfound = false;

            string abfrage = @"Select * from Kunde Inner join Person On
                                                              Kunde.personID = Person.personID
	                                               where Trim(person.Vorname) + ' ' + Trim(Person.Nachname) = @vollName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@vollName", vollName);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                kundeID = (int)reader["kundeID"];
                                personID = (int)reader["personID"];
                                firmaName = (string)reader["firmaName"];
                                regestriertAm = (DateTime)reader["regestriertAm"];
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


        public static DataTable GetAllKunde()
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select * From  Kunde
                                                  Order by kundeID Desc";
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

        public static DataTable GetKundeByName(string vollName)
        {
            DataTable dt = new DataTable();

            string abfrage = @"select Kunde.kundeID, Kunde.personID,
                                        (Person.Vorname + ' ' + Person.Nachname) as KundenName , 
                                        Person.Geburtstag, Person.Geschlecht, Kunde.firmaName, 
                                        Person.Email, Kunde.regestriertAm, Kunde.istAktive
                                       from Person INNER JOIN Kunde ON
                                       Person.PersonID = Kunde.personID
	                                   where Trim(person.Vorname) + ' ' + Trim(Person.Nachname) = @vollName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@vollName", vollName);

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
        public static DataTable GetAllKundenName()
        {
            DataTable dt = new DataTable();

            string abfrage = @"select (person.Vorname + ' ' + Person.Nachname) As Vollname
                                                 From Person Inner Join Kunde On 
	                                                Person.personID = Kunde.personID;";
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

        public static DataTable GetAllKunde_View()
        {
            DataTable dt = new DataTable();

            string abfrage = @"select Kunde.kundeID, Kunde.personID,
                                        (Person.Vorname + ' ' + Person.Nachname) as KundenName , 
                                        Person.Geburtstag, Person.Geschlecht, Kunde.firmaName, Person.Email, Kunde.regestriertAm, Kunde.istAktive
                                       from Person INNER JOIN Kunde ON
                                       Person.PersonID = Kunde.personID
                           Order by KundeID Desc";
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

        //public static DataTable GetMitarbeiter_View()
        //{
        //    DataTable dt = new DataTable();

        //    string abfrage = @"Select * from Mitarbeiter_View";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(abfrage, connection))
        //            {

        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                        dt.Load(reader);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return dt;
        //}

       
        public static bool DoesKundeExistForThisPerson(int PersonID)
        {
            bool isFound = false;
            string abfrage = "Select 1 From Kunde Where PersonID = @PersonID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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

        //public static bool isMitarbeiterActiveForThisPersonID(int PersonID)
        //{
        //    bool isActive = false;
        //    string abfrage = "Select 1 From Mitarbeiter Where PersonID = @PersonID And Zustand = 'Aktive' ";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(abfrage, connection))
        //            {
        //                command.Parameters.AddWithValue("@PersonID", PersonID);

        //                connection.Open();
        //                object result = command.ExecuteScalar();

        //                isActive = (result != null && (int)result == 1);

        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return isActive;
        //}
        public static int AddNewKunde(int personID, string firmaName, DateTime regestriertAm, bool istAktive)
        {
            int kundeID = -1;

            string abfrage = @"Insert into Kunde(personID,firmaName, regestriertAm, istAktive)
                                        Values  (@personID, @firmaName, @regestriertAm, @istAktive)
                               Select Scope_Identity()";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@personID", personID);
                        command.Parameters.AddWithValue("@firmaName", firmaName);
                        command.Parameters.AddWithValue("@regestriertAm", regestriertAm);
                        command.Parameters.AddWithValue("@istAktive", istAktive);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            kundeID = insertedID;
                        }


                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return kundeID;
        }

        public static bool UpdateKunde(int KundeID, string firmaName, DateTime regestriertAm, bool istAktive)
        {
            int RowAffected = 0;
            string abfrage = @"Update Kunde  Set 
                                                       firmaName   = @firmaName,
                                                       regestriertAm = @regestriertAm,
                                                       istAktive  = @istAktive
                                           Where kundeID = @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@kundeID", KundeID);
                        command.Parameters.AddWithValue("@firmaName", firmaName);
                        command.Parameters.AddWithValue("@regestriertAm", regestriertAm);
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

        public static bool DeleteKunde(int kundeID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Kunde Where kundeID = @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@kundeID", kundeID);

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

        public static bool deaktiviereKunde(int kundeID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Kunde
                                  set istAktive = 0
                                      where  istAktive = 1 And kundeID = @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@kundeID", kundeID);

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

        public static bool aktiviereKunde(int kundeID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Kunde
                                  set istAktive = 1
                                      where  istAktive = 0 And  kundeID = @kundeID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@kundeID", kundeID);

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

        //public static bool HatMitarbeiterEinenArbeitsvertrag(int mitarbeiterID)
        //{
        //    bool hatVertrag = false;
        //    string abfrage = @"Select dbo.HatMitarbeiterEinenArbeitsVertrag(@MitarbeiterID)";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(abfrage, connection))
        //            {
        //                command.Parameters.AddWithValue("@MitarbeiterID", mitarbeiterID);

        //                connection.Open();
        //                object result = command.ExecuteScalar();
        //                if (result != null)
        //                    hatVertrag = Convert.ToBoolean(result);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return hatVertrag;
        //}

    }
}

