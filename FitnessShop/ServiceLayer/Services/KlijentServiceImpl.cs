using FitnessShop.ServiceLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FitnessShop.ServiceLayer.Services
{
    class KlijentServiceImpl : KlijentService
    {
        public Klijent Login(string username, string password)
        {
            MySqlConnection connection = DataSource.GetOpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM korisnik_klijent WHERE korisnicko_ime=@username AND lozinka=(@password)", connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Prepare();

            try
            {
                MySqlDataReader res = cmd.ExecuteReader();
                res.Read();
                if (res.HasRows)
                {
                    int korisnikId = res.GetInt32("korisnik_id");
                    String ime = res.GetString("ime");
                    String prezime = res.GetString("prezime");
                    String mail = res.GetString("mail");
                    String brojTelefona = res.GetString("broj_telefona");
                    String adresaStanovanja = res.GetString("adresa_stanovanja");
                    DateTime datumRodjenja = res.GetDateTime("datum_rodjenja").Date;
                    bool aktivan = res.GetBoolean("aktivan");
                    bool mailPretplatnik = res.GetBoolean("mail_pretplatnik");
                    res.Close();
                    return new Klijent(korisnikId, ime, prezime, mail, brojTelefona, adresaStanovanja, datumRodjenja, aktivan, mailPretplatnik);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error!\n" + e.Message);

            }
            finally
            {
                connection.Close();
            }
            return null;

        }
    }
}
