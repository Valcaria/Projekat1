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
            
        }

        private void imgStudentCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Connection();
            if (txtKorisnik.Text == user && txtLozinka.Password.ToString() == password && txtKorisnik.Text!= "" && txtLozinka.Password.ToString() != "" )
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

            MySqlDataReader rReader = cmd.ExecuteReader();
            while(rReader.Read())
            {
                if (txtKorisnik.Text == rReader[1].ToString() && txtLozinka.Password.ToString() == rReader[2].ToString())
                {
                    user = rReader[1].ToString();
                    password = rReader[2].ToString();                    
                }             
            }
            conn.Close();
        }

        private void Connection()
        {
            string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from history", conn);

            MySqlDataReader rReader = cmd.ExecuteReader();
            while (rReader.Read())
            {
                if(rReader[3].ToString()=="0")
                {
                    mySql();
                }
                else if(rReader[3].ToString() == "1")
                {
                    txtKorisnik.Text = rReader[1].ToString();
                    txtLozinka.Password = rReader[2].ToString();
                    cbxSacuvaj.IsChecked = true;
                }
            }
            conn.Close();
        }
        private void cbxSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (cbxSacuvaj.IsChecked == true)
            {
                string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                MySqlConnection con = new MySqlConnection(connstr);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE history SET user = '"+txtKorisnik.Text+"', password = '"+txtLozinka.Password.ToString()+"',user_checked = 1 where id = 0", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                MySqlConnection con = new MySqlConnection(connstr);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE history SET user = '', password = '',user_checked = 0 where id = 0", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
