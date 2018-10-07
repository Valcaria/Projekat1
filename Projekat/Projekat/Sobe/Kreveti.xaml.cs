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
using Projekat.Properties;
using MySql.Data.MySqlClient;
namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for Kreveti.xaml
    /// </summary>
    public partial class Kreveti : UserControl
    {
        string soba = "";
        string dom = "";
        string paviljon = "";
        string maticni = "";
        public Kreveti(string color, string stanje, string dom, string paviljon, string brSobe, string maticni)
        {
            InitializeComponent();
            if (color == "R")
            {
                grbColor.Background = Brushes.Red;
                lblIme.Content = stanje;
            }
            else if (color == "G")
            {
                grbColor.Background = Brushes.Green;
                lblIme.Content = stanje;
            }
            else if (color == "Gr")
            {
                grbColor.Background = Brushes.Gray;
                lblIme.Content = stanje;
            }

            soba = brSobe;
            this.paviljon = paviljon;
            this.dom = dom;
            this.maticni = maticni;
        }
        private void grbColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(grbColor.Background == Brushes.Green && Settings.Default.pom == "off")
            {
                Settings.Default.soba = soba;
                Settings.Default.close = 4;
                Settings.Default.maticni = "";
            }
            else if(grbColor.Background == Brushes.Red && Settings.Default.pom == "off")
            {
                Settings.Default.maticni = maticni;
                Settings.Default.imePrezime = lblIme.Content.ToString();
                Settings.Default.dom = dom;
                Settings.Default.paviljon = paviljon;
                Settings.Default.soba = soba;
                Settings.Default.close = 2;
            }
            else if(grbColor.Background == Brushes.Green && Settings.Default.pom == "on")
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET dom = REPLACE(dom, '" + Settings.Default.dom + "', '" + (dom) + "'), paviljon = REPLACE(paviljon, '" + Settings.Default.paviljon + "','" + paviljon + "'), soba = REPLACE(soba, '" + Settings.Default.soba + "','" + soba + "') where maticni_broj = '" + Settings.Default.maticni + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                Settings.Default.pom = "off";
                promjenaNoveSobe(dom, paviljon, soba);
                promjenaStareSobe(Settings.Default.dom, Settings.Default.paviljon, Settings.Default.soba);
                CleanIT();
                Settings.Default.close = 3;
            }
            else if(grbColor.Background == Brushes.Red && Settings.Default.pom == "on")
            {
                Zamjena zamjena = new Zamjena(Settings.Default.imePrezime, lblIme.Content.ToString(), Settings.Default.maticni, maticni, Settings.Default.soba, soba, Settings.Default.dom, dom, Settings.Default.paviljon, paviljon);
                zamjena.ShowDialog();
                Settings.Default.pom = "off";
                Settings.Default.close = 3;
            }
        }
        void CleanIT()
        {
            Projekat.Properties.Settings.Default.imePrezime = "";
            Projekat.Properties.Settings.Default.dom = "";
            Projekat.Properties.Settings.Default.paviljon = "";
            Projekat.Properties.Settings.Default.soba = "";
            Projekat.Properties.Settings.Default.maticni = "";
        }
        void promjenaNoveSobe(string dom, string paviljon, string brSobe)
        {
            int brSlobodnihSoba = 0;
            MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
            MySqlDataReader rReader = cmd.ExecuteReader();
            while (rReader.Read())
            {
                if (dom == rReader[1].ToString() && paviljon == rReader[2].ToString() && brSobe == rReader[3].ToString())
                {
                    try
                    {
                        brSlobodnihSoba = Convert.ToInt32(rReader[5].ToString());
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                }
            }
            conn.Close();
            conn = new MySqlConnection(Settings.Default.connstr);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobodnihSoba + "', '" + (brSlobodnihSoba - 1) + "') WHERE SOBA ='" + brSobe + "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        void promjenaStareSobe(string dom, string paviljon, string brSobe)
        {
            int brSlobodnihSoba = 0;
            MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
            MySqlDataReader rReader = cmd.ExecuteReader();
            while (rReader.Read())
            {
                if (dom == rReader[1].ToString() && paviljon == rReader[2].ToString() && brSobe == rReader[3].ToString())
                {
                    try
                    {
                        brSlobodnihSoba = Convert.ToInt32(rReader[5].ToString());
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                }
            }
            conn.Close();
            conn = new MySqlConnection(Settings.Default.connstr);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobodnihSoba + "', '" + (brSlobodnihSoba + 1) + "') WHERE SOBA ='" + brSobe + "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
