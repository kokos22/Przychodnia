using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    class Pacjent
    {
        public int ID { get; private set; }
        public String Imie { get; private set; }
        public String Nazwisko { get; private set; }
        public int Pesel { get; private set; }
        public String Email { get; private set; }
        public String Adres { get; private set; }
        public int Telefon { get; private set; }
        public int MyProperty { get; private set; }
    }
}
