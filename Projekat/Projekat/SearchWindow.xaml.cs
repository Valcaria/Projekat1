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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using Projekat.Properties;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
        string maticniBroj = "";
        string maticni = "";
        string brSobeStaro = "";
        string domStaro = "";
        string paviljonStaro = "";
        string brSobe = "";
        string dom = "";
        string paviljon= "";
        string baza = "";

        public SearchWindow(string maticni, string dom, string paviljon, string brSobe)
        {
            InitializeComponent();

            baza = "select * from studenti";
            this.dom = dom;
            this.paviljon= paviljon;
            this.brSobe = brSobe;
            this.maticni = maticni;

            searchPom("T");
            FillDataGrid();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcherTimer.Start();

        }

        public SearchWindow()
        {
            InitializeComponent();

            try
            {
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand("select ID, IME,PREZIME,MATICNI_BROJ from arhiva", conn);
                MySqlDataAdapter sAdapter = new MySqlDataAdapter(command);
                sAdapter.Fill(dG);
                dtgPretraga.ItemsSource = dG.DefaultView;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska: " + e.Message.ToString());
            }

            baza = "select * from arhiva";
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (dtgPretraga.SelectedItem != null)
            {
                btnDodaj.IsEnabled = true;
            }
            else
            {
                btnDodaj.IsEnabled = false;
            }
        }
        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {
            searchPom("T");
            int pom = 1;
            if(maticni == "")
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(baza, conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    Settings.Default.ime = rReader[1].ToString();
                    Settings.Default.prezime = rReader[2].ToString();
                    if ((Settings.Default.ime == txtPretraga.Text || Settings.Default.prezime == txtPretraga.Text || (Settings.Default.ime + " " + Settings.Default.prezime) == txtPretraga.Text))
                    {
                        if (baza == "select * from studenti" && dom == rReader[6].ToString() && paviljon == rReader[7].ToString() && brSobe == rReader[8].ToString())
                        {
                            pom = 0;
                        }
                        pom++;
                        if (pom != 0)
                        {
                            maticniBroj = rReader[3].ToString();
                            searchPom("U");
                        }
                        
                    }
                }
                conn.Close();              
            }
            else if(maticni != "")
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from studenti", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    Settings.Default.ime = rReader[1].ToString();
                    Settings.Default.prezime = rReader[2].ToString();
                
                    if ((Settings.Default.ime == txtPretraga.Text || Settings.Default.prezime == txtPretraga.Text || (Settings.Default.ime + " " + Settings.Default.prezime) == txtPretraga.Text) && maticniBroj != rReader[3].ToString() && rReader[9].ToString() == "Hrana i soba")
                    {
                        if(dom == rReader[6].ToString() && paviljon == rReader[7].ToString() && brSobe == rReader[8].ToString())
                        {
                            pom = 0;
                        }
                        if(pom != 0)
                        {
                            maticniBroj = rReader[3].ToString();
                            searchPom("U");
                        }
                        pom++;
                    }
                }
                conn.Close();
            }
            FillDataGrid();
            searchPom("T");
        }
        private void FillDataGrid()
        {
            try
            {
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand("select IME, prezime,maticni_broj from search", conn);
                MySqlDataAdapter sAdapter = new MySqlDataAdapter(command);
                sAdapter.Fill(dG);
                dtgPretraga.ItemsSource = dG.DefaultView;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska: " + e.Message.ToString());
            }
        }
        
        void searchPom(string character)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            if (character == "U")
            {
                MySqlCommand cmd = new MySqlCommand("INSERT into search(ime, prezime,maticni_broj) VALUES('" + Settings.Default.ime + "', '" + Settings.Default.prezime +"', '" + maticniBroj + "')", conn);
                cmd.ExecuteNonQuery();
            }
            else if(character == "T")
            {
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE search",conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPretraga.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dtgPretraga.SelectedItem;

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from studenti", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    if (rReader[3].ToString() == dataRow.Row.ItemArray[3].ToString())
                    {
                        domStaro = rReader[6].ToString();
                        paviljonStaro = rReader[7].ToString();
                        brSobeStaro = rReader[8].ToString();
                    }
                }
                if (maticni != "")
                {
                    Projekat.Properties.Settings.Default.imePrezime = dataRow.Row.ItemArray[1].ToString();
                    Projekat.Properties.Settings.Default.dom = domStaro;
                    Projekat.Properties.Settings.Default.paviljon = paviljonStaro;
                    Projekat.Properties.Settings.Default.soba = brSobeStaro;
                    Projekat.Properties.Settings.Default.maticni = dataRow.Row.ItemArray[2].ToString();
                }
                conn.Close();

                if (maticni == "")
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE studenti SET dom = REPLACE(dom, '" + domStaro + "', '" + (dom) + "'), paviljon = REPLACE(paviljon, '" + paviljonStaro + "','" + paviljon + "'), soba = REPLACE(soba, '" + brSobeStaro + "','" + brSobe + "') where maticni_broj = '" + dataRow.Row.ItemArray[3].ToString() + "'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    promjenaNoveSobe(dom, paviljon, brSobe);
                    promjenaStareSobe(domStaro, paviljonStaro, brSobeStaro);
                }

                this.Close();
            }
        }

        void promjenaNoveSobe(string dom, string paviljon, string brSobe)
        {
            int brSlobodnihSoba = 0;
            MySqlConnection conn = new MySqlConnection(connstr);
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
            conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobodnihSoba + "', '" + (brSlobodnihSoba - 1) + "') WHERE SOBA ='" + brSobe + "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        void promjenaStareSobe(string dom, string paviljon, string brSobe)
        {
            int brSlobodnihSoba = 0;
            MySqlConnection conn = new MySqlConnection(connstr);
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
            conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobodnihSoba + "', '" + (brSlobodnihSoba + 1) + "') WHERE SOBA ='" + brSobe + "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
