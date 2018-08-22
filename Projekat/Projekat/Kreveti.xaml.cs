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
        public Kreveti(string color)
        {
            InitializeComponent();

            if (color == "R")
                grbColor.Background = Brushes.Red;
            else if (color == "G")
                grbColor.Background = Brushes.Green;
        }

        private void grbColor_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
