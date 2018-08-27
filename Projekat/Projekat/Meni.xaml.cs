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

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for Meni.xaml
    /// </summary>
    public partial class  Meni : Window
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void btnEvidencija_Click(object sender, RoutedEventArgs e)
        {
            WorkingWindow workingWindow = new WorkingWindow();
           // this.Close();
            workingWindow.ShowDialog();    
        }

        private void btnSobe_Click(object sender, RoutedEventArgs e)
        {
            Sobe sobe = new Sobe();
           // this.Close();
            sobe.ShowDialog();
            
        }

        private void btnIzvjestaj_Click(object sender, RoutedEventArgs e)
        {
            //sthis.Close();
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
           // this.Close();
            addWindow.ShowDialog();
        }
    }
}
