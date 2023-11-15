using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using FitnessShop.ServiceLayer;
using FitnessShop.View;

namespace FitnessShop.ServiceLayer.Services
{
    public class AdminServiceImpl : AdminService
    {
        public bool Login(string username, string password)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin WHERE korisnicko_ime=@username AND lozinka=(@password)", connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Prepare();

            try
            {
                MySqlDataReader res = cmd.ExecuteReader();
                return res.HasRows;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
