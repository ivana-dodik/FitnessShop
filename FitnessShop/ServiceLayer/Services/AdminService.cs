using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FitnessShop.ServiceLayer.Services
{
    interface AdminService
    {
        bool Login(String username, String password);
    }
}
