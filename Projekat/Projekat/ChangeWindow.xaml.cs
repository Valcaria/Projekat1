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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {

        public ChangeWindow(string ime, string prezime, int dom, int fakultet, int godina, string komentar)
        {
            InitializeComponent();
            txtIme.Text = ime;
            txtPrezime.Text = prezime;
            txtKomentar.Text = komentar;
            cmbDom.SelectedIndex = dom;
            cmbFakultet.SelectedIndex = fakultet;
            cmbGodina.SelectedIndex = godina;

        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" && txtKomentar.Text != "" && cmbDom.Text !=""&&cmbFakultet.Text!=""&& cmbGodina.Text!="")
            {
                string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ime,prezime, dom, fakultet, godina, komentar) VALUES('"+txtIme.Text+"','"+txtPrezime.Text+"','"+cmbDom.Text+"','"+cmbFakultet.Text+"','"+cmbGodina.Text+"','"+txtKomentar.Text+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
            
        }
    }
}
