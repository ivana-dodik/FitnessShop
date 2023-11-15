using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Services
{
    class KorpaServiceImpl : KorpaService
    {

        string INSERT_NARUDZBA_QUERY = "INSERT INTO narudzba (klijent_id) VALUES (@klijentId)";

        string INSERT_NARUDZBA_STAVKA_QUERY = "INSERT INTO narudzba_stavka (narudzba_id, proizvod_id, kolicina) VALUES (@narudzbaId, @proizvodId, @kolicina)";


        public void AddKorpaStavka(int proizvodId, int klijentId)
        {
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand("insert_korpa_stavka", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@proizvod_id", proizvodId);
                    command.Parameters.AddWithValue("@klijent_id", klijentId);
                    command.Parameters.AddWithValue("@kolicina", 1);

                    command.ExecuteNonQuery();
                }
            }

        }

        public void Clear(int klijentId)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"delete from korpa_stavka where klijent_id = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", klijentId);

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

        public List<KorpaStavka> GetAll(int klijentId)
        {
            List<KorpaStavka> korpaStavka = new List<KorpaStavka>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM korpa where klijent_id=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", klijentId);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KorpaStavka ks = new KorpaStavka(
                        reader.GetInt32("proizvod_id"),
                        klijentId,
                        reader.GetInt32("kolicina"),
                        reader.GetString("naziv"));

                    korpaStavka.Add(ks);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return korpaStavka;
            }

            finally
            {
                connection.Close();
            }

            return korpaStavka;
        }

        public void IncrementKorpaStavkaKolicina(int proizvodId, int klijentId)
        {
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand("UPDATE korpa_stavka SET kolicina = kolicina + 1 WHERE proizvod_id = @proizvodId AND klijent_id = @klijentId;", connection))
                {
                    command.Parameters.AddWithValue("@proizvodId", proizvodId);
                    command.Parameters.AddWithValue("@klijentId", klijentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Order(Korpa korpa)
        {
            using (var connection = DataSource.GetOpenConnection())
            {

                using (var transaction = connection.BeginTransaction())
                {
                    using (var insertNarudzbaCmd = new MySqlCommand(INSERT_NARUDZBA_QUERY, connection, transaction))
                    using (var insertNarudzbaStavkaCmd = new MySqlCommand(INSERT_NARUDZBA_STAVKA_QUERY, connection, transaction))
                    {
                        // Insert Narudzba
                        insertNarudzbaCmd.Parameters.AddWithValue("@klijentId", korpa.getStavke()[0].KlijentId);
                        insertNarudzbaCmd.ExecuteNonQuery();

                        // Get the generated ID of the new Narudzba
                        int narudzbaId = (int)insertNarudzbaCmd.LastInsertedId;

                        // Insert NarudzbaStavka for each item in the list
                        foreach (var stavka in korpa.getStavke())
                        {
                            insertNarudzbaStavkaCmd.Parameters.AddWithValue("@narudzbaId", narudzbaId);
                            insertNarudzbaStavkaCmd.Parameters.AddWithValue("@proizvodId", stavka.ProizvodId);
                            insertNarudzbaStavkaCmd.Parameters.AddWithValue("@kolicina", stavka.Kolicina);
                            insertNarudzbaStavkaCmd.ExecuteNonQuery();
                            insertNarudzbaStavkaCmd.Parameters.Clear();
                        }

                        // Commit the transaction
                        transaction.Commit();
                    }
                }
            }

        }


    }
}
