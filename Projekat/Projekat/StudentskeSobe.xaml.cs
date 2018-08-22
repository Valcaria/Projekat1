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
    /// Interaction logic for StudentskeSobe.xaml
    /// </summary>
    public partial class StudentskeSobe : UserControl
    {
        public StudentskeSobe(string brSobe, string ukupnoMjesta, string slobondaMjesta)
        {
            InitializeComponent();

            lblBrSobe.Content = brSobe;
            lblSlobodnaMjesta.Content = slobondaMjesta;
            lblBrMjesta.Content = ukupnoMjesta;
            try
            {
                for (int i = 0; i < Convert.ToInt32(ukupnoMjesta)-Convert.ToInt32(slobondaMjesta); i++)
                {
                    stcPanel.Children.Add(new Kreveti("R"));
                }
                for (int i = 0; i <  Convert.ToInt32(slobondaMjesta); i++)
                {
                    stcPanel.Children.Add(new Kreveti("G"));
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Greska: "+ error.Message.ToString());
            }
        }
    }
}
