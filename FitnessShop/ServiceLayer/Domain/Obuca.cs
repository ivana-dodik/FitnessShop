using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    public class Obuca
    {
        public int Id { get; set; }
        public String Naziv { get; set; }
        public String Opis { get; set; }
        public double Cijena { get; set; }
        public int KolicinaNaStanju { get; set; }
        public String Boja { get; set; }
        public String Pol { get; set; }
        public String RobnaMarka { get; set; }
        public String Velicina { get; set; }

        public Obuca(int id, String naziv, String opis, double cijena, int kolicinaNaStanju, String boja, String pol, String robnaMarka, String velicina)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Cijena = cijena;
            this.KolicinaNaStanju = kolicinaNaStanju;
            this.Boja = boja;
            this.Pol = pol;
            this.RobnaMarka = robnaMarka;
            this.Velicina = velicina;
        }
    }
}
