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
using Projekat.Properties;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for StudentskeSobe.xaml
    /// </summary>
    public partial class StudentskeSobe : UserControl
    {
        
        public StudentskeSobe(string dom, string paviljon, string brSobe, string ukupnoMjesta, string slobondaMjesta)
        {
            InitializeComponent();
            string student = "";
            lblBrSobe.Content = brSobe;
            lblSlobodnaMjesta.Content = slobondaMjesta;
            lblBrMjesta.Content = ukupnoMjesta;
            try
            {
                MySqlConnection conn = new MySqlConnection(Settings.Default.connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from studenti", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                while (rReader.Read())
                {
                    if (dom == rReader[6].ToString() && paviljon == rReader[7].ToString() && brSobe == rReader[8].ToString() && Settings.Default.maticni != rReader[3].ToString())
                    {
                        student = rReader[1].ToString();
                        student += " " + rReader[2].ToString();
                        stcPanel.Children.Add(new Kreveti("R", student, dom, paviljon, brSobe, rReader[3].ToString()));
                    }
                    else if (dom == rReader[6].ToString() && paviljon == rReader[7].ToString() && brSobe == rReader[8].ToString() && Settings.Default.maticni == rReader[3].ToString())
                    {
                        student = rReader[1].ToString();
                        student += " " + rReader[2].ToString();
                        stcPanel.Children.Add(new Kreveti("Gr", student, dom, paviljon, brSobe, rReader[3].ToString()));

                    }
                }
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
            }

            try
            {
                for (int i = 0; i < Convert.ToInt32(slobondaMjesta); i++)
                {
                    stcPanel.Children.Add(new Kreveti("G", "Prazno", dom, paviljon, brSobe, ""));
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Greška: " + error.Message.ToString());
                Settings.Default.maticni = "";
            } 
        }
    }
}
