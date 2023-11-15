using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    class KlijentHrana
    {
        readonly int ProizvodId;
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int KolicinaNaStanju { get; set; }
        public string RobnaMarka { get; set; }
        public string HranljiveVrijednosti { get; set; }

        public KlijentHrana(int proizvodId, String naziv, String opis, double cijena, int kolicinaNaStanju, String robnaMarka, String hranljiveVrijednosti)
        {
            this.ProizvodId = proizvodId;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Cijena = cijena;
            this.KolicinaNaStanju = kolicinaNaStanju;
            this.RobnaMarka = robnaMarka;
            this.HranljiveVrijednosti = hranljiveVrijednosti;
        }

        public int GetProizvodId() { return this.ProizvodId; }

    }
}
