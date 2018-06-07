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
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();

            FillDataGrid();
        }

        private void FillDataGrid()
        {
           // datagrdTabela.Items.Clear();
            DataTable dG = new DataTable();
            string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

           // MySqlCommand command = new MySqlCommand("select * from studenti", conn);
            
            MySqlDataAdapter sAdapter = new MySqlDataAdapter("select * from studenti",conn);
            sAdapter.Fill(dG);
            
            

            datagrdTabela.ItemsSource = dG.DefaultView;

            conn.Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            

            Projekat.AddWindow add = new Projekat.AddWindow();
            add.ShowDialog();
            FillDataGrid();
            
        }

        private void btnUkloni_Click(object sender, RoutedEventArgs e)
        {
           if (datagrdTabela.SelectedItem != null)
            {
                string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
                string cellValue = dataRow.Row.ItemArray[0].ToString();
                MySqlCommand komanda = new MySqlCommand("DELETE FROM studenti WHERE ID = " + (cellValue), conn);
                komanda.ExecuteNonQuery();
                
                conn.Close();
                FillDataGrid();
                
            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            Projekat.MainWindow main = new Projekat.MainWindow();
            main.Show();
            this.Close();
          
        }


        


private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           if(datagrdTabela.SelectedItem != null)
            {
                btnUkloni.IsEnabled = true;
                btnIzmijeni.IsEnabled = true;
            }
           else
            {
                btnUkloni.IsEnabled = false;
                btnIzmijeni.IsEnabled = false;
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            Projekat.ChangeWindow changeWindow = new Projekat.ChangeWindow()
        }
    }
}
