using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDodajPacjenta_Click(object sender, RoutedEventArgs e)
        {
            AkcjePacjentow.DodajPacjenta(new Pacjent(AkcjePacjentow.IlePacjentow(), txtImie.Text, txtNazwisko.Text, txtAdres.Text, txtEmail.Text));
            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "insert into pacjent (imie, nazwisko, adres, email) values (@imie, @nazwisko, @adres, @email);";
                cmd.Parameters.AddWithValue("@imie", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Imie);
                cmd.Parameters.AddWithValue("@nazwisko", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Nazwisko);
                cmd.Parameters.AddWithValue("@adres", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Adres);
                cmd.Parameters.AddWithValue("@email", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            
            con.Close();
        }

        private void btnSzukajPacjenta_Click(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "Szukanie...";
            TworzenieZapytan.WykonajSelectaPacjentow(TworzenieZapytan.StworzSelectaPacjentow(txtImie.Text, txtNazwisko.Text, txtAdres.Text, txtEmail.Text));
        }

        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            Uzytkownik.SprawdzHaslo(txtNazwaUzytkownika.Text, txtHaslo.Password);
        }

        //jakoś tak:
        /*
        tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            //validate the current page, to cancel the select use:
            e.Cancel = true;
        }
        */

    }
}
