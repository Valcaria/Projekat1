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

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for Kreveti.xaml
    /// </summary>
    public partial class Kreveti : UserControl
    {
        string soba = "";
        string dom = "";
        string paviljon = "";
        string maticni = "";
        public Kreveti(string color, string stanje, string dom, string paviljon, string brSobe, string maticni)
        {
            InitializeComponent();

                if (color == "R")
                {
                    grbColor.Background = Brushes.Red;
                    lblIme.Content = stanje;
                }
                else if (color == "G")
                {
                    grbColor.Background = Brushes.Green;
                    lblIme.Content = stanje;
                }

            soba = brSobe;
            this.paviljon = paviljon;
            this.dom = dom;
            this.maticni = maticni;
        }

        private void grbColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(grbColor.Background == Brushes.Green)
            {
                SearchWindow searchWindow = new SearchWindow("", dom, paviljon, soba);
                searchWindow.ShowDialog();
            }
            else if(grbColor.Background == Brushes.Red)
            {
                Zamjena zamjena = new Zamjena(Convert.ToString(lblIme.Content), maticni, soba, dom, paviljon);
                zamjena.ShowDialog();
            }
        }
    }
}
