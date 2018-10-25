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

        private void imgSobe_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sobe sobe = new Sobe();
            this.Hide();
            sobe.ShowDialog();
            this.Show();
            Settings.Default.maticni = "";
        }

        private void imgEvidencija_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WorkingWindow workingWindow = new WorkingWindow();
            this.Hide();
            workingWindow.ShowDialog();
            this.Show();
        }

        private void meniOdjavise_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void imgUnesi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            this.Hide();
            addWindow.ShowDialog();
            this.Show();
        }
    }
}
