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
        string buttonChecker = "off";

        public AddWindow()
        {
            InitializeComponent();
            datePicker();
            cmbSoba.IsEnabled = false;
        }
        void datePicker()
        {
            string godina = "";
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
        private void ConnectionSobe()
        {
            cmbSoba.IsEnabled = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
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
                                    MessageBox.Show("Greška: " + error.Message.ToString());
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
                                    MessageBox.Show("Greška: " + error.Message.ToString());
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
                                    MessageBox.Show("Greška: " + error.Message.ToString());
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
                                MessageBox.Show("Greška: " + error.Message.ToString());
                            }
                        }
                    }
                    conn.Close();

                    conn = new MySqlConnection(Settings.Default.connstr);
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
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
        }

        public AddWindow(string id, string ime, string prezime, string maticni_br, string mjesto_stan, string br_telefona, string dom, string paviljon, string soba, string usluga, string fakultet, string godina, string komentar)
        {

            InitializeComponent();
            Settings.Default.soba = soba;
            Settings.Default.dom = dom;
            Settings.Default.paviljon = paviljon;
            int pom = 0;

            if (id != "")
            {
                btnDodaj.Content = "Izmijeni";
            }
            txtIme.Text = ime;
            txtPrezime.Text = prezime;
            txtKomentar.Text = komentar;
            txtMaticni_Broj.Text = maticni_br;
            txtMjesto_Stanovanja.Text = mjesto_stan;
            txtBroj_Telefona.Text = br_telefona;
            this.id = id;
            switch (dom)
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
            switch (fakultet)
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
            switch (godina)
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
            switch (paviljon)
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
                {
                    ConnectionSobe();
                }
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
            datePicker();

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            buttonChecker = "on";
            if (id == "" && !ProvjeraDuplikata(txtMaticni_Broj.Text))
                {
                    if (dpDatumZaduzivanja.Text != "")
                        Settings.Default.datum = dpDatumZaduzivanja.SelectedDate.Value.Year + "-" + dpDatumZaduzivanja.SelectedDate.Value.Month + "-" + dpDatumZaduzivanja.SelectedDate.Value.Day.ToString();
                    if (cmbUsluga.Text == "Hrana i soba")
                    {
                        if (txtIme.Text != "" && txtPrezime.Text != "" && dpDatumZaduzivanja.SelectedDate != null && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbSoba.Text != "" && cmbPaviljon.Text != "" && cmbUsluga.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                        {
                            try
                            {
                                int count = Count("SELECT * FROM studenti");
                                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ID,ime,prezime,maticni_broj, mjesto_stanovanja, broj_telefona, dom, paviljon, soba, usluga,DATUM_ZADUZIVANJA, godina_upotrebe, fakultet, godina, komentar) VALUES('" + (count + 1) + "','" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtMaticni_Broj.Text + "', '" + txtMjesto_Stanovanja.Text + "', '" + txtBroj_Telefona.Text + "', '" + cmbDom.Text + "', '" + cmbPaviljon.Text + "', '" + cmbSoba.Text + "', '" + cmbUsluga.Text + "', '" + (Settings.Default.datum) + "','" + txtGodina.Text + "', '" + cmbFakultet.Text + "', '" + cmbGodina.Text + "', '" + txtKomentar.Text + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                this.Close();
                                ConnectionSobe();
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("Greška: " + error.Message.ToString());
                            }
                        }
                    }
                    else if (cmbUsluga.Text == "Hrana")
                    {
                        if (txtIme.Text != "" && txtPrezime.Text != "" && dpDatumZaduzivanja.SelectedDate != null && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbUsluga.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                        {
                            try
                            {
                                int count = Count("SELECT * FROM studenti");

                                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ID,ime,prezime,maticni_broj, mjesto_stanovanja, broj_telefona, usluga,DATUM_ZADUZIVANJA, godina_upotrebe, fakultet, godina, komentar) VALUES('" + (count + 1) + "','" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtMaticni_Broj.Text + "', '" + txtMjesto_Stanovanja.Text + "', '" + txtBroj_Telefona.Text + "', '" + cmbUsluga.Text + "', '" + (Settings.Default.datum) + "','" + txtGodina.Text + "', '" + cmbFakultet.Text + "', '" + cmbGodina.Text + "', '" + txtKomentar.Text + "')", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                this.Close();
                                ConnectionSobe();
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("Greška: " + error.Message.ToString());
                            }
                        }
                    }
                }
            else
                {
                if (dpDatumZaduzivanja.Text != "")
                    Settings.Default.datum = dpDatumZaduzivanja.SelectedDate.Value.Year + "-" + dpDatumZaduzivanja.SelectedDate.Value.Month + "-" + dpDatumZaduzivanja.SelectedDate.Value.Day.ToString();

                if (cmbUsluga.Text == "Hrana i soba")
                    {
                        if (txtIme.Text != "" && txtPrezime.Text != "" && dpDatumZaduzivanja.SelectedDate != null && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbSoba.Text != "" && cmbPaviljon.Text != "" && cmbUsluga.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                        {
                            try
                            {
                                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET ime = '" + txtIme.Text + "', prezime ='" + txtPrezime.Text + "', maticni_broj ='" + txtMaticni_Broj.Text + "', mjesto_stanovanja ='" + txtMjesto_Stanovanja.Text + "', broj_telefona ='" + txtBroj_Telefona.Text + "', dom ='" + cmbDom.Text + "',paviljon ='" + cmbPaviljon.Text + "',soba ='" + cmbSoba.Text + "',usluga ='" + cmbUsluga.Text + "',DATUM_ZADUZIVANJA = '"+ Settings.Default.datum + "',godina_upotrebe ='" + txtGodina.Text + "',fakultet = '" + cmbFakultet.Text + "', godina = '" + cmbGodina.Text + "',komentar = '" + txtKomentar.Text + "' where id = " + id + ";", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                if (Settings.Default.soba != cmbSoba.Text)
                                {
                                    ConnectionSobe();
                                    OslobodiSobu();
                                }
                                if (Settings.Default.soba == cmbSoba.Text)
                                    if (Settings.Default.dom != cmbDom.Text || Settings.Default.paviljon != cmbPaviljon.Text)
                                    {
                                        ConnectionSobe();
                                        OslobodiSobu();
                                    }
                                conn.Close();
                                this.Close();
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("Greška: " + error.Message.ToString());
                            }
                        }
                    }
                    else if (cmbUsluga.Text == "Hrana")
                    {
                        if (txtIme.Text != "" && txtPrezime.Text != "" && dpDatumZaduzivanja.SelectedDate != null && txtMaticni_Broj.Text != "" && txtMjesto_Stanovanja.Text != "" && txtBroj_Telefona.Text != "" && cmbUsluga.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                        {
                            try
                            {
                                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET ime = '" + txtIme.Text + "', prezime ='" + txtPrezime.Text + "', maticni_broj ='" + txtMaticni_Broj.Text + "', mjesto_stanovanja ='" + txtMjesto_Stanovanja.Text + "', broj_telefona ='" + txtBroj_Telefona.Text + "', dom ='" + cmbDom.Text + "',paviljon ='" + cmbPaviljon.Text + "',soba ='" + cmbSoba.Text + "',usluga ='" + cmbUsluga.Text + "',DATUM_ZADUZIVANJA = '" + Settings.Default.datum + "',godina_upotrebe ='" + txtGodina.Text + "',fakultet = '" + cmbFakultet.Text + "', godina = '" + cmbGodina.Text + "',komentar = '" + txtKomentar.Text + "' where id = " + id + ";", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                if (Settings.Default.soba != cmbSoba.Text)
                                {
                                    ConnectionSobe();
                                    OslobodiSobu();
                                }
                                if (Settings.Default.soba == cmbSoba.Text)
                                    if (Settings.Default.dom != cmbDom.Text || Settings.Default.paviljon != cmbPaviljon.Text)
                                    {
                                        ConnectionSobe();
                                        OslobodiSobu();
                                    }
                                conn.Close();
                                this.Close();
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("Greška: " + error.Message.ToString());
                            }
                        }
                    }

                }
            if(cmbUsluga.Text == "Hrana")
            {
                if (txtIme.Text == "" || txtBroj_Telefona.Text == "" || txtMaticni_Broj.Text == "" || txtMjesto_Stanovanja.Text == "" || txtPrezime.Text == "" || cmbFakultet.SelectedItem == null || cmbGodina.SelectedItem == null || cmbUsluga.SelectedItem == null || dpDatumZaduzivanja.Text == "")
                {
                    MessageBox.Show("Potrebno je unijeti sva polja!");
                    buttonChecker = "off";
                }
            }
            else if(cmbUsluga.Text == "Hrana i soba")
            {
                if (txtIme.Text == "" || txtBroj_Telefona.Text == "" || txtMaticni_Broj.Text == "" || txtMjesto_Stanovanja.Text == "" || txtPrezime.Text == "" || cmbDom.SelectedItem == null || cmbFakultet.SelectedItem == null || cmbGodina.SelectedItem == null || cmbPaviljon.SelectedItem == null || cmbSoba.SelectedItem == null || cmbUsluga.SelectedItem == null || dpDatumZaduzivanja.Text == "")
                {
                    MessageBox.Show("Potrebno je unijeti sva polja!");
                    buttonChecker = "off";
                }
            }
        }
        private void OslobodiSobu()
        {
            int brSlobonihSoba = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    if (Settings.Default.dom == rReader[1].ToString() && Settings.Default.paviljon == rReader[2].ToString() && Settings.Default.soba == rReader[3].ToString())
                    {
                        try
                        {
                            brSlobonihSoba = Convert.ToInt32(rReader[5].ToString());
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Greška: " + error.Message.ToString());
                        }
                    }
                }
                conn.Close();
                conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobonihSoba + "', '" + (brSlobonihSoba + 1) + "') WHERE SOBA ='" + Settings.Default.soba + "' AND DOM = '" + Settings.Default.dom + "' AND PAVILJON = '" + Settings.Default.paviljon + "'", conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška: "+error.Message.ToString());
            }
        }
        private bool ProvjeraDuplikata(string maticniBroj)
        {
            bool pronadjen = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from studenti", conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (maticniBroj == dataReader[3].ToString())
                    {
                        pronadjen = true;
                    }
                }
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
            if (pronadjen)
            {
                MessageBox.Show("Student se već nalazi u listi tekuće godine!");
            }
            return pronadjen;
        }
        private void cmbPaviljon_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbDom.Text != "" && cmbPaviljon.Text!= "")
            {
                ConnectionSobe();
                cmbSoba.IsEnabled = true;
            }
            else
            {
                cmbSoba.IsEnabled = false;
            }
        }
            
        private void cmbDom_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbDom.Text != "" && cmbPaviljon.Text != "")
            {
                ConnectionSobe();
                cmbSoba.IsEnabled = true;
            }
            else
            {
                cmbSoba.IsEnabled = false;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WorkingWindow working = new WorkingWindow("arhiva");
            working.ShowDialog();
            txtMjesto_Stanovanja.Text = working.adresa;
            txtIme.Text = working.ime;
            txtPrezime.Text = working.prezime;
            txtBroj_Telefona.Text = working.brTelefona;
            txtMaticni_Broj.Text = working.maticniBr;
        }

        private void cmbUsluga_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbUsluga.Text == "Hrana")
            {
                cmbDom.IsEnabled = false;
                cmbPaviljon.IsEnabled = false;
                cmbSoba.IsEnabled = false;
                cmbDom.SelectedItem = null;
                cmbPaviljon.SelectedItem = null;
                cmbSoba.SelectedItem = null;
            }
            else if(cmbUsluga.Text == "Hrana i soba")
            {
                cmbDom.IsEnabled = true;
                cmbPaviljon.IsEnabled = true;
            }
        }

        private void dpDatumZaduzivanja_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dpDatumZaduzivanja.Text = dpDatumZaduzivanja.SelectedDate.ToString();
        }

        private int Count(string baza)
        {
            int count = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();

                MySqlCommand command = new MySqlCommand(baza, conn);
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    count++;
                }

                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
            return count;
        }
    }
}
