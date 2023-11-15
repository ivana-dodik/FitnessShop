using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    public class KorpaStavka
    {
        public int ProizvodId { get; set; }
        public int KlijentId { get; set; }
        public int Kolicina { get; set; }
        public string Naziv { get; set; }
 
        public KorpaStavka(int proizvodId, int klijentId, int kolicina, String naziv)
        {
            this.ProizvodId= proizvodId;
            this.KlijentId = klijentId;
            this.Kolicina = kolicina;
            this.Naziv = naziv;
        }

        public void IncreaseKolicina()
        {
            Kolicina++;
        }

        public override String ToString()
        {
            return "KorpaStavka{" +
                  "proizvodId=" + ProizvodId +
                  ", klijentId=" + KlijentId +
                  ", kolicina=" + Kolicina +
                  ", naziv='" + Naziv + '\'' +
                  '}';
        }

       

        
    }
}
