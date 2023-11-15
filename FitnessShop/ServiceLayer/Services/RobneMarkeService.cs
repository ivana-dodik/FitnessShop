using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using FitnessShop.ServiceLayer.Domain;

namespace FitnessShop.ServiceLayer.Services
{
    interface RobneMarkeService
    {
        List<RobnaMarka> GetAllRobnaMarka();

        void DeleteRobnaMarka(int robnaMarkaId);

        RobnaMarka AddRobnaMarka(String naziv, String opis);

        void EditRobnaMarka(int id, String naziv, String opis);
    }
}
