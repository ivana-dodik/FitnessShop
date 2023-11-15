using FitnessShop.ServiceLayer.Domain;
using System.Collections.Generic;

namespace FitnessShop.ServiceLayer.Services
{
    internal interface NarudzbaService
    {
        List<Narudzba> GetAllNarudzbe(int klijentId);
    }
}
