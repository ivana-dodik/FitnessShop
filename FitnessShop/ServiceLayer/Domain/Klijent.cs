using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Domain
{
    public class Klijent
    {

        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public string BrojTelefona { get; set; }
        public string AdresaStanovanja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Aktivan { get; set; }
        public bool MailPretplatnik { get; set; }


        public Klijent(int klijentId, string ime, string prezime, string mail, string brojTelefona, string adresaStanovanja, DateTime datumRodjenja, bool aktivan, bool mailPretplatnik)
        {
            KlijentId1 = klijentId;
            Ime = ime;
            Prezime = prezime;
            Mail = mail;
            BrojTelefona = brojTelefona;
            AdresaStanovanja = adresaStanovanja;
            DatumRodjenja = datumRodjenja;
            Aktivan = aktivan;
            MailPretplatnik = mailPretplatnik;
        }

        public int KlijentId1 { get => KlijentId; set => KlijentId = value; }

        public override string ToString()
        {
            return "Klijent ID: " + KlijentId1 + "\n\n" +
                    "Ime: " + Ime + "\n\n" +
                    "Prezime: " + Prezime + "\n\n" +
                    "Mail: " + Mail + "\n\n" +
                    "Broj telefona: " + BrojTelefona + "\n\n" +
                    "Adresa stanovanja: " + AdresaStanovanja + "\n\n" +
                    "Datum rodjenja: " + DatumRodjenja.ToString("dd/MM/yyyy") + "\n\n" +
                    "Aktivan: " + (Aktivan ? "Da" : "Ne") + "\n\n" +
                    "Mail pretplatnik: " + (MailPretplatnik ? "Da" : "Ne");
        }
    }
}
