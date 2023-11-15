using FitnessShop.ServiceLayer.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessShop.ServiceLayer.Services
{
    internal class NarudzbaServiceImpl : NarudzbaService
    {
        private static readonly string NARUDZBA_QUERY = "SELECT * FROM fitness_shop.narudzba_view WHERE klijent_id = @klijentId";

        public List<Narudzba> GetAllNarudzbe(int klijentId)
        {
            List<Narudzba> narudzbe = new List<Narudzba>();
            using (MySqlConnection connection = DataSource.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand(NARUDZBA_QUERY, connection))
                {
                    command.Parameters.AddWithValue("@klijentId", klijentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        narudzbe.AddRange(MapResultSetToNarudzbaList(reader));
                    }
                }
            }

            return narudzbe;
        }

        public List<Narudzba> MapResultSetToNarudzbaList(MySqlDataReader reader)
        {
            List<Narudzba> narudzbe = new List<Narudzba>();
            Dictionary<int, Narudzba> narudzbaMap = new Dictionary<int, Narudzba>();

            while (reader.Read())
            {
                int narudzbaId = reader.GetInt32("narudzba_id");
                Narudzba narudzba;
                if (!narudzbaMap.TryGetValue(narudzbaId, out narudzba))
                {
                    narudzba = new Narudzba(narudzbaId, new List<NarudzbaStavka>());
                    narudzbaMap.Add(narudzbaId, narudzba);
                    narudzbe.Add(narudzba);
                }

                int proizvodId = reader.GetInt32("proizvod_id");
                int kolicina = reader.GetInt32("kolicina");
                double cijena = reader.GetDouble("cijena");
                string naziv = reader.GetString("naziv");

                NarudzbaStavka stavka = new NarudzbaStavka(naziv, kolicina, cijena);
                narudzba.GetStavke().Add(stavka);
            }

            return narudzbe;
        }

    }
}
