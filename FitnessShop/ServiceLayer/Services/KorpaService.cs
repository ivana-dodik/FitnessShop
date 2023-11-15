using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Services
{
    interface KorpaService
    {
        void AddKorpaStavka(int proizvodId, int klijentId);

        void IncrementKorpaStavkaKolicina(int proizvodId, int klijentId);

        void Clear(int klijentId);

        List<KorpaStavka> GetAll(int klijentId);

        void Order(Korpa korpa);
    }
}
