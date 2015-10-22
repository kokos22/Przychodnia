using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class Uzytkownik
    {
        static Uzytkownik()
        {
            Login = null;
            PoziomDostepu = 0;
        }

        public static string Login { get; private set; }
        public static int PoziomDostepu { get; private set; }
        
        public static bool SprawdzHaslo(string iLogin, string iHaslo)
        {
            //sprawdz haslo

            //ustaw poziom dostepu

            return true;
        }
    }
}
