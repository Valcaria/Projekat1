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
using Projekat.Properties;

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

            //this.SizeToContent = SizeToContent.Height;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            switch (Settings.Default.close)
            {
                case 0:
                    Settings.Default.close = 1;
                    combBoxChange();
                    break;
                case 2:
                    Settings.Default.close = 1;
                    stpStudentInfo.Children.Clear();
                    stpStudentInfo.Children.Add(new StudentInfo());
                    combBoxChange();
                    break;
                case 3:
                    Settings.Default.close = 1;
                    stpStudentInfo.Children.Clear();
                    combBoxChange();
                    break;
                case 4:
                    Settings.Default.close = 1;
                    stpStudentInfo.Children.Clear();
                    stpStudentInfo.Children.Add(new StudentInfo(cmbDom.Text, cmbPaviljon.Text));
                    combBoxChange();
                    break;
            }
        }

        void combBoxChange()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
                MySqlDataReader rReader = cmd.ExecuteReader();

                stcPanel.Children.Clear();
                while (rReader.Read())
                {
                    if (cmbDom.Text == rReader[1].ToString() && cmbPaviljon.Text == rReader[2].ToString())
                    {
                        brSobe = rReader[3].ToString();
                        ukupnoMjesta = rReader[4].ToString();
                        slobondaMjesta = rReader[5].ToString();
                        stcPanel.Children.Add(new StudentskeSobe(cmbDom.Text, cmbPaviljon.Text, brSobe, ukupnoMjesta, slobondaMjesta));
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

        private void scrVwer_GotFocus(object sender, RoutedEventArgs e)
        {
            combBoxChange();
        }
    }
}
