using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace Data_Layer
{
    public class clsParfümDatenzugriff
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

       public static DataTable GetAllParfüms()
        {
            DataTable dt = new DataTable(); ;

            string abfrage = @"select distinct parfümNummer, Marke, Name,Kategorie, Duftrichtung, Jahreszeiten, IstVorhanden
                             from Parfüm_Kopie  Order by parfümNummer Desc";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using(SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        public static DataTable GetAllHerrenParfüms()
        {
            DataTable dt = new DataTable(); ;

            string abfrage = @"
                               select* from Parfüm_Kopie where Kategorie Like 'Herrenduft%' 
                                order by parfümNummer Desc";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        public static DataTable GetAllDamenParfüms()
        {
            DataTable dt = new DataTable(); ;

            string abfrage = @"select * from Parfüm_Kopie where Kategorie Like 'Damenduft%'
                                 Order by parfümNummer Desc";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        public static bool AddNewPerfum(int parfümNummer, string marke, string name,string kategorie,
              string duftrichtung, string jahreszeiten, bool IstVorhanden)
        {
            int rowAffected = 0;

            string abfrage = @"Insert into Parfüm_Kopie (parfümNummer,Marke, Name, Kategorie, Duftrichtung, Jahreszeiten, IstVorhanden)
                                          Values(@parfümNummer, @marke, @name, @kategorie, @duftrichtung, @jahreszeiten, @istVorhanden)";
                              
                      
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using(SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);
                        command.Parameters.AddWithValue("@marke", marke);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@kategorie", kategorie);

                        if (string.IsNullOrEmpty(duftrichtung))
                            command.Parameters.AddWithValue("@duftrichtung", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@duftrichtung",duftrichtung);

                        if (string.IsNullOrEmpty(jahreszeiten))
                            command.Parameters.AddWithValue("@jahreszeiten", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@jahreszeiten", jahreszeiten);

                        command.Parameters.AddWithValue("@istVorhanden", IstVorhanden);

                        connection.Open();

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            return (rowAffected > 0);
        }

        public static bool UpdatePerfum(int neuParfümNummer, int parfümNummer, string marke, string name, string kategorie,
              string duftrichtung, string jahreszeiten, bool istVorhanden)
        {
            int rowAffected = 0;

            string abfrage = @"Update Parfüm_Kopie 
                                        Set  parfümNummer = @neuParfümNummer,
                                             Marke        = @marke,
                                             Name         = @name,
                                             Kategorie    = @kategorie,
                                             Duftrichtung = @duftrichtung,
                                             Jahreszeiten = @jahreszeiten,
                                             IstVorhanden = @istVorhanden
                                       Where parfümNummer = @parfümNummer";


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        //die neue ParfümNummer.
                        command.Parameters.AddWithValue("@neuParfümNummer", neuParfümNummer);
                        command.Parameters.AddWithValue("@marke", marke);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@kategorie", kategorie);

                        if (string.IsNullOrEmpty(duftrichtung))
                            command.Parameters.AddWithValue("@duftrichtung", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@duftrichtung", duftrichtung);

                        if (string.IsNullOrEmpty(jahreszeiten))
                            command.Parameters.AddWithValue("@jahreszeiten", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@jahreszeiten", jahreszeiten);

                        command.Parameters.AddWithValue("@istVorhanden", istVorhanden);

                        connection.Open();

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return (rowAffected > 0);
        }
        public static bool Delete(int parfümNummer)
        {
            int rowAffected = 0;
            string abfrage = @"Delete From Parfüm_Kopie  Where parfümNummer = @parfümNummer";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        connection.Open();
                       
                        rowAffected = command.ExecuteNonQuery();    
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return (rowAffected > 0);
        }

        public static bool Find(int parfümNummer, ref string marke, ref string name,
              ref string kategorie, ref string duftrichtung, ref string jahreszeiten,ref bool istVorhanden)
        {
            bool isfound = false;
            string abfrage = @"Select * From Parfüm_Kopie  Where parfümNummer = @parfümNummer";

            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isfound = true;

                                marke = (string)reader["Marke"];
                                name = (string)reader["Name"];
                                kategorie = (string)reader["Kategorie"];
                                duftrichtung = (string)reader["Duftrichtung"].ToString();                           
                                jahreszeiten = (string)reader["Jahreszeiten"].ToString();
                                istVorhanden = (bool)reader["IstVorhanden"];

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return isfound;
        }

        public static bool _IstParfümNummerVergeben(int parfümNummer)
        {
            int rowAffected = 0;
            string abfrage = @"Select Find = 1 From Parfüm_Kopie  Where parfümNummer = @parfümNummer";

            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    using(SqlCommand command = new SqlCommand(abfrage, connection))
                    {
                        command.Parameters.AddWithValue("@parfümNummer", parfümNummer);

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            rowAffected = (int)result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return (rowAffected > 0);
        }
    }
  
}

