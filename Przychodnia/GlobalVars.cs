using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class GlobalVars
    {
        static GlobalVars() { ListaPacjentow = new List<Pacjent>(); }

        public static List<Pacjent> ListaPacjentow { get; private set; }
        
        public static void DodajPacjenta(Pacjent iPacjent)
        {
            ListaPacjentow.Add(iPacjent);
        }

        public static int IlePacjentow()
        {
            return ListaPacjentow.Count();
        }
    }
}
