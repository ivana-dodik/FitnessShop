using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    class NarudzbaStavka
    {
        readonly string Naziv;
        readonly int Kolicina;
        readonly double Cijena;

        public NarudzbaStavka(String naziv, int kolicina, double cijena)
        {
            this.Naziv = naziv;
            this.Kolicina = kolicina;
            this.Cijena = cijena;
        }

        public string GetNaziv() { return Naziv; }
        public int GetKolicina() { return Kolicina; }
        public double GetCijena() { return Cijena; }

    }
}
