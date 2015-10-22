using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class TworzenieZapytan
    {
        //static TworzenieZapytan() { };

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
            return where;
        }
    }
}
