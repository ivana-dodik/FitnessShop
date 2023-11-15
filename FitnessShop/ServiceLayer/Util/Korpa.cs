using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

using FitnessShop.ServiceLayer.Domain;

namespace FitnessShop.ServiceLayer.Util
{
    public class Korpa
    {
        readonly List<KorpaStavka> Stavke;

        public Korpa() { this.Stavke = new List<KorpaStavka>(); }  

        public Korpa(List<KorpaStavka> stavke) { this.Stavke = stavke; }

        public void AddStavka(KorpaStavka stavka) { Stavke.Add(stavka); }

        public void AddStavke(List<KorpaStavka> values)
        {
            Stavke.AddRange(values);
        }

        public List<KorpaStavka> getStavke() { return Stavke; }

        public int Size() { return Stavke.Count(); }

        public void Clear() { Stavke.Clear(); }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var stavka in Stavke)
                sb.Append(stavka).Append('\n');
            return sb.ToString();
        }

        public bool ContainsStavka(int proizvodId)
        {
            foreach (var stavka in Stavke)
            {
                if (stavka.ProizvodId == proizvodId)
                {
                    return true;
                }
            }

            return false;
        }

        public void IncreaseKolicina(int proizvodId)
        {
            foreach (var stavka in Stavke)
            {
                if (stavka.ProizvodId == proizvodId)
                {
                    stavka.IncreaseKolicina();
                }
            }
        }

        public int GetKolicinaForProizvod(int proizvodId)
        {
            foreach (var stavka in Stavke)
            {
                if (stavka.ProizvodId == proizvodId)
                {
                    return stavka.Kolicina;
                }
            }

            return 0;
        }
    }
}
