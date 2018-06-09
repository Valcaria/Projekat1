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
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" && cmbDom.Text !=""&&cmbFakultet.Text!=""&&cmbGodina.Text!="")
            {
                string connstr = "Server=localhost;Uid=root;pwd= ;database=baza_projekat;SslMode=none";
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
