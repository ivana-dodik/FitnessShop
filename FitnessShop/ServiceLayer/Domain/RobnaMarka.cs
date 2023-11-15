using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    public class RobnaMarka
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int BrojProizvoda { get; set; }

        public RobnaMarka(int id, string naziv, string opis, int brojProizvoda)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.BrojProizvoda = brojProizvoda;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
