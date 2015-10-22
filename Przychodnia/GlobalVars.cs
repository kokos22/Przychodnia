using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class GlobalVars
    {
        static GlobalVars()
        {
            ListaPacjentow = new List<Pacjent>();
            WybranyPacjent = null;
        }

        public static List<Pacjent> ListaPacjentow { get; private set; }
        public static Pacjent WybranyPacjent { get; private set; }

        public static void DodajPacjenta(Pacjent iPacjent)
        {
            ListaPacjentow.Add(iPacjent);
        }

        public static int IlePacjentow()
        {
            return ListaPacjentow.Count();
        }

        public static void WybierzPacjenta(Pacjent iPacjent)
        {
            WybranyPacjent = iPacjent;
        }

        public static bool CzyWybranyPacjent()
        {
            if (WybranyPacjent == null)
                return false;
            return true;
        }

        public static void WyczyscWybranegoPacjenta()
        {
            WybranyPacjent = null;
        }
    }
}
