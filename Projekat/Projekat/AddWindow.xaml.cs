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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        string id = "";
        string godina = "";
        string buttonChecker = "off";
        string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
        string brSobe = "";
        string dom = "";
        string paviljon = "";

        public AddWindow()
        {
            InitializeComponent();
            datePicker();
        }
        void datePicker()
        {
            DateTime now = DateTime.Now;
            if (now.Month < 9)
            {
                godina = Convert.ToString(now.Year - 1) + "/" + Convert.ToString(now.Year);
                dpDatumZaduzivanja.DisplayDateStart = new DateTime((now.Year-1),9,1);
                dpDatumZaduzivanja.DisplayDateEnd = new DateTime((now.Year), 7, 15);
                txtGodina.Text = godina;
            }
            else
            {
                godina = Convert.ToString(now.Year) + "/" + Convert.ToString(now.Year + 1);
                dpDatumZaduzivanja.DisplayDateStart = new DateTime((now.Year), 8, 31);
                dpDatumZaduzivanja.DisplayDateEnd = new DateTime((now.Year + 1), 7, 15);
                txtGodina.Text = godina;
            }
        }
        void connectionSobe()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                int i = 1, slobSobe = 0;
                if(buttonChecker == "off")
                {
                    cmbSoba.Items.Clear();
                    while (rReader.Read())
                    {
                        if (cmbDom.Text == "2")
                        {
                            if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == rReader[2].ToString())
                            {
                                try
                                {
                                    slobSobe = Convert.ToInt32(rReader[5].ToString());
                                    if (slobSobe != 0)
                                        cmbSoba.Items.Add(i);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show("Greska: " + error.Message.ToString());
                                }
                                i++;
                            }
                        }
                        else if (cmbDom.Text == "1")
                        {
                            if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == "M" && cmbPaviljon.Text == rReader[2].ToString())
                            {
                                try
                                {
                                    slobSobe = Convert.ToInt32(rReader[5].ToString());
                                    if (slobSobe != 0)
                                        cmbSoba.Items.Add(i);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show("Greska: " + error.Message.ToString());
                                }
                            }
                            else if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == "Z" && cmbPaviljon.Text == rReader[2].ToString())
                            {
                                try
                                {
                                    slobSobe = Convert.ToInt32(rReader[5].ToString());
                                    if (slobSobe != 0)
                                        cmbSoba.Items.Add(i);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show("Greska: " + error.Message.ToString());
                                }
                            }
                            i++;
                        }
                    }
                }
                else if (buttonChecker == "on")
                {
                    while (rReader.Read())
                    {
                        if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == rReader[2].ToString() && cmbSoba.Text == rReader[3].ToString())
                        {
                            try
                            {
                                slobSobe = Convert.ToInt32(rReader[5].ToString());
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
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + slobSobe + "', '" + (slobSobe - 1) + "') WHERE SOBA ='" + cmbSoba.Text + "' AND DOM = '"+cmbDom.Text+"' AND PAVILJON = '"+cmbPaviljon.Text+"'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                rReader.Close();
                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greska: " + error.Message.ToString());
            }
        }

        public AddWindow(string id, string ime, string prezime, string maticni_br, string mjesto_stan, string br_telefona, string dom, string paviljon, string soba, string usluga, string fakultet, string godina, string komentar)
        {
            
            InitializeComponent();
            //datePicker();
            brSobe = soba;
            this.dom = dom;
            this.paviljon = paviljon;
            int pom = 0;

            btnDodaj.Content = "Izmijeni";
            txtIme.Text = ime;
            txtPrezime.Text = prezime;
            txtKomentar.Text = komentar;
            txtMaticni_Broj.Text = maticni_br;
            txtMjesto_Stanovanja.Text = mjesto_stan;
            txtBroj_Telefona.Text = br_telefona;
            
            this.id = id;
            switch(dom)
            {
                case "1":
                    cmbDom.SelectedIndex = 0;
                    break;
                case "2":
                    cmbDom.SelectedIndex = 1;
                    break;
                case "":
                    cmbDom.IsEnabled = false;
                    break;
            }            
            switch(fakultet)
            {
                case "ETF":
                    cmbFakultet.SelectedIndex = 0;
                    break;
                case "MAK":
                    cmbFakultet.SelectedIndex = 1;
                    break;
                case "MAF":
                    cmbFakultet.SelectedIndex = 2;
                    break;
                case "POF":
                    cmbFakultet.SelectedIndex = 3;
                    break;
            }
            switch(godina)
            {
                case "1":
                    cmbGodina.SelectedIndex = 0;
                    break;
                case "2":
                    cmbGodina.SelectedIndex = 1;
                    break;
                case "3":
                    cmbGodina.SelectedIndex = 2;
                    break;
                case "4":
                    cmbGodina.SelectedIndex = 3;
                    break;
            }
            switch(paviljon)
            {
                case "M":
                    cmbPaviljon.SelectedIndex = 0;
                    break;
                case "Z":
                    cmbPaviljon.SelectedIndex = 1;
                    break;
                case "":
                    cmbPaviljon.IsEnabled = false;
                    break;
            }
            if (usluga == "Hrana i soba")
            {
                cmbUsluga.SelectedIndex = 0;
                if (cmbDom.Text != "" && cmbPaviljon.Text != "")
                    connectionSobe();
                pom = Convert.ToInt32(soba);
                cmbSoba.SelectedIndex = pom - 1;
                if (cmbPaviljon.Text == "Z" && cmbDom.Text == "1")
                    cmbSoba.SelectedIndex = pom - 10;
            }
            else if (usluga == "Hrana")
            {
                cmbUsluga.SelectedIndex = 1;
                cmbSoba.IsEnabled = false;
            }
            dpDatumZaduzivanja.SelectedDate = Convert.ToDateTime(Settings.Default.datum);
            dpDatumZaduzivanja.Text = Convert.ToString(Convert.ToDateTime(Settings.Default.datum));
            //MessageBox.Show(Convert.ToString(dpDatumZaduzivanja.SelectedDate));
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            buttonChecker = "on";
            if (id == "")
            {
                Settings.Default.datum = dpDatumZaduzivanja.SelectedDate.Value.Year + "-" + dpDatumZaduzivanja.SelectedDate.Value.Month + "-" + dpDatumZaduzivanja.SelectedDate.Value.Day.ToString();
                MessageBox.Show(Settings.Default.datum);
                if (cmbUsluga.Text == "Hrana i soba")
                {
                    if (txtIme.Text != "" && txtPrezime.Text != "" && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbSoba.Text != "" && cmbPaviljon.Text != "" && cmbUsluga.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                    {
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(connstr);
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ime,prezime,maticni_broj, mjesto_stanovanja, broj_telefona, dom, paviljon, soba, usluga,DATUM_ZADUZIVANJA, godina_upotrebe, fakultet, godina, komentar) VALUES('" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtMaticni_Broj.Text + "', '" + txtMjesto_Stanovanja.Text + "', '" + txtBroj_Telefona.Text + "', '" + cmbDom.Text + "', '" + cmbPaviljon.Text + "', '" + cmbSoba.Text + "', '" + cmbUsluga.Text + "', '" + (Settings.Default.datum) + "','" + txtGodina.Text + "', '" + cmbFakultet.Text + "', '" + cmbGodina.Text + "', '" + txtKomentar.Text + "')", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            this.Close();
                            connectionSobe();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Greska: " + error.Message.ToString());
                        }
                    }
                }
                else if(cmbUsluga.Text == "Hrana")
                {
                    if (txtIme.Text != "" && txtPrezime.Text != "" && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != ""  && cmbUsluga.Text != ""  && cmbFakultet.Text != "" && cmbGodina.Text != "")
                    {   
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(connstr);
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ime,prezime,maticni_broj, mjesto_stanovanja, broj_telefona, usluga,DATUM_ZADUZIVANJA, godina_upotrebe, fakultet, godina, komentar) VALUES('" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtMaticni_Broj.Text + "', '" + txtMjesto_Stanovanja.Text + "', '" + txtBroj_Telefona.Text + "', '" + cmbUsluga.Text + "', '" + (Settings.Default.datum) +  "','"+ txtGodina.Text + "', '" + cmbFakultet.Text + "', '" + cmbGodina.Text + "', '" + txtKomentar.Text + "')", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            this.Close();
                            connectionSobe();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Greska: " + error.Message.ToString());
                        }
                    }
                }
            }
            else
            {
                if (txtIme.Text != "" && txtPrezime.Text != "" && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbSoba.Text != "" && cmbPaviljon.Text != "" && cmbUsluga.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                {
                    try
                    { 
                        MySqlConnection conn = new MySqlConnection(connstr);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET ime = '" + txtIme.Text + "', prezime ='" + txtPrezime.Text + "', maticni_broj ='" + txtMaticni_Broj.Text + "', mjesto_stanovanja ='" + txtMjesto_Stanovanja.Text + "', broj_telefona ='" + txtBroj_Telefona.Text+ "', dom ='" + cmbDom.Text +"',paviljon ='" +cmbPaviljon.Text+"',soba ='" + cmbSoba.Text+ "',usluga ='" + cmbUsluga.Text+ "',godina_upotrebe ='" + txtGodina.Text + "',fakultet = '" + cmbFakultet.Text + "', godina = '" + cmbGodina.Text + "',komentar = '" + txtKomentar.Text + "' where id = " + id + ";", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        if (brSobe != cmbSoba.Text)
                        {
                            connectionSobe();
                            oslobodiSobu();
                        }
                        if (brSobe == cmbSoba.Text)
                            if (dom != cmbDom.Text || paviljon != cmbPaviljon.Text)
                            {
                                connectionSobe();
                                oslobodiSobu();
                            }
                        conn.Close();
                        this.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                }
            }
            
        }
        void oslobodiSobu()
        {
            int brSlobonihSoba = 0;
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
                        brSlobonihSoba = Convert.ToInt32(rReader[5].ToString());
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
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobonihSoba + "', '" + (brSlobonihSoba + 1) + "') WHERE SOBA ='" + brSobe + "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        private void cmbPaviljon_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbDom.Text != "")
            {
                connectionSobe();
            }
        }

        private void cmbDom_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbPaviljon.Text != "")
            {
                connectionSobe();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WorkingWindow working = new WorkingWindow("s");
            working.ShowDialog();
        }

        private void cmbUsluga_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbUsluga.Text == "Hrana")
            {
                cmbDom.IsEnabled = false;
                cmbPaviljon.IsEnabled = false;
                cmbSoba.IsEnabled = false;
            }
            else if(cmbUsluga.Text == "Hrana i soba")
            {
                cmbDom.IsEnabled = true;
                cmbPaviljon.IsEnabled = true;
                cmbSoba.IsEnabled = true;
            }
        }

        private void dpDatumZaduzivanja_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dpDatumZaduzivanja.Text = dpDatumZaduzivanja.SelectedDate.ToString();
        }
    }
}
