using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using FitnessShop.ServiceLayer.Domain;

namespace FitnessShop.ServiceLayer.Services
{
    interface KlijentService
    {
        Klijent Login(String username, String password);
    }
}
