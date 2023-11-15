using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Util;

namespace FitnessShop.ServiceLayer.Services
{
    interface ObucaService
    {
        List<Obuca> GetAllObuca();

        List<KlijentObuca> GetAllKlijentObuca();

        void DeleteObuca(int ObucaId);

        Obuca AddObuca(string naziv, string opis, double cijena, int kolicinaNaStanju, string boja, PolAttr pol,
                       int robnaMarkaId, string robnaMarkaNaziv, VelicinaAttr velicina);

        void EditObuca(string naziv, string opis, double cijena, int kolicinaNaStanju, string boja, PolAttr pol,
                       int robnaMarkaId, VelicinaAttr velicina, int obucaId);
    }
}
