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

namespace projekatTMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        public WorkingWindow()
        {
            InitializeComponent();

            
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable dG = new DataTable();
            string connstr = "Server=localhost;Uid=root;pwd= ;database=baza_projekat;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
           // MySqlCommand cmd = new MySqlCommand("select * from baza_pojekat", conn);
          //  DataSet sDs = new DataSet();

            MySqlDataAdapter sAdapter = new MySqlDataAdapter("select * from studenti",conn);
            sAdapter.Fill(dG);
            //DataTable dTable = sDs.Tables["baze_projekat"];

            datagrdTabela.ItemsSource = dG.DefaultView;
            
            
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Projekat.AddWindow add = new Projekat.AddWindow();
            add.ShowDialog();
            
        }
    }
}
