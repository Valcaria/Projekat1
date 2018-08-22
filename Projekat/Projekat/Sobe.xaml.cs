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

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for Sobe.xaml
    /// </summary>
    public partial class Sobe : Window
    {
        string brSobe = "";
        string ukupnoMjesta = "";
        string slobondaMjesta = "";
        string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
        public Sobe()
        {
            InitializeComponent();
        }

        void combBoxChange()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();
                int i = 1;
                stcPanel.Children.Clear();
                while (rReader.Read())
                {
                    if (cmbDom.Text == "2")
                    {
                        if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == rReader[2].ToString())
                        {
                            brSobe = Convert.ToString(i++);
                            ukupnoMjesta = rReader[4].ToString();
                            slobondaMjesta = rReader[5].ToString();
                            stcPanel.Children.Add(new StudentskeSobe(brSobe,ukupnoMjesta,slobondaMjesta));
                        }
                    }
                    else if (cmbDom.Text == "1")
                    {
                        if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == "M" && cmbPaviljon.Text == rReader[2].ToString())
                        {
                            brSobe = Convert.ToString(i);
                            ukupnoMjesta = rReader[4].ToString();
                            slobondaMjesta = rReader[5].ToString();
                            stcPanel.Children.Add(new StudentskeSobe(brSobe, ukupnoMjesta, slobondaMjesta));
                        }
                        else if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == "Z" && cmbPaviljon.Text == rReader[2].ToString())
                        {
                            brSobe = Convert.ToString(i);
                            ukupnoMjesta = rReader[4].ToString();
                            slobondaMjesta = rReader[5].ToString();
                            stcPanel.Children.Add(new StudentskeSobe(brSobe, ukupnoMjesta, slobondaMjesta));
                        }
                        i++;
                    }
                }
                rReader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Greska: " + error.Message.ToString());
            }
        }

        private void cmbDom_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbPaviljon.Text != "")
            {
                combBoxChange();
            }
        }

        private void cmbPaviljon_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbDom.Text != "")
            {
                combBoxChange();
            }
        }
    }

}
