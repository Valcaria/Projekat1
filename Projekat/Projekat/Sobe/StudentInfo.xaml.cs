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
using Projekat.Properties;
using MySql.Data.MySqlClient;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : UserControl
    {
        public StudentInfo()
        {
            InitializeComponent();
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from studenti", conn);
                MySqlDataReader rReader = command.ExecuteReader();
                while (rReader.Read())
                {
                    if (Settings.Default.maticni == rReader[3].ToString())
                    {
                        lblImePrezime.Content = "Student: " + Settings.Default.imePrezime + "\nMaticni broj: " + Settings.Default.maticni + "\nBroj Telefona:" + rReader[5].ToString() + "\nDatum zaduzenja:\n" + DateTime.Parse(rReader[10].ToString()).ToShortDateString();
                    }
                }
                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }

            btnZamjena.Content = "Promjeni sobu";
        }

        public StudentInfo(string dom, string paviljon)
        {
            InitializeComponent();
            lblInfo.Content = "Soba broj: "+ Settings.Default.soba;

            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from sobe", conn);
                MySqlDataReader rReader = command.ExecuteReader();
                while (rReader.Read())
                {
                    if (dom == rReader[1].ToString() && paviljon == rReader[2].ToString() && Settings.Default.soba == rReader[3].ToString())
                    {
                        lblImePrezime.Content = "\nUkupno kreveta:\t" + rReader[4].ToString() + "\nSlobodni kreveti:\t" + rReader[5].ToString();
                    }
                }
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }

            Settings.Default.dom = dom;
            Settings.Default.paviljon = paviljon;
            btnZamjena.Content = "Pretraga";
            Settings.Default.maticni = "";
        }

        private void btnZamjena_Click(object sender, RoutedEventArgs e)
        {
            if(btnZamjena.Content.ToString() == "Promjeni sobu")
            {
                Settings.Default.close = 0;
                Settings.Default.pom = "on";
                Settings.Default.promjena = "Izaberite sobu";

            }
            else if(btnZamjena.Content.ToString() == "Pretraga")
            {
                SearchWindow searchWindow = new SearchWindow("", Settings.Default.dom, Settings.Default.paviljon, Settings.Default.soba);
                searchWindow.Show();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.maticni = "";
            Settings.Default.pom = "off";
            Settings.Default.close = 3;
        }
    }
}
