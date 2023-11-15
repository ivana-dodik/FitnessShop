using FitnessShop.ServiceLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace FitnessShop.ServiceLayer.Services
{
    class RobneMarkeServiceImpl : RobneMarkeService
    {
        public RobnaMarka AddRobnaMarka(string naziv, string opis)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"insert into robna_marka (naziv, opis)
                                values (@naziv, @opis); SELECT LAST_INSERT_ID();";

            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@naziv", naziv);
                command.Parameters.AddWithValue("@opis", opis);

                int robnaMarkaId = Convert.ToInt32(command.ExecuteScalar());
                return new RobnaMarka(robnaMarkaId, naziv, opis, 0);
            }
            catch (Exception)
            {
                return null;
            }

            finally
            {
                connection.Close();
            }
        }

        public void DeleteRobnaMarka(int robnaMarkaId)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"delete from robna_marka where robna_marka_id = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", robnaMarkaId);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }

            finally
            {
                connection.Close();
            }
        }

        public void EditRobnaMarka(int id, string naziv, string opis)
        {

            int numberOfRowsAffected = 0;

            MySqlConnection connection = DataSource.GetOpenConnection();

            string query = @"update robna_marka set naziv = @naziv, opis = @opis WHERE robna_marka_id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@naziv", naziv);
                command.Parameters.AddWithValue("@opis", opis);


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

        public List<RobnaMarka> GetAllRobnaMarka()
        {
            //SELECT * FROM robna_marka_broj_proizvoda
            List<RobnaMarka> robnaMarka = new List<RobnaMarka>();

            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM robna_marka_broj_proizvoda", connection);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RobnaMarka rm = new RobnaMarka(
                        reader.GetInt32("robna_marka_id"),
                        reader.GetString("naziv"),
                        reader.GetString("opis"),
                        reader.GetInt32("broj_proizvoda"));

                    robnaMarka.Add(rm);
                }

                reader.Close();
            }
            catch (Exception)
            {
                return robnaMarka;
            }

            finally
            {
                connection.Close();
            }

            return robnaMarka;
        }
    }
}
