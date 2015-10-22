﻿using System;
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
            GlobalVars.DodajPacjenta(new Pacjent(GlobalVars.IlePacjentow(), txtImie.Text, txtNazwisko.Text, txtAdres.Text, txtEmail.Text));
            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            con.Open();
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "insert into pacjent (imie, nazwisko, adres, email) values (@imie, @nazwisko, @adres, @email);";
                cmd.Parameters.AddWithValue("@imie", GlobalVars.ListaPacjentow[GlobalVars.IlePacjentow() - 1].Imie);
                cmd.Parameters.AddWithValue("@nazwisko", GlobalVars.ListaPacjentow[GlobalVars.IlePacjentow() - 1].Nazwisko);
                cmd.Parameters.AddWithValue("@adres", GlobalVars.ListaPacjentow[GlobalVars.IlePacjentow() - 1].Adres);
                cmd.Parameters.AddWithValue("@email", GlobalVars.ListaPacjentow[GlobalVars.IlePacjentow() - 1].Email);
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
            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            con.Open();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT imie, nazwisko FROM pacjent;";
                MySqlDataReader reader = cmd.ExecuteReader();
                

                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                    //sb.Append(reader.GetChar(0).ToString());

                    lbl1.Content += reader.GetString(0) + " " + reader.GetString(1);
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
