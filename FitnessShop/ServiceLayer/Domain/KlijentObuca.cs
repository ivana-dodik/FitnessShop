using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    class KlijentObuca
    {
        readonly int ProizvodId;
        public String Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int KolicinaNaStanju { get; set; }
        public string Boja { get; set; }
        public string Pol { get; set; }
        public string RobnaMarka { get; set; }
        public string Velicina { get; set; }

        public KlijentObuca(int proizvodId, String naziv, String opis, double cijena, int kolicinaNaStanju, String boja, String pol, String robnaMarka, String velicina)
        {
            this.ProizvodId = proizvodId;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Cijena = cijena;
            this.KolicinaNaStanju = kolicinaNaStanju;
            this.Boja = boja;
            this.Pol = pol;
            this.RobnaMarka = robnaMarka;
            this.Velicina = velicina;
        }

        public int GetProizvodId() { return this.ProizvodId; }
    }

    
}
