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
        public static string StworzSelectaPacjentow(params WhereParams[] iParamsList)
        {
            bool jest = false;
            string select = "";
            string where = "";

            for (int i = 0; i < iParamsList.Length; i++)
            {
                if(iParamsList[i].GetParams() != "")
                {
                    if (jest) { select += " and"; }
                    select += iParamsList[i].GetParams();
                    jest = true;
                }
            }
            
            if (jest) { where = " where" + select; }

            return "SELECT imie, nazwisko, adres, email FROM pacjent " + where + ";";
        }


        /// <summary>
        /// Wykonuje iSelecta na bazie, zwraca MySqlDataReader z wynikami
        /// </summary>
        /// <param name="iSelect"></param>
        public static MySqlDataReader WykonajSelecta(string iSelect)
        {
            MySqlDataReader readerToReturn;

            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            con.Open();

            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = iSelect;
                readerToReturn = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {/*
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }*/
            }
            //no i chuj, żeby zamknąć połączenie trzeba tutaj wjebać delegata
            return readerToReturn;
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
