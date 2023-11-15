using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    public class Hrana
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int KolicinaNaStanju { get; set; }
        public string RobnaMarka { get; set; }

        

        public Hrana(int id, String naziv, String opis, double cijena, int kolicinaNaStanju, String robnaMarka)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Cijena = cijena;
            this.KolicinaNaStanju = kolicinaNaStanju;
            this.RobnaMarka = robnaMarka;
        }
    }
}
