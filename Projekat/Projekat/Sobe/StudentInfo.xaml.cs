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
using Projekat;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        public StudentInfo(string imePrezime, string maticni, string brSobe, string dom, string paviljon)
        {
            InitializeComponent();
            lblImePrezime.Content = imePrezime;
            lblDom.Content = dom;
            lblPaviljon.Content = paviljon;
            lblBrSobe.Content = brSobe;
            Settings.Default.maticni = maticni;
        }

        private void btnZamjena_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.close = 0;
            Settings.Default.imePrezime = lblImePrezime.Content.ToString();
            Settings.Default.dom = lblDom.Content.ToString();
            Settings.Default.paviljon = lblPaviljon.Content.ToString();
            Settings.Default.soba = lblBrSobe.Content.ToString();

            Sobe sobe = new Sobe(lblDom.Content.ToString(), lblPaviljon.Content.ToString());
            this.Close();
            sobe.ShowDialog();
        }
    }
}
