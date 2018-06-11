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

        string id = "";


        public AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(string id, string ime, string prezime, string dom, string fakultet, string godina, string komentar)
        {
            
            InitializeComponent();

            btnDodaj.Content = "Izmijeni";
            txtIme.Text = ime;
            txtPrezime.Text = prezime;
            txtKomentar.Text = komentar;
            this.id = id;
            if (dom == "1")
            {
                cmbDom.SelectedIndex = 0;
            }
            else if (dom == "2")
            {
                cmbDom.SelectedIndex = 1;

            }
            if (fakultet == "ETF")
            {
                cmbFakultet.SelectedIndex = 0;
            }
            else if (fakultet == "MAK")
            {
                cmbFakultet.SelectedIndex = 1;
            }
            else if (fakultet == "MAF")
            {
                cmbFakultet.SelectedIndex = 2;
            }
            else if (fakultet == "POF")
            {
                cmbFakultet.SelectedIndex = 3;
            }
            if (godina == "1")
            {
                cmbGodina.SelectedIndex = 0;
            }
            else if (godina == "2")
            {
                cmbGodina.SelectedIndex = 1;
            }
            else if (godina == "3")
            {
                cmbGodina.SelectedIndex = 2;
            }
            else if (godina == "4")
            {
                cmbGodina.SelectedIndex = 3;
            }


        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            
            if (id == "")
            {
                if (txtIme.Text != "" && txtPrezime.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                {
                    try
                    {
                    string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                    MySqlConnection conn = new MySqlConnection(connstr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT into studenti(ime,prezime, dom, fakultet, godina, komentar) VALUES('" + txtIme.Text + "','" + txtPrezime.Text + "','" + cmbDom.Text + "','" + cmbFakultet.Text + "','" + cmbGodina.Text + "','" + txtKomentar.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                }
            }
            else
            {
                if (txtIme.Text != "" && txtPrezime.Text != "" && cmbDom.Text != "" && cmbFakultet.Text != "" && cmbGodina.Text != "")
                {
                    try
                    { 
                    string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                    MySqlConnection conn = new MySqlConnection(connstr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET ime = '" + txtIme.Text + "', prezime ='" + txtPrezime.Text + "',dom =" + cmbDom.Text + ",fakultet = '" + cmbFakultet.Text + "', godina = " + cmbGodina.Text + ",komentar = '" + txtKomentar.Text + "' where id = " + id + ";", conn);
                    cmd.ExecuteNonQuery();
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
    }
}
