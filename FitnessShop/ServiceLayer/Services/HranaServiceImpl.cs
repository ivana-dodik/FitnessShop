using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using FitnessShop.ServiceLayer.Domain;
using System.Data;

namespace FitnessShop.ServiceLayer.Services
{
    class HranaServiceImpl : HranaService
    {
        public Hrana AddHrana(string naziv, string opis, double cijena, int kolicinaNaStanju, int robnaMarkaId, string robnaMarka)
        {
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand("insert_hrana_proizvod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@cijena", cijena);
                    command.Parameters.AddWithValue("@opis", opis);
                    command.Parameters.AddWithValue("@naziv", naziv);
                    command.Parameters.AddWithValue("@kolicina_na_stanju", kolicinaNaStanju);
                    command.Parameters.AddWithValue("@robna_marka_id", robnaMarkaId);
                    command.Parameters.AddWithValue("@hranljive_vrijednosti", generateHranljiveVrijednosti());

                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int id = (int)command.Parameters["@id"].Value;

                    return new Hrana(id, naziv, opis, cijena, kolicinaNaStanju, robnaMarka);
                }
            }
        }

        public void DeleteHrana(int hranaId)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"delete from proizvod where proizvod_id = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", hranaId);

            try
            {   
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            finally
            {
                connection.Close();
            }
        }

        public void EditHrana(string naziv, string opis, double cijena, int kolicinaNaStanju, int robnaMarkaId, int hranaId)
        {
            int numberOfRowsAffected = 0;

            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"update proizvod set naziv = @naziv, cijena = @cijena, opis = @opis, kolicina_na_stanju = @kolicina_na_stanju, robna_marka_id = @robna_marka_id WHERE proizvod_id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@naziv", naziv);
                command.Parameters.AddWithValue("@opis", opis);
                command.Parameters.AddWithValue("@cijena", cijena);
                command.Parameters.AddWithValue("@kolicina_na_stanju", kolicinaNaStanju);
                command.Parameters.AddWithValue("@robna_marka_id", robnaMarkaId);
                command.Parameters.AddWithValue("@id", hranaId);

                numberOfRowsAffected = command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Hrana> GetAllHrana()
        {
            List<Hrana> hrana = new List<Hrana>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM hrana_proizvod", connection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Hrana h = new Hrana(
                        reader.GetInt32("hrana_id"),
                        reader.GetString("naziv"),
                        reader.GetString("opis"),
                        reader.GetDouble("cijena"),
                        reader.GetInt32("kolicina_na_stanju"),
                        reader.GetString("robna_marka"));

                    hrana.Add(h);
                }
            }
            catch (Exception)
            {
                return hrana;
            }

            finally
            {
                connection.Close();
            }

            return hrana;
        }

        public List<KlijentHrana> GetAllKlijentHrana()
        {
            List<KlijentHrana> hrana = new List<KlijentHrana>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM klijentska_hrana WHERE kolicina_na_stanju > 0", connection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KlijentHrana h = new KlijentHrana(
                        reader.GetInt32("proizvod_id"),
                        reader.GetString("naziv"),
                        reader.GetString("opis"),
                        reader.GetDouble("cijena"),
                        reader.GetInt32("kolicina_na_stanju"),
                        reader.GetString("robna_marka"),
                        reader.GetString("hranljive_vrijednosti"));

                    hrana.Add(h);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return hrana;
            }

            finally
            {
                connection.Close();
            }

            Console.WriteLine(  hrana.Count);
            return hrana;
        }

        private String generateHranljiveVrijednosti()
        {
            Random rnd = new Random();
            int masti = rnd.Next(50);
            int proteini = rnd.Next(50);
            int carbs = rnd.Next(50);
            int kalorije = 4 * carbs + 4 * proteini + 9 * masti;

            return "{"
                  + "\"Masti\": " + masti + ","
                  + "\"Protein\": " + proteini + ","
                  + "\"Kalorije\": " + kalorije + ","
                  + "\"Ugljikohidrati\": " + carbs
                  + "}";

        }
    }
}
