﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class AkcjePacjentow
    {
        static AkcjePacjentow()
        {
            ListaPacjentow = new List<Pacjent>();
            PacjentOperacyjny = null;
        }

        public static List<Pacjent> ListaPacjentow { get; private set; }
        /// <summary>
        /// Wybrany pacjent, na którym można wykonywać dalsze operacje
        /// </summary>
        public static Pacjent PacjentOperacyjny { get; private set; }


        /// <summary>
        /// Dodaje pacjenta do globalnej listy pacjentów
        /// </summary>
        /// <param name="iPacjent"></param>
        public static void DodajPacjenta(Pacjent iPacjent)
        {
            ListaPacjentow.Add(iPacjent);
        }

        /// <summary>
        /// Zwraca liczbę pacjentów, (n-1) może być używane do indeksowania []
        /// </summary>
        /// <returns></returns>
        public static int IlePacjentow()
        {
            return ListaPacjentow.Count();
        }

        /// <summary>
        /// Czyści listę pacjentów, zwykle przed SELECTEM
        /// </summary>
        public static void WyczyscListePacjentow()
        {
            ListaPacjentow.Clear();
        }

        /// <summary>
        /// Wybiera jednego pacjenta (operacyjnego), na którym można wykonywać dalsze operacje
        /// </summary>
        /// <param name="iPacjent"></param>
        public static void WybierzPacjentaOperacyjnego(Pacjent iPacjent)
        {
            PacjentOperacyjny = iPacjent;
        }

        /// <summary>
        /// Czy istnieje pacjent operacyjny?
        /// </summary>
        /// <returns></returns>
        public static bool CzyIstniejePacjentOperacyjny()
        {
            if (PacjentOperacyjny == null)
                return false;
            return true;
        }

        /// <summary>
        /// czyści aktualnie wybranego pacjenta
        /// </summary>
        public static void WyczyscWybranegoPacjenta()
        {
            PacjentOperacyjny = null;
        }
    }
}
