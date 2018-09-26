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
            this.Hide();
            workingWindow.ShowDialog();
            this.Show();
        }

        private void btnSobe_Click(object sender, RoutedEventArgs e)
        {
            Sobe sobe = new Sobe();
            this.Hide();
            sobe.ShowDialog();
            this.Show();
        }

        private void btnIzvjestaj_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Show();
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            this.Hide();
            addWindow.ShowDialog();
            this.Show();
        }
    }
}
