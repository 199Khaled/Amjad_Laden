using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;

namespace Data_Layer
{
    public class clsPreisDatenzugriff
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public static string connection { get { return ConnectionString; } }    

        public static bool GetPreisKategorieByID(int preisID, ref int Kategorie, ref int miniMenge, ref int maxMenge, ref float preisProEinheit)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From Preise Where PreisID = @preisID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@PreisID", preisID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                Kategorie = (int)reader["Kategorie"];
                                miniMenge = (int)reader["MiniMenge"];
                                maxMenge = (int)reader["MaxMenge"];
                                preisProEinheit = (float)reader["PreisProEinheit"];
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

        public static bool GetPreisKategorieByKategorie(ref int preisID, int Kategorie, ref int miniMenge, ref int maxMenge, ref float preisProEinheit)
        {

            bool isfound = false;
            string abfrage = @"SELECT * From Preise Where Kategorie = @Kategorie";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        command.Parameters.AddWithValue("@Kategorie", Kategorie);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;

                                preisID = (int)reader["preisID"];
                                miniMenge = (int)reader["MiniMenge"];
                                maxMenge = (int)reader["MaxMenge"];
                                preisProEinheit = (float)reader["PreisProEinheit"];
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
        public static DataTable GetAllPreise()
        {
            DataTable dt = new DataTable();

            string abfrage = @"Select PreisID, Kategorie, Cast(MiniMenge As Nvarchar(50)) + '  Gm'  As MiniMengeInGramm,
                                                         Cast(MaxMenge As Nvarchar(50)) + '  Gm'  As MaxMengeInGramm,
                                                         Format(PreisProEinheit, 'C', 'de-DE') As Preis
                                                  From  Preise ";

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
        public static int AddNewPreis(int Kategorie, int miniMenge, int maxMenge, float preisProEinheit)
        {
            int preisID = -1;

            string abfrage = @"Insert into Preise (Kategorie, MiniMenge, MaxMenge, PreisProEinheit)
                                        Values  (@Kategorie, @miniMenge, @maxMenge, @preisProEinheit)
                                  SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@Kategorie", Kategorie);
                        command.Parameters.AddWithValue("@miniMenge", miniMenge);
                        command.Parameters.AddWithValue("@maxMenge", maxMenge);
                        command.Parameters.AddWithValue("@preisProEinheit", preisProEinheit);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            preisID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return preisID;
        }

        public static bool UpdatePreise(int preisID, int Kategorie, int miniMenge, int maxMenge, float preisProEinheit)
        {
            int RowAffected = 0;
            string abfrage = @"Update Preise  Set
                                                  Kategorie = @Kategorie,
                                                  MiniMenge = @miniMenge,
                                                  MaxMenge  = @maxMenge,
                                                  PreisProEinheit= @preisProEinheit
                                     
                                            Where PreisID = @preisID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {

                        // Parameter hinzufügen
                        // Über Parameter hinzufügen
                        command.Parameters.AddWithValue("@preisID", preisID);
                        command.Parameters.AddWithValue("@Kategorie", Kategorie);
                        command.Parameters.AddWithValue("@miniMenge", miniMenge);
                        command.Parameters.AddWithValue("@maxMenge", maxMenge);
                        command.Parameters.AddWithValue("@preisProEinheit", preisProEinheit);

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

        public static bool DeletePreise(int preisID)
        {
            int RowAffected = 0;

            string abfrage = @"Delete From Preise Where PreisID = @preisID";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@preisID", preisID);

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

        public static float BerechnePreis(float menge, int kategorie)
        {
            float parfümPreis = 0;

            string query = @"
            SELECT TOP 1 PreisProEinheit
            FROM Preise
            WHERE Kategorie = @Kategorie
              AND @Menge BETWEEN MiniMenge AND MaxMenge";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Kategorie", kategorie);
                    command.Parameters.AddWithValue("@Menge", menge);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && float.TryParse(result.ToString(), out float outPreis))
                        {
                            parfümPreis = outPreis;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler: {ex.Message}");
                        throw;
                    }
                }
            }
            return parfümPreis;
        }

        public static bool IstKategorieVorhanden(int Kategorie)
        {
            bool isfound = false;
            string abfrage = @"SELECT 1 FROM Preise WHERE Kategorie= @Kategorie";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@Kategorie", Kategorie);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true; // Kategorie existiert, da ein Ergebnis zurückgegeben wurde
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isfound = false;
                throw; // Optional: Logge den Fehler hier
            }

            return isfound;
        }
    }
}

