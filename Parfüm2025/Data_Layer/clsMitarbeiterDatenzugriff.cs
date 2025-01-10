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
    public class clsMitarbeiterDatenzugriff
    {

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static bool GetMitarbeiterbyID(int mitarbeiterID, ref int personID, ref string versicherungsName,
            ref string versicherungsNummer, ref DateTime EingestelltAm, ref bool istAktive)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From  Mitarbeiter Where mitarbeiterID = @mitarbeiterID";
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

                                personID = (int)reader["PersonID"];
                                versicherungsName = (string)reader["versicherungsName"];
                                versicherungsNummer = (string)reader["versicherungsNummer"];
                                EingestelltAm = (DateTime)reader["EingestelltAm"];
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

        public static bool GetMitarbeiterbyPersonID(ref int mitarbeiterID, int personID, ref string versicherungsName,
            ref string versicherungsNummer, ref DateTime EingestelltAm, ref bool istAktive)
        {

            bool isfound = false;

            string abfrage = @"SELECT * From Mitarbeiter Where personID = @personID";
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

                                mitarbeiterID = (int)reader["mitarbeiterID"];
                                versicherungsName = (string)reader["versicherungsName"];
                                versicherungsNummer = (string)reader["versicherungsNummer"];
                                EingestelltAm = (DateTime)reader["EingestelltAm"];
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



        public static DataTable GetAllMitarbeiter()
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select * From  Mitarbeiter
                                                  Order by MitarbeiterID Desc";
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


        public static DataTable GetAllMitarbeiter_View()
        {
            DataTable dt = new DataTable();

            string abfrage = @"select Mitarbeiter.mitarbeiterID, Mitarbeiter.personID,
                                        (Person.Vorname + ' ' + Person.Nachname) as Vollname , 
                                        Person.Geburtstag, Person.Geschlecht, Person.SteuerID,
                                         Mitarbeiter.versicherungsName, Mitarbeiter.versicherungsNummer,
                                       Mitarbeiter.EingestelltAm, Mitarbeiter.istAktive
                                       from Person INNER JOIN Mitarbeiter ON
                                       Person.PersonID = Mitarbeiter.personID 
                                Order by MitarbeiterID Desc";
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

        public static DataTable GetMitarbeiterByPersonName(string vollname)
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select * from Person Inner Join Mitarbeiter On
                                                      Person.PersonID = Mitarbeiter.personID 
		                                                     where Trim(Person.Vorname) + ' ' + Trim(Person.Nachname) = @PersonName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@Vollname", vollname);

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
        public static bool DoesMitarbeiterExistForThisPerson(int PersonID)
        {
            bool isFound = false;
            string abfrage = "Select 1 From Mitarbeiter Where PersonID = @PersonID";
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

        public static bool isMitarbeiterActiveForThisPersonID(int PersonID)
        {
            bool isActive = false;
            string abfrage = "Select 1 From Mitarbeiter Where PersonID = @PersonID And Zustand = 'Aktive' ";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static int AddNewMitarbeiter(int personID, string versicherungsName,
            string versicherungsNummer, DateTime EingestelltAm,  bool istAktive)
        {
            int MitarbeiterID = -1;

            string abfrage = @"Insert into Mitarbeiter(personID, versicherungsName, versicherungsNummer, EingestelltAm, istAktive)
                                        Values  (@personID, @versicherungsName, @versicherungsNummer, @EingestelltAm, @istAktive)
                               Select Scope_Identity()";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                      
                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@versicherungsName", versicherungsName);
                        command.Parameters.AddWithValue("@versicherungsNummer",versicherungsNummer);
                        command.Parameters.AddWithValue("@EingestelltAm", EingestelltAm);
                        command.Parameters.AddWithValue("@istAktive", istAktive);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            MitarbeiterID = insertedID;
                        }
                       

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return MitarbeiterID;
        }

        public static bool UpdateMitarbeiter(int MitarbeiterID, string versicherungsName,
            string versicherungsNummer, DateTime EingestelltAm, bool istAktive)
        {
            int RowAffected = 0;
            string abfrage = @"Update Mitarbeiter  Set 
                                                       versicherungsName = @versicherungsName,
                                                       versicherungsNummer = @versicherungsNummer,
                                                       EingestelltAm      = @EingestelltAm,
                                                       istAktive  = @istAktive
                                           Where mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    { 

                        // Parameter hinzufügen
                        command.Parameters.AddWithValue("@MitarbeiterID", MitarbeiterID);
                        command.Parameters.AddWithValue("@versicherungsName", versicherungsName);
                        command.Parameters.AddWithValue("@versicherungsNummer", versicherungsNummer) ;
                        command.Parameters.AddWithValue("@EingestelltAm", EingestelltAm);
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

        public static bool DeleteMitarbeiter(int mitarbeiterID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Mitarbeiter Where mitarbeiterID = @mitarbeiterID";
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

        public static bool deaktiviereMitarbeiter(int mitarbeiterID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Mitarbeiter
                                  set istAktive = 0
                                      where  istAktive = 1 And mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

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

        public static bool aktiviereMitarbeiter(int mitarbeiterID)
        {
            int rowAffected = 0;
            string abfrage = @"Update Mitarbeiter
                                  set istAktive = 1
                                      where  istAktive = 0 And  mitarbeiterID = @mitarbeiterID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@mitarbeiterID", mitarbeiterID);

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

