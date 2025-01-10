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
   public class clsPersonDatenzugriff
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static bool GetPersonDataByPersonID(int PersonID, ref string Vorname,
          ref string Nachname, ref DateTime GeburtsTag, ref char Geschlecht, ref string steuerNummer,
          ref string Email, ref string Straße, ref string Stadt,
          ref string Land, ref string Telefon)
        {
            bool isFound = false;
            string abfrage = @"Select * From Person     Where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            //wenn das object gefungen ist
                            isFound = true;

                            Vorname = (string)reader["Vorname"];
                            Nachname = (string)reader["Nachname"];
                            GeburtsTag = (DateTime)reader["GeburtsTag"];
                            Geschlecht = reader["Geschlecht"].ToString()[0];
                            steuerNummer = (string)reader["SteuerID"];
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                            Straße = (string)reader["Strasse"];
                            Stadt = (string)reader["Stadt"];
                            Land = reader["Land"] != DBNull.Value ? (string)reader["Land"] : string.Empty;
                            Telefon = reader["Telefon"] != DBNull.Value ? (string)reader["Telefon"] : string.Empty;               
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    throw new Exception("Fehler beim Aufrufen der PersonDaten\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isFound;

        }

        //public static bool GetPersonDataByNationalID(ref int PersonID, string AusweisID, ref string Vorname,
        //    ref string Nachname, ref DateTime GeburtsTag, ref DateTime RegistrierungsDatum, ref byte Geschlecht, ref int LandID,
        //    ref string Stadt, ref string Postleitzahl, ref string Straße,
        // ref string Hausnummer, ref string Email, ref string TelefonNummer, ref string FotoPfad)
        //{
        //    bool isFound = false;

        //    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        //    string abfrage = @"Select * From Personen     Where AusweisID = @AusweisID";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        using (SqlCommand command = new SqlCommand(abfrage, connection))
        //        {
        //            command.Parameters.AddWithValue("@AusweisID", AusweisID);

        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    //wenn das object gefungen ist..           
        //                    isFound = true;

        //                    PersonID = (int)reader["PersonID"];
        //                    Vorname = (string)reader["Vorname"];
        //                    Nachname = (string)reader["Nachname"];
        //                    GeburtsTag = (DateTime)reader["GeburtsTag"];
        //                    RegistrierungsDatum = (DateTime)reader["RegistrierungsDatum"];
        //                    Geschlecht = (byte)reader["Geschlecht"];
        //                    LandID = (int)reader["LandID"];
        //                    Stadt = (string)reader["Stadt"];
        //                    Postleitzahl = (string)reader["Postleitzahl"];
        //                    Straße = (string)reader["Straße"];
        //                    Hausnummer = (string)reader["HausNummer"];

        //                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
        //                    TelefonNummer = reader["TelefonNummer"] != DBNull.Value ? (string)reader["TelefonNummer"] : string.Empty;
        //                    FotoPfad = reader["FotoPfad"] != DBNull.Value ? (string)reader["FotoPfad"] : string.Empty;

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Fehler beim Aufrufen der PersonDaten\n" + ex.Message);
        //    }
        //    return isFound;
        //}

        public static bool GetPersonDataByEmailAdresse(ref int PersonID, ref string Vorname,
          ref string Nachname, ref DateTime GeburtsTag, ref char Geschlecht, ref string steuerID ,
         string Email, ref string Straße, ref string Stadt,
          ref string Land, ref string Telefon)
        {
            bool isFound = false;

            string abfrage = @"Select * From Person    Where Email = @Email";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //wenn das object gefungen ist
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                            Vorname = (string)reader["Vorname"];
                            Nachname = (string)reader["Nachname"];
                            GeburtsTag = (DateTime)reader["GeburtsTag"];
                            Geschlecht = reader["Geschlecht"].ToString()[0];
                            steuerID = (string)reader["SteuerID"];
                            Straße = (string)reader["Strasse"];
                            Stadt = (string)reader["Stadt"];
                            Land = reader["Land"] != DBNull.Value ? (string)reader["Land"] : string.Empty;
                            Telefon = reader["Telefon"] != DBNull.Value ? (string)reader["Telefon"] : string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    throw new Exception("Fehler beim Aufrufen der PersonDaten\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isFound;
        }

        public static bool GetPersonDataByPersonName(string PersonName, ref int PersonID, ref string Vorname,
          ref string Nachname, ref DateTime GeburtsTag, ref char Geschlecht, ref string steuerID,
         ref string Email, ref string Straße, ref string Stadt,
          ref string Land, ref string Telefon)
        {
            bool isFound = false;

            string abfrage = @"Select * From Person  
                                 Where Trim(Person.Vorname) + ' ' + Trim(Person.Nachname) = @PersonName";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@PersonName", PersonName);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //wenn das object gefungen ist
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                            Vorname = (string)reader["Vorname"];
                            Nachname = (string)reader["Nachname"];
                            GeburtsTag = (DateTime)reader["GeburtsTag"];
                            Geschlecht = reader["Geschlecht"].ToString()[0];
                            steuerID = (string)reader["SteuerID"];
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty;
                            Straße = (string)reader["Strasse"];
                            Stadt = (string)reader["Stadt"];
                            Land = reader["Land"] != DBNull.Value ? (string)reader["Land"] : string.Empty;
                            Telefon = reader["Telefon"] != DBNull.Value ? (string)reader["Telefon"] : string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    throw new Exception("Fehler beim Aufrufen der PersonDaten\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isFound;
        }
        //public static int GetPatientDataByPersonNamen(string PersonName)
        //{
        //    int PersonID = -1;

        //    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        //    string abfrage = @"select Personen.PersonID
        //                          From   Personen  
        //                          INNER JOIN Patients ON Personen.PersonID = Patients.PersonID
        //                         where Trim(Personen.Vorname) + ' ' + Trim(Personen.Nachname) = @PersonName";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    using (SqlCommand command = new SqlCommand(abfrage, connection))
        //    {
        //        command.Parameters.AddWithValue("@PersonName", PersonName);

        //        try
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {


        //                    PersonID = (int)reader["PersonID"];
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Fehler beim GetPerosnDatenByID Methode " + ex.Message);
        //        }
        //    }
        //    return PersonID;
        //}
        public static int AddNewPerson(string Vorname,string Nachname, DateTime GeburtsTag,
            char Geschlecht, string steuerID,string Email, string Straße, string Stadt,
          string Land, string Telefon)
        {
            int PersonID = -1;
            string abfrage = @"INSERT INTO Person
                                (Vorname, Nachname, GeburtsTag,
                                  Geschlecht, SteuerID, Email, Strasse, 
                                 Stadt, Land, Telefon)
                          VALUES 
                                (@Vorname, @Nachname, @GeburtsTag,
                                  @Geschlecht, @SteuerID, @Email, @Strasse, 
                                 @Stadt, @Land, @Telefon)
                         SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@Vorname", Vorname);
                command.Parameters.AddWithValue("@Nachname", Nachname);
                command.Parameters.AddWithValue("@GeburtsTag", GeburtsTag);
                command.Parameters.AddWithValue("@Geschlecht", Geschlecht);
                command.Parameters.AddWithValue("@SteuerID", steuerID);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Strasse", Straße);
                command.Parameters.AddWithValue("@Stadt", Stadt);
               command.Parameters.AddWithValue("@Land", Land);

                if (string.IsNullOrEmpty(Telefon))
                    command.Parameters.AddWithValue("@Telefon", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Telefon", Telefon);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        PersonID = InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Fehler beim Hinzufügen dieser Person.\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return PersonID;
            }
        }

        public static bool UpdatePerson(int PersonID,string Vorname, string Nachname, DateTime GeburtsTag,
            char Geschlecht, string steuerID, string Email, string Straße, string Stadt,
          string Land, string Telefon)
        {
            int BetroffeneZeile = 0;

            string abfrage = @"Update Person
                                       SET
                                              Vorname = @Vorname,
                                              Nachname = @Nachname,
                                              GeburtsTag = @GeburtsTag,
                                              Geschlecht = @Geschlecht,
                                              SteuerID  = @SteuerID,
                                              Email  = @Email,
                                              Straße  = @Straße,
                                              Stadt   = @Stadt,
                                              Land    = @Land,
                                              Telefon = @Telefon
                              Where PersonID  = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@Vorname", Vorname);
                command.Parameters.AddWithValue("@Nachname", Nachname);
                command.Parameters.AddWithValue("@GeburtsTag", GeburtsTag);
                command.Parameters.AddWithValue("@Geschlecht", Geschlecht);
                command.Parameters.AddWithValue("@SteuerID", steuerID);
                command.Parameters.AddWithValue("@Email", Email);
                
                command.Parameters.AddWithValue("@Straße", Straße);
                command.Parameters.AddWithValue("@Stadt", Stadt);
                command.Parameters.AddWithValue("@Land", Land);

                if (string.IsNullOrEmpty(Telefon))
                    command.Parameters.AddWithValue("@Telefon", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Telefon", Telefon);



                try
                {
                    connection.Open();
                    BetroffeneZeile = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Fehler beim Aktualisieren dieser Person.\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return (BetroffeneZeile > 0);
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            int BetroffeneZeile = 0;

            string abfrage = @"Delete From Person  Where PersonID = @PersonID ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    BetroffeneZeile = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Fehler beim Löschen dieser Person.\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return (BetroffeneZeile > 0);
            }
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            string abfrage = @"Select Find=1  From Personen   Where PersonID = @PersonID ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }

                }
                catch (Exception ex)
                {
                    isFound = false;
                    throw new Exception("Fehler beim Suchen.\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return isFound;
            }
        }

        //public static bool IsPersonExist(string AusweisID)
        //{
        //    bool isFound = false;

        //    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        //    string abfrage = @"Select Find=1  From Personen   Where AusweisID = @AusweisID ";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    using (SqlCommand command = new SqlCommand(abfrage, connection))
        //    {
        //        command.Parameters.AddWithValue("@AusweisID", AusweisID);

        //        try
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                isFound = reader.HasRows;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            isFound = false;
        //            throw new Exception("Fehler beim Suchen.\n" + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return isFound;
        //    }
        //}

        //public static bool IsPersonExistByEmailAdresse(string Email)
        //{
        //    bool isFound = false;

        //    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        //    string abfrage = @"Select Find=1  From Personen   Where Email = @Email";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    using (SqlCommand command = new SqlCommand(abfrage, connection))
        //    {
        //        command.Parameters.AddWithValue("@Email", Email);

        //        try
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                isFound = reader.HasRows;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            isFound = false;
        //            throw new Exception("Fehler beim Suchen.\n" + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return isFound;
        //    }
        //}

        //public static bool IsNationalIDFrei(string AusweisID)
        //{
        //    bool isFound = false;
        //    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        //    string abfrage = @"Select Find=1  From Personen   Where AusweisID = @AusweisID ";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    using (SqlCommand command = new SqlCommand(abfrage, connection))
        //    {
        //        command.Parameters.AddWithValue("@AusweisID", AusweisID);

        //        try
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                isFound = reader.HasRows;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            isFound = false;
        //            throw new Exception("Fehler beim Suchen.\n" + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return isFound;
        //    }
        //}

        public static DataTable GetAllPersons()
        {
            DataTable dtPersonen = new DataTable();

            string abfrage = @"Select * from Person  Order by PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(abfrage, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dtPersonen.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Fehler beim Laden der PersonenDaten .\n" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return dtPersonen;
            }

        }

        //public static DataTable GetPersonenRecordsProSeite(int ZeileProSeite, int SeiteNummer)
        //{
        //    DataTable dt = new DataTable();

        //    string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand("Sp_GetRecordsProSeite", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("@ZeileProSeite", ZeileProSeite);
        //                command.Parameters.AddWithValue("@SeiteNummer", SeiteNummer);

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
        //        throw new Exception("Fehler beim Laden der PersonenDaten.\n" + ex.Message);
        //    }
        //    return dt;
        //}

    }
}

