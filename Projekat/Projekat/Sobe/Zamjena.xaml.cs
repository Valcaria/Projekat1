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
using Projekat.Properties;
using MySql.Data.MySqlClient;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for Zamjena.xaml
    /// </summary>
    public partial class Zamjena : Window
    {
        string maticni1 = "";
        string soba1 = "";
        string dom1 = "";
        string paviljon1 = "";
        string maticni2 = "";
        string soba2 = "";
        string dom2 = "";
        string paviljon2 = "";
        public Zamjena(string imePrezime1,  string imePrezime2, string maticni1, string maticni2, string soba1, string soba2, string dom1, string dom2, string paviljon1, string paviljon2)
        {
            InitializeComponent();
            txtImePrezime1.Text = imePrezime1;
            this.maticni1 = maticni1;
            this.dom1 = dom1;
            this.soba1 = soba1;
            this.paviljon1 = paviljon1;

            txtImePrezime2.Text = imePrezime2;
            this.maticni2 = maticni2;
            this.dom2 = dom2;
            this.paviljon2 = paviljon2;
            this.soba2 = soba2;
            CleanIT();
            btnZamjeni.IsEnabled = true;
        }
        void CleanIT()
        {
            Projekat.Properties.Settings.Default.imePrezime = "";
            Projekat.Properties.Settings.Default.dom = "";
            Projekat.Properties.Settings.Default.paviljon = "";
            Projekat.Properties.Settings.Default.soba = "";
            Projekat.Properties.Settings.Default.maticni = "";
        }
        private void btnZamjeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE studenti SET dom = REPLACE(dom, '" + dom1 + "', '" + (dom2) + "'), paviljon = REPLACE(paviljon, '" + paviljon1 + "','" + paviljon2 + "'), soba = REPLACE(soba, '" + soba1 + "','" + soba2 + "') where maticni_broj = '" + maticni1 + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand("UPDATE studenti SET dom = REPLACE(dom, '" + dom2 + "', '" + (dom1) + "'), paviljon = REPLACE(paviljon, '" + paviljon2 + "','" + paviljon1 + "'), soba = REPLACE(soba, '" + soba2 + "','" + soba1 + "') where maticni_broj = '" + maticni2 + "'", conn);
                cmd2.ExecuteNonQuery();
                conn.Close();

                this.Close();

                MessageBox.Show("Zamjena uspjesna");
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }
        }
    }
}
