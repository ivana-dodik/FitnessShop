using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessShop.ServiceLayer.Domain;

namespace FitnessShop.ServiceLayer.Services
{
    interface HranaService
    {
        List<Hrana> GetAllHrana();

        List<KlijentHrana> GetAllKlijentHrana();

        void DeleteHrana(int hranaId);

        Hrana AddHrana(string naziv, string opis, double cijena, int kolicinaNaStanju, int robnaMarkaId, String robnaMarka);

        void EditHrana(string naziv, string opis, double cijena, int kolicinaNaStanju, int robnaMarkaId, int hranaId);
    }
}
