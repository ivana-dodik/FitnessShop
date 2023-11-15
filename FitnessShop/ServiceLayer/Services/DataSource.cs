using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace FitnessShop.ServiceLayer.Services
{
    class DataSource
    {
        private static String connectionString = "server=localhost;user=root;database=fitness_shop;password=ivana1";

        public static MySqlConnection GetOpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
