using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Util;
using System.Data;

namespace FitnessShop.ServiceLayer.Services
{
    class ObucaServiceImpl : ObucaService
    {
        public Obuca AddObuca(string naziv, string opis, double cijena, int kolicinaNaStanju, string boja, PolAttr pol, int robnaMarkaId, string robnaMarkaNaziv, VelicinaAttr velicina)
        {
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand("insert_obuca_proizvod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@naziv", naziv);
                    command.Parameters.AddWithValue("@opis", opis);
                    command.Parameters.AddWithValue("@cijena", cijena);
                    command.Parameters.AddWithValue("@kolicina_na_stanju", kolicinaNaStanju);
                    command.Parameters.AddWithValue("@boja", boja);
                    command.Parameters.AddWithValue("@pol_id", pol.NumericValue);
                    command.Parameters.AddWithValue("@velicina_obuce_id", velicina.Id);
                    command.Parameters.AddWithValue("@robna_marka_id", robnaMarkaId);
                    //command.Parameters.AddWithValue("@robna_marka_naziv", robnaMarkaNaziv);
                    
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int id = (int)command.Parameters["@id"].Value;

                    return new Obuca(id, naziv, opis, cijena, kolicinaNaStanju, boja, pol.StringValue, robnaMarkaNaziv, velicina.Naziv);
                }
            }


        }

        public void DeleteObuca(int ObucaId)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"delete from proizvod where proizvod_id = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ObucaId);

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

        public void EditObuca(string naziv, string opis, double cijena, int kolicinaNaStanju, string boja, PolAttr pol, int robnaMarkaId, VelicinaAttr velicina, int obucaId)
        {
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand("update_obuca_proizvod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@obuca_id", obucaId);
                    command.Parameters.AddWithValue("@naziv", naziv);
                    command.Parameters.AddWithValue("@opis", opis);
                    command.Parameters.AddWithValue("@cijena", cijena);
                    command.Parameters.AddWithValue("@kolicina_na_stanju", kolicinaNaStanju);
                    command.Parameters.AddWithValue("@boja", boja);
                    command.Parameters.AddWithValue("@pol_id", pol.NumericValue);
                    command.Parameters.AddWithValue("@robna_marka_id", robnaMarkaId);
                    command.Parameters.AddWithValue("@velicina_obuce_id", velicina.Id);


                    command.ExecuteNonQuery();
                }
            }
        }

        public List<KlijentObuca> GetAllKlijentObuca()
        {
            List<KlijentObuca> obuca = new List<KlijentObuca>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM obuca_proizvod_klijent WHERE kolicina_na_stanju > 0", connection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KlijentObuca o = new KlijentObuca(
                        reader.GetInt32("proizvod_id"),
                        reader.GetString("naziv"),
                        reader.GetString("opis"),
                        reader.GetDouble("cijena"),
                        reader.GetInt32("kolicina_na_stanju"),
                        reader.GetString("boja"),
                        reader.GetString("pol"),
                        reader.GetString("robna_marka"),
                        reader.GetString("velicine_kolicine").Split(':')[0]);

                    obuca.Add(o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return obuca;
            }

            finally
            {
                connection.Close();
            }

            return obuca;
        }

        public List<Obuca> GetAllObuca()
        {
            List<Obuca> obuca = new List<Obuca>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM obuca_proizvod", connection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Obuca o = new Obuca(
                        reader.GetInt32("proizvod_id"),
                        reader.GetString("naziv"),
                        reader.GetString("opis"),
                        reader.GetDouble("cijena"),
                        reader.GetInt32("kolicina_na_stanju"),
                        reader.GetString("boja"),
                        reader.GetString("pol"),
                        reader.GetString("robna_marka"),
                        reader.GetString("velicine"));

                    obuca.Add(o);
                }
            }
            catch (Exception)
            {
                return obuca;
            }

            finally
            {
                connection.Close();
            }

            return obuca;
        }
    }
}
