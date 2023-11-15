using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    class Narudzba
    {
        readonly int Id;
        List<NarudzbaStavka> Stavke;

        public Narudzba(int id, List<NarudzbaStavka> stavke)
        {
            this.Id = id;
            this.Stavke = stavke;
        }

        public List<NarudzbaStavka> GetStavke() { return Stavke; }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Narduzba ID: ").Append(Id).Append("\n");
            sb.Append("Stavke:\n");
            double UkupnaCijena = 0.0;
            foreach (NarudzbaStavka stavka in Stavke)
            {
                sb.Append("[Naziv: ").Append(stavka.GetNaziv()).Append(", Količina: ")
                      .Append(stavka.GetKolicina()).Append(", Cijena: ").Append(stavka.GetCijena())
                      .Append("KM]\n");
                UkupnaCijena += stavka.GetKolicina() * stavka.GetCijena();
            }
            sb.Append("Ukupna cijena: ").Append(UkupnaCijena).Append("KM\n");
            return sb.ToString();
        }
    }
}
