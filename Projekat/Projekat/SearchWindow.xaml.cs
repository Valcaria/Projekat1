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
        public string maticni = "";
        string brSobeStaro = "";
        string domStaro = "";
        string paviljonStaro = "";
        string brSobe = "";
        string dom = "";
        string paviljon= "";
        string baza = "";
        public string adresa = "";
        public string ime = "";
        public string prezime = "";
        public string brTelefona = "";
        string[] filterString = { "", "", "", "", "", "", "", "" };
        string pom = "";
        public SearchWindow(string maticni, string dom, string paviljon, string brSobe)
        {
            InitializeComponent();

            this.dom = dom;
            this.paviljon= paviljon;
            this.brSobe = brSobe;
            this.maticni = maticni;


            FillDataGrid("SELECT DISTINCT MATICNI_BROJ, IME, PREZIME from studenti");

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcherTimer.Start();

            baza = "select * from studenti";

        }

        public SearchWindow(string pom, string[] naredba)
        {
            InitializeComponent();
            this.pom = pom;
            for (int i = 0; i < filterString.Length; i++)
            {
                filterString[i] = String.Copy(naredba[i]);
            }
            try
            {
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand("select DISTINCT MATICNI_BROJ, IME, PREZIME from arhiva"+Settings.Default.naredba, conn);
                MySqlDataAdapter sAdapter = new MySqlDataAdapter(command);
                sAdapter.Fill(dG);
                dtgPretraga.ItemsSource = dG.DefaultView;
                conn.Close();

                baza = "select * from arhiva";
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska: " + e.Message.ToString());
            }
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
           if(baza == "select * from studenti")
            {
                FillDataGrid("SELECT DISTINCT MATICNI_BROJ, IME, PREZIME FROM studenti WHERE concat(concat(IME,' '),PREZIME) like '%" + txtPretraga.Text + "%' OR concat(concat(PREZIME,' '),IME) like '%" + txtPretraga.Text + "%'");
            }
            else
            {
                FillDataGrid("SELECT DISTINCT MATICNI_BROJ, IME, PREZIME FROM arhiva WHERE concat(concat(IME,' '),PREZIME) like '%" + txtPretraga.Text + "%' OR concat(concat(PREZIME,' '),IME) like '%" + txtPretraga.Text + "%'");
            }
        }
        private void FillDataGrid(string komanda)
        {
            try
            {
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand(komanda, conn);
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

        private bool IzbaciDuplikat(int ID, string maticni)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            MySqlCommand command = new MySqlCommand("select * from arhiva", conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if(Convert.ToInt32(reader[0].ToString()) <ID && maticni == reader[3].ToString())
                {
                    return true;
                }
            }

                conn.Close();
            return false;
        }
        
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPretraga.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dtgPretraga.SelectedItem;

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(baza, conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    if (rReader[3].ToString() == dataRow.Row.ItemArray[0].ToString())
                    {
                        if(baza == "select * from arhiva" && pom != "arhiva")
                        {
                            AddWindow add = new AddWindow("", rReader[1].ToString(), rReader[2].ToString(), rReader[3].ToString(), rReader[4].ToString(), rReader[5].ToString(), "", "", "", "", "", "", "");
                            this.Close();
                            add.ShowDialog();
                        }
                        else if(baza == "select * from arhiva" && pom =="arhiva")
                        {
                            maticni = rReader[3].ToString();
                            ime = rReader[1].ToString();
                            prezime = rReader[2].ToString();
                            adresa = rReader[4].ToString();
                            brTelefona = rReader[5].ToString();
                        }
                        if(baza == "select * from studenti" && rReader[9].ToString() == "Hrana")
                        {
                            PromjeniUslugu(dataRow.Row.ItemArray[0].ToString());
                        }
                        domStaro = rReader[6].ToString();
                        paviljonStaro = rReader[7].ToString();
                        brSobeStaro = rReader[8].ToString();
                        
                    }
                }

                conn.Close();
                if (baza == "select * from studenti")
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE studenti SET dom = REPLACE(dom, '" + domStaro + "', '" + (dom) + "'), paviljon = REPLACE(paviljon, '" + paviljonStaro + "','" + paviljon + "'), soba = REPLACE(soba, '" + brSobeStaro + "','" + brSobe + "') where maticni_broj = '" + dataRow.Row.ItemArray[0].ToString() + "'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    promjenaNoveSobe(dom, paviljon, brSobe);
                    promjenaStareSobe(domStaro, paviljonStaro, brSobeStaro);
                }
                Settings.Default.close = 3;
                this.Close();
            }
        }
        void PromjeniUslugu(string maticniBroj)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand("UPDATE studenti SET USLUGA = 'Hrana i soba', DOM = '"+dom+"', PAVILJON = '"+paviljon+"', SOBA = '"+brSobe+ "' WHERE  MATICNI_BROJ='"+maticniBroj+"'", conn);
                command.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greska pri UPDATE u bazi: "+error.Message.ToString());
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

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            if (maticni != "")
            {
                Filtar filter = new Filtar(filterString);
                filter.ShowDialog();
                Settings.Default.naredba = filter.naredba;
                FillDataGrid("SELECT DISTINCT MATICNI_BROJ, IME, PREZIME FROM studenti WHERE concat(concat(IME,' '),PREZIME) like '%" + txtPretraga.Text + "%' OR concat(concat(PREZIME,' '),IME) like '%" + txtPretraga.Text + "%'" + filter.naredba);
                for (int i = 0; i < filterString.Length; i++)
                {
                    filterString[i] = String.Copy(filter.prvaNaredba[i]);
                }
            }
            else
            {
                Filtar filter = new Filtar(filterString);
                filter.ShowDialog();
                Settings.Default.naredba = filter.naredba;
                FillDataGrid("SELECT DISTINCT MATICNI_BROJ, IME, PREZIME FROM arhiva WHERE concat(concat(IME,' '),PREZIME) like '%" + txtPretraga.Text + "%' OR concat(concat(PREZIME,' '),IME) like '%" + txtPretraga.Text + "%'" + filter.naredba);
                for (int i = 0; i < filterString.Length; i++)
                {
                    filterString[i] = String.Copy(filter.prvaNaredba[i]);
                }
            }
        }
    }
}
