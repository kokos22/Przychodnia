using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Przychodnia
{
    static class TworzenieZapytan
    {
        //static TworzenieZapytan() { };

        /// <summary>
        /// Zwykłe tworzenie selecta pacjentów, zwraca całego selecta
        /// </summary>
        /// <param name="iImie"></param>
        /// <param name="iNazwisko"></param>
        /// <param name="iAdres"></param>
        /// <param name="iEmail"></param>
        /// <returns></returns>
        public static string StworzSelectaPacjentow(string iImie, string iNazwisko, string iAdres, string iEmail)
        {
            bool jest = false;
            string select = "";
            string where = "";
            if(iImie != "")
            {
                select += " imie = '" + iImie + "'";
                jest = true;
            }
            if(iNazwisko != "")
            {
                if (jest)
                {
                    select += " and";
                }
                select += " nazwisko = '" + iNazwisko + "'";
                jest = true;
            }
            if(iAdres != "")
            {
                if(jest)
                {
                    select += " and";
                }
                select += " adres = '" + iAdres + "'";
                jest = true;
            }

            if(iEmail != "")
            {
                if(jest)
                {
                    select += " and";
                }
                select += " email = '" + iEmail + "'";
                jest = true;
            }

            if (jest) { where = " where" + select; }

            return "SELECT imie, nazwisko, adres, email FROM pacjent " + where + ";";
        }


        /// <summary>
        /// Wrzuca do globalnej listy pacjentów wyszukanych iSelectem
        /// </summary>
        /// <param name="iSelect"></param>
        public static void WykonajSelectaPacjentow(string iSelect)
        {
            AkcjePacjentow.WyczyscListePacjentow();
            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            con.Open();

            try
            {
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = iSelect;

                MySqlDataReader reader = cmd.ExecuteReader();


                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    //Dodaje pacjentów do globalnej listy pacjentów, z której można potem
                    //wybrać jednego pacjenta
                    Pacjent p = new Pacjent(AkcjePacjentow.IlePacjentow(), reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    AkcjePacjentow.DodajPacjenta(p);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Tworzy selecta loginu
        /// </summary>
        /// <param name="iLogin"></param>
        /// <returns></returns>
        public static string StworzSelectaLoginu(string iLogin)
        {
            return  "SELECT login, haslo FROM user WHERE login = " + iLogin + ";";
        }
    }
}
