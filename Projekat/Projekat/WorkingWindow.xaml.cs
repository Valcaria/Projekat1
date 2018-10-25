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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Projekat.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkingWindow : System.Windows.Window
    {
        public string maticniBr = "";
        public string adresa = "";
        public string ime = "";
        public string prezime = "";
        public string brTelefona = "";
        private System.Data.DataTable dataTable;
        public string[] filterString = {"","","","","","","","" };
        private string pom = "";
        public WorkingWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcherTimer.Start();
            Settings.Default.naredba = "";

            FillDataGrid("Select ID, PREZIME, IME, MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + Settings.Default.naredba);
        }

        public WorkingWindow(string pom)
        {
            InitializeComponent();
            this.pom = pom;
            FillDataGrid("Select ID,  PREZIME, IME, MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA,DATE_FORMAT(DATUM_RAZDUZENJA, '%d/%m/%Y') as DATUM_RAZDUZENJA From arhiva");
            btnArhiviraj.IsEnabled = true;
            btnArhiviraj.Content = "Pretraga";
            btnIzvjestaj.Visibility = Visibility.Hidden;
            btnIzmijeni.Visibility = Visibility.Hidden;
            btnArhivirajSve.Visibility = Visibility.Hidden;
            arhiva.Visibility = Visibility.Hidden;
            dockPanel.Visibility = Visibility.Hidden;
            datagrdTabela.Margin = new Thickness(10,15,9,85);
            btnIzvjestaj.Margin = new Thickness(0, 0, 10, 23);
            Settings.Default.naredba = "";

        }
        private void FillDataGrid(string baza)
        {
            bool arhiva = false;

            if (baza == "Select ID, PREZIME, IME,  MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA,DATE_FORMAT(DATUM_RAZDUZENJA, '%d/%m/%Y') as DATUM_RAZDUZENJA From arhiva" + Settings.Default.naredba)
            {
                arhiva = true;
                DataGridTextColumn data = new DataGridTextColumn();
                data.Header = "Datum Razduzenja";
                data.FontSize = 14;
                Binding binding = new Binding("DATUM_RAZDUZENJA");
                data.Binding = binding;
                datagrdTabela.Columns.Add(data);
            }

            try
            {

                if(Count("select * from studenti")>0)
                {
                    btnArhivirajSve.IsEnabled = true;
                }
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();

                MySqlDataAdapter sAdapter = new MySqlDataAdapter(baza, conn);
                sAdapter.Fill(dG);
                datagrdTabela.ItemsSource = dG.DefaultView;
                conn.Close();
                dataTable = dG;
            }
            catch (Exception e)
            {
                MessageBox.Show("Greška: " + e.Message.ToString());
            }

            if (datagrdTabela.Columns.Count > 8 && !arhiva)
            {
                datagrdTabela.Columns.Remove(datagrdTabela.Columns[8]);
            }
        }

        private string KonverzijaDatuma(string datumIzTabele)
        {
            string godina = "";
            string dan = "";
            string mjesec = "";
            for (int i = 0, j = 0; i < 10; i++)
            {
                if (datumIzTabele[i] != '/')
                {
                    switch (j)
                    {
                        case 0:
                            dan += datumIzTabele[i];
                            break;
                        case 1:
                            mjesec += datumIzTabele[i];
                            break;
                        case 2:
                            godina += datumIzTabele[i];
                            break;
                    }
                }
                else
                {
                    j++;
                }
            }
            return godina + "-" + mjesec + "-" + dan; ;
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
           if(btnArhiviraj.Content.ToString() != "Pretraga")
            {
                AddWindow add = new AddWindow();
                add.ShowDialog();
                FillDataGrid("Select ID, PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + Settings.Default.naredba);
            }
            else
            {
                if(pom == "arhiva")
                {
                    DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
                    maticniBr = dataRow.Row.ItemArray[3].ToString();
                    PronadjiStudenta("select * from arhiva");
                }
                else
                {
                    if(datagrdTabela.SelectedItem != null)
                    {
                        DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
                        AddWindow add = new AddWindow("", dataRow.Row.ItemArray[2].ToString(), dataRow.Row.ItemArray[1].ToString(), dataRow.Row.ItemArray[3].ToString(), dataRow.Row.ItemArray[4].ToString(), dataRow.Row.ItemArray[5].ToString(), "", "", "", "", "", "", "");
                        add.ShowDialog();
                    }
                }
            }
        }

        private void btnArhiviraj_Click(object sender, RoutedEventArgs e)
        {
            int broj = 0;
            if (datagrdTabela.SelectedItem != null && btnArhiviraj.Content.ToString() == "Arhiviraj")
            {
                DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
              
                MessageBoxResult message = MessageBox.Show("Da li ste sigurni da želite da arhivirate studenta "+dataRow.Row.ItemArray[1].ToString() + " "+dataRow.Row.ItemArray[2].ToString()+"?", " ", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (message == MessageBoxResult.OK)
                {
                    try
                    {
                        int count = Count("SELECT * FROM arhiva");
                        string datum = "";
                        maticniBr = dataRow.Row.ItemArray[3].ToString();

                        datum = KonverzijaDatuma(dataRow.Row.ItemArray[7].ToString());
                        broj = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());

                        PronadjiStudenta("select * from studenti");
      
                        MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("INSERT into arhiva(ID,PREZIME,ime,maticni_broj, mjesto_stanovanja, broj_telefona, dom, paviljon, soba, usluga,DATUM_ZADUZIVANJA,datum_razduzenja, godina_upotrebe, fakultet, godina, komentar) VALUES('" + (count+1)+"','" + dataRow.Row.ItemArray[1].ToString() + "', '" + dataRow.Row.ItemArray[2].ToString() + "', '" + dataRow.Row.ItemArray[3].ToString() + "', '" + dataRow.Row.ItemArray[4].ToString() + "', '" + dataRow.Row.ItemArray[5].ToString() + "', '" + Settings.Default.dom + "', '" + Settings.Default.paviljon + "', '" + Settings.Default.soba + "', '" + dataRow.Row.ItemArray[6].ToString() + "', '" + datum + "','" +DateTime.Now.ToString("yyyy-MM-dd") +"','"+ Settings.Default.godina_upotrebe+ "', '" + Settings.Default.fakultet + "', '" + Settings.Default.godina + "', '" + Settings.Default.komentar + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        conn = new MySqlConnection(Settings.Default.connstr);
                        conn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("DELETE FROM studenti WHERE maticni_broj = '" + (maticniBr)+"'", conn);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        PromjenaID(broj);
                        OslobodiSobu();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greška: " + error.Message.ToString());
                    }
                    FillDataGrid("Select ID,PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + Settings.Default.naredba);
                }   
            }
            else if(btnArhiviraj.Content.ToString() == "Pretraga")
            {
                SearchWindow search = new SearchWindow(pom, filterString);
                search.ShowDialog();
                if(search.ime != "" && search.prezime!="" && search.brTelefona != "" && search.adresa != "" && search.maticni != "")
                {
                    ime = search.ime;
                    prezime = search.prezime;
                    maticniBr = search.maticni;
                    adresa = search.adresa;
                    brTelefona = search.brTelefona;
                    this.Close();
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           if(datagrdTabela.SelectedItem != null && btnArhiviraj.Content.ToString() !="Pretraga")
            {
                btnDodaj.IsEnabled = true;
                btnArhiviraj.IsEnabled = true;
                btnIzmijeni.IsEnabled = true;
            }
           else if(datagrdTabela.SelectedItem == null && btnArhiviraj.Content.ToString() != "Pretraga")
            {
                btnDodaj.IsEnabled = true;
                btnArhiviraj.IsEnabled = false;
                btnIzmijeni.IsEnabled = false;
            }
           else if(datagrdTabela.SelectedItem == null && btnArhiviraj.Content.ToString() == "Pretraga")
            {
                btnDodaj.IsEnabled = false;
            }
           else if (datagrdTabela.SelectedItem != null && btnArhiviraj.Content.ToString() == "Pretraga")
            {
                btnDodaj.IsEnabled = true;
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT MATICNI_BROJ, ID, IME,PREZIME,MJESTO_STANOVANJA,BROJ_TELEFONA,DOM,PAVILJON,SOBA,USLUGA,DATUM_ZADUZIVANJA,GODINA_UPOTREBE,FAKULTET,GODINA,KOMENTAR from studenti", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    if (rReader[0].ToString() == dataRow.Row.ItemArray[3].ToString())
                    {
                        Settings.Default.datum = rReader[10].ToString();
                        AddWindow addWindow = new AddWindow(dataRow.Row.ItemArray[0].ToString(), dataRow.Row.ItemArray[2].ToString(), dataRow.Row.ItemArray[1].ToString(), dataRow.Row.ItemArray[3].ToString(), rReader[4].ToString(), rReader[5].ToString(), rReader[6].ToString(), rReader[7].ToString(), rReader[8].ToString(), rReader[9].ToString(), rReader[12].ToString(), rReader[13].ToString(), rReader[14].ToString());
                        addWindow.ShowDialog();
                        FillDataGrid("Select ID,PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + Settings.Default.naredba);
                        this.Show();
                    }
                }
                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška: "+ error.Message.ToString());
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
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
        }
        private void PronadjiStudenta(string baza)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(baza, conn);
                MySqlDataReader rReader = cmd.ExecuteReader();

                while (rReader.Read())
                {
                    if (maticniBr == rReader[3].ToString())
                    {
                        if (baza == "select * from studenti")
                        {
                            Settings.Default.dom = rReader[6].ToString();
                            Settings.Default.paviljon = rReader[7].ToString();
                            Settings.Default.soba = rReader[8].ToString();
                            Settings.Default.godina_upotrebe = rReader[11].ToString();
                            Settings.Default.fakultet = rReader[12].ToString();
                            Settings.Default.godina = rReader[13].ToString();
                            Settings.Default.komentar = rReader[14].ToString();

                        }
                        else
                        {
                            ime = rReader[1].ToString();
                            prezime = rReader[2].ToString();
                            adresa = rReader[4].ToString();
                            brTelefona = rReader[5].ToString();

                            this.Close();
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
        }
        private void btnIzvjestaj_Click(object sender, RoutedEventArgs e)
        {
            Projekat.Izvjestaj izvjestaj = new Projekat.Izvjestaj(dataTable, arhiva.Header.ToString());
            izvjestaj.ShowDialog();
        }

        private void PromjenaID(int ID)
        {
            int count = Count("SELECT * FROM studenti");
            

            for (int j = ID; j <= count; j++)
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();

                MySqlCommand command2 = new MySqlCommand("UPDATE studenti SET ID = '"+ID+"' WHERE ID = '"+(ID+1)+"'", conn);
                command2.ExecuteNonQuery();
                ID++;

                conn.Close();

            }
        }

        private int Count(string baza)
        {
            int count = 0;

            MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
            conn.Open();

            MySqlCommand command = new MySqlCommand(baza, conn);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                count++;
            }

            conn.Close();

            return count;
        }

        private void btnArhivirajSve_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Da li ste sigurni da želite da arhivirate sve studente?", " ", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            try
            {
                if (message == MessageBoxResult.OK)
                {
                    int broj = Count("SELECT * FROM studenti");

                    for (int i = 0; i < broj; i++)
                    {
                        string ime = "", prezime = "", maticni = "", brojTelefona = "", mjestoStanovanja = "";
                        string datumZaduzenja = "", fakultet = "", godina = "";
                        string godinaUsluge = "", komentar = "", usluga = "";

                        MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);

                        conn.Open();
                        MySqlCommand command = new MySqlCommand("Select ID,PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,DOM,PAVILJON,SOBA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA,GODINA_UPOTREBE,	FAKULTET,	GODINA,	KOMENTAR  From studenti", conn);
                        MySqlDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            if (dataReader[0].ToString() == Convert.ToString(i + 1))
                            {
                                ime = dataReader[1].ToString();
                                prezime = dataReader[2].ToString();
                                maticni = dataReader[3].ToString();
                                brojTelefona = dataReader[5].ToString();
                                mjestoStanovanja = dataReader[4].ToString();
                                datumZaduzenja = dataReader[10].ToString();
                                Settings.Default.dom = dataReader[6].ToString();
                                Settings.Default.soba = dataReader[8].ToString();
                                Settings.Default.paviljon = dataReader[7].ToString();
                                komentar = dataReader[14].ToString();
                                godina = dataReader[13].ToString();
                                godinaUsluge = dataReader[11].ToString();
                                fakultet = dataReader[12].ToString();
                                usluga = dataReader[9].ToString();
                            }
                        }


                        conn.Close();

                        OslobodiSobu();
                        datumZaduzenja = KonverzijaDatuma(datumZaduzenja);

                        int id = Count("select * from arhiva");

                        conn = new MySqlConnection(Settings.Default.connstr);

                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("INSERT into arhiva(ime,prezime,maticni_broj, mjesto_stanovanja, broj_telefona, dom, paviljon, soba, usluga,DATUM_ZADUZIVANJA,datum_razduzenja, godina_upotrebe, fakultet, godina, komentar) VALUES('" + ime + "', '" + prezime + "', '" + maticni + "', '" + mjestoStanovanja + "', '" + brojTelefona + "', '" + Settings.Default.dom + "', '" + Settings.Default.paviljon + "', '" + Settings.Default.soba + "', '" + usluga + "', '" + datumZaduzenja + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + godinaUsluge + "', '" + fakultet + "', '" + godina + "', '" + komentar + "')", conn);
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }

                    MySqlConnection conn2 = new MySqlConnection(Settings.Default.connstr);

                    conn2.Open();
                    MySqlCommand cmd2 = new MySqlCommand("TRUNCATE TABLE studenti", conn2);
                    cmd2.ExecuteNonQuery();

                    conn2.Close();

                    FillDataGrid("Select ID, PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
            btnArhivirajSve.IsEnabled = false;
        }

        private void arhiva_Click(object sender, RoutedEventArgs e)
        {
            if (arhiva.Header.ToString() == "_Arhiva")
            {
                FillDataGrid("Select ID, PREZIME, IME,  MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA,DATE_FORMAT(DATUM_RAZDUZENJA, '%d/%m/%Y') as DATUM_RAZDUZENJA From arhiva" + Settings.Default.naredba);
                arhiva.Header = "_Tekuća godina";
                btnArhiviraj.IsEnabled = true;

                btnArhiviraj.Content = "Pretraga";
                btnIzmijeni.Visibility = Visibility.Hidden;
                btnArhivirajSve.Visibility = Visibility.Hidden;
            }
            else if (arhiva.Header.ToString() == "_Tekuća godina")
            {

                FillDataGrid("Select ID,PREZIME,IME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + Settings.Default.naredba);
                btnArhiviraj.IsEnabled = false;
                btnArhiviraj.Margin = new Thickness(135, 0, 0, 23);
                btnArhiviraj.Content = "Arhiviraj";
                btnIzmijeni.Visibility = Visibility.Visible;
                btnArhivirajSve.Visibility = Visibility.Visible;
                arhiva.Header = "_Arhiva";

            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            if (arhiva.Header.ToString() == "_Arhiva")
            {
                Filtar filter = new Filtar(filterString);
                filter.ShowDialog();
                Settings.Default.naredba = filter.naredba;
                FillDataGrid("Select ID,PREZIME, IME,  MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti" + filter.naredba);
                for (int i = 0; i < filterString.Length; i++)
                {
                    filterString[i] = String.Copy(filter.prvaNaredba[i]);
                }
            }

            else if (arhiva.Header.ToString() == "_Tekuća godina")
            {
                Filtar filter = new Filtar(filterString);
                filter.ShowDialog();
                Settings.Default.naredba = filter.naredba;
                FillDataGrid("Select ID, PREZIME,IME,  MATICNI_BROJ, MJESTO_STANOVANJA, BROJ_TELEFONA, USLUGA, DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA,DATE_FORMAT(DATUM_RAZDUZENJA, '%d/%m/%Y') as DATUM_RAZDUZENJA From arhiva" + filter.naredba);
                for (int i = 0; i < filterString.Length; i++)
                {
                    filterString[i] = String.Copy(filter.prvaNaredba[i]);
                }
            }

        }
    }
}
