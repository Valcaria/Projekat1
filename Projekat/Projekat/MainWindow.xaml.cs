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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string user = "";
        string password = "";
        public MainWindow()
        {
            InitializeComponent();
            txtKorisnik.Clear();
            mySql();
            
        }

        private void imgStudentCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtKorisnik.Text == user && txtLozinka.Password.ToString() == password)
            {
                projekatTMP.WorkingWindow test = new projekatTMP.WorkingWindow();
                this.Close();
                test.ShowDialog();          
            }
            else
                MessageBox.Show("Nije moguc pristup");

            
        }
        
        private void mySql()
        {

           
            string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from admin", conn);
            //DataSet sDs = new DataSet();

            //MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);
            //sAdapter.Fill(sDs, "admin");
            //DataTable dTable = sDs.Tables["admin"];

            MySqlDataReader rReader = cmd.ExecuteReader();
            rReader.Read();
            user= rReader.GetString("ID");
            password = rReader.GetString("PASS");





        }
    }
}
