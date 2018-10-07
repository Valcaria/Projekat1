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
    /// Interaction logic for Filtar.xaml
    /// </summary>
    public partial class Filtar : Window
    {

        public string naredba = "";
        public string[] prvaNaredba = { "","","","","","","",""};
        int pom = 0;
        public Filtar(string[] pom)
        {
            InitializeComponent();
            Check(pom);
            for (int i = 0; i < pom.Length; i++)
            {
                prvaNaredba[i] = pom[i].ToString();
            }
        }

        private void PromjenaNizaStringa(string naziv)
        {
            for (int i = 0; i< prvaNaredba.Length; i++)
            {
                if(prvaNaredba[i].ToString() == naziv)
                {
                    for (int j = i; j < (prvaNaredba.Length - 1); j++)
                    {
                        prvaNaredba[j] = prvaNaredba[j + 1].ToString();

                    }
                    if (i == prvaNaredba.Length - 1)
                        prvaNaredba[i] = "";
                }
            }
            pom--;
        }

        private void Check(string[] pom)
        {
            for (int i = 0; i < pom.Length; i++)
            {
                switch (pom[i].ToString())
                {
                    case "Mjesto":
                        txtMjestoStanovanja.Text = Settings.Default.mjestoS1;
                        chbMjestoStanovanja.IsChecked = true;
                        txtMjestoStanovanja.IsEnabled = true;
                        break;
                    case "Dom":
                        if (Settings.Default.dom1 == "1")
                        {
                            rbtnDom1.IsChecked = true;
                            rbtnDom1.IsEnabled = true;
                        }
                        else if (Settings.Default.dom1 == "2")
                        {
                            rbtnDom2.IsChecked = true;
                            rbtnDom2.IsEnabled = true;
                        }
                        chbDom.IsChecked = true;
                        break;
                    case "Paviljon":
                        if (Settings.Default.paviljon1 == "M")
                        {
                            rbtnPaviljonM.IsChecked = true;
                            rbtnPaviljonM.IsEnabled = true;
                        }
                        else if (Settings.Default.paviljon1 == "Z")
                        {
                            rbtnPaviljonZ.IsChecked = true;
                            rbtnPaviljonZ.IsEnabled = true;
                        }
                        chbPaviljon.IsChecked = true;
                        break;
                    case "Usluga":
                        if (Settings.Default.usluga1 == "Hrana i soba")
                        {
                            rbtnHranaiSoba.IsChecked = true;
                            rbtnHranaiSoba.IsEnabled = true;
                        }
                        else if (Settings.Default.usluga1 == "Hrana")
                        {
                            rbtnHrana.IsChecked = true;
                            rbtnHrana.IsEnabled = true;
                        }
                        chbUsluga.IsChecked = true;
                        break;
                    case "DatumZ":
                        break;
                    case "GodinaU":
                        txtGodinaUpotrebe.Text = Settings.Default.godinaU1;
                        chbGodinaUpotrebe.IsChecked = true;
                        txtGodinaUpotrebe.IsEnabled = true;
                        break;
                    case "Fakultet":
                        chbFakultet.IsChecked = true;
                        cmbFakultet.IsEnabled = true;
                        switch (Settings.Default.fakultet1)
                        {
                            case "ETF":
                                cmbFakultet.SelectedIndex = 0;
                                break;
                            case "MAK":
                                cmbFakultet.SelectedIndex = 1;
                                break;
                            case "MAF":
                                cmbFakultet.SelectedIndex = 2;
                                break;
                            case "POF":
                                cmbFakultet.SelectedIndex = 3;
                                break;
                        }
                        break;
                    case "GodinaF":
                        txtGodinaFakulteta.Text = Settings.Default.godinaF1;
                        chbGodinaFakulteta.IsChecked = true;
                        txtGodinaFakulteta.IsEnabled = true;
                        break;
                }
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            naredba = " ";

            for (int i = 0; i < prvaNaredba.Length; i++)
            {
                switch (prvaNaredba[i].ToString())
                {
                    case "Mjesto":
                        if (i == 0)
                        {
                            naredba += "WHERE MJESTO_STANOVANJA LIKE '%" + txtMjestoStanovanja.Text + "%' ";
                        }
                        else
                        {
                            naredba += "AND MJESTO_STANOVANJA LIKE '%" + txtMjestoStanovanja.Text + "%' ";
                        }
                        Settings.Default.mjestoS1 = txtMjestoStanovanja.Text;

                        break;
                    case "Dom":
                        if (i == 0)
                        {
                            if (rbtnDom1.IsChecked == true)
                            {
                                naredba += "WHERE DOM = '1' ";
                            }
                            else if (rbtnDom2.IsChecked == true)
                            {
                                naredba += "WHERE DOM = '2' ";
                            }
                        }
                        else
                        {
                            if (rbtnDom1.IsChecked == true)
                            {
                                naredba += "AND DOM = '1' ";
                            }
                            else if (rbtnDom2.IsChecked == true)
                            {
                                naredba += "AND DOM = '2' ";
                            }
                        }
                        if (rbtnDom1.IsChecked == true)
                        {
                            Settings.Default.dom1 = "1";
                        }
                        else if (rbtnDom2.IsChecked == true)
                        {
                            Settings.Default.dom1 = "2";
                        }
                        break;
                    case "Paviljon":
                        if (i == 0)
                        {
                            if (rbtnPaviljonM.IsChecked == true)
                            {
                                naredba += "WHERE PAVILJON = 'M' ";
                            }
                            else if (rbtnPaviljonZ.IsChecked == true)
                            {
                                naredba += "WHERE PAVILJON = 'Z' ";
                            }
                        }
                        else
                        {
                            if (rbtnPaviljonM.IsChecked == true)
                            {
                                naredba += "AND PAVILJON = 'M' ";
                            }
                            else if (rbtnPaviljonZ.IsChecked == true)
                            {
                                naredba += "AND PAVILJON = 'Z' ";
                            }
                        }
                        if (rbtnPaviljonM.IsChecked == true)
                        {
                            Settings.Default.paviljon1 = "M";
                        }
                        else if (rbtnPaviljonZ.IsChecked == true)
                        {
                            Settings.Default.paviljon1 = "Z";
                        }
                        break;
                    case "Usluga":
                        if (i == 0)
                        {
                            if (rbtnHranaiSoba.IsChecked == true)
                            {
                                naredba += "WHERE USLUGA = 'Hrana i soba' ";
                            }
                            else if (rbtnHrana.IsChecked == true)
                            {
                                naredba += "WHERE USLUGA = 'Hrana' ";
                            }
                        }
                        else
                        {
                            if (rbtnHranaiSoba.IsChecked == true)
                            {
                                naredba += "AND USLUGA = 'Hrana i soba' ";
                            }
                            else if (rbtnHrana.IsChecked == true)
                            {
                                naredba += "AND USLUGA = 'Hrana' ";
                            }
                        }
                        if (rbtnHranaiSoba.IsChecked == true)
                        {
                            Settings.Default.usluga1 = "Hrana i soba";
                        }
                        else if (rbtnHrana.IsChecked == true)
                        {
                            Settings.Default.usluga1 = "Hrana";
                        }
                break;
                    case "DatumZ":
                        break;
                    case "GodinaU":
                        if (i == 0)
                        {
                            naredba += "WHERE GODINA_UPOTREBE ='" + txtGodinaUpotrebe.Text + "' ";
                        }
                        else
                        {
                            naredba += "AND GODINA_UPOTREBE ='" + txtGodinaUpotrebe.Text + "' ";
                        }
                        Settings.Default.godinaU1 = txtGodinaUpotrebe.Text;
                        break;
                    case "Fakultet":
                        if (i == 0)
                        {
                            naredba += "WHERE FAKULTET ='" + cmbFakultet.Text + "' ";
                        }
                        else
                        {
                            naredba += "AND FAKULTET ='" + cmbFakultet.Text + "' ";
                        }
                        Settings.Default.godinaF1 = cmbFakultet.SelectedItem.ToString();
                        break;
                    case "GodinaF":
                        if (i == 0)
                        {
                            naredba += "WHERE GODINA ='" + txtGodinaFakulteta.Text + "' ";
                        }
                        else
                        {
                            naredba += "AND GODINA ='" + txtGodinaFakulteta.Text + "' ";
                        }
                        Settings.Default.godinaF1 = txtGodinaFakulteta.Text;
                        break;
                }
            }
            MessageBox.Show(naredba);
            this.Close();
        }

        private void chbMjestoStanovanja_Click(object sender, RoutedEventArgs e)
        {
            if(chbMjestoStanovanja.IsChecked == true)
            {
                prvaNaredba[pom++] = "Mjesto";
                txtMjestoStanovanja.IsEnabled = true;
            }
            else if (chbMjestoStanovanja.IsChecked == false)
            {
                txtMjestoStanovanja.IsEnabled = false;
                PromjenaNizaStringa("Mjesto");
                txtMjestoStanovanja.Clear();
            }
        }

        private void chbDom_Click(object sender, RoutedEventArgs e)
        {
            if (chbDom.IsChecked == true)
            {
                rbtnDom1.IsEnabled = true;
                rbtnDom2.IsEnabled = true;
                prvaNaredba[pom++] = "Dom";
            }
            else if (chbDom.IsChecked == false)
            {
                rbtnDom1.IsEnabled = false;
                rbtnDom2.IsEnabled = false;
                PromjenaNizaStringa("Dom");
                rbtnDom1.IsChecked = false;
                rbtnDom2.IsChecked = false;
            }
        }

        private void chbPaviljon_Click(object sender, RoutedEventArgs e)
        {
            if (chbPaviljon.IsChecked == true)
            {
                rbtnPaviljonM.IsEnabled = true;
                rbtnPaviljonZ.IsEnabled = true;
                prvaNaredba[pom++] = "Paviljon";
            }
            else if (chbPaviljon.IsChecked == false)
            {
                rbtnPaviljonM.IsEnabled = false;
                rbtnPaviljonZ.IsEnabled = false;
                PromjenaNizaStringa("Paviljon");
                rbtnPaviljonM.IsChecked = false;
                rbtnPaviljonZ.IsChecked = false;
            }
        }

        private void chbUsluga_Click(object sender, RoutedEventArgs e)
        {
            if (chbUsluga.IsChecked == true)
            {
                rbtnHrana.IsEnabled = true;
                rbtnHranaiSoba.IsEnabled = true;
                prvaNaredba[pom++] = "Usluga";
            }
            else if (chbUsluga.IsChecked == false)
            {
                rbtnHranaiSoba.IsEnabled = false;
                rbtnHrana.IsEnabled = false;
                PromjenaNizaStringa("Usluga");
                rbtnHrana.IsChecked = false;
                rbtnHranaiSoba.IsChecked = false;
            }
        }

        private void chbGodinaUpotrebe_Click(object sender, RoutedEventArgs e)
        {
            if (chbGodinaUpotrebe.IsChecked == true)
            {
                prvaNaredba[pom++] = "GodinaU";
                txtGodinaUpotrebe.IsEnabled = true;
            }
            else if (chbGodinaUpotrebe.IsChecked == false)
            {
                txtGodinaUpotrebe.IsEnabled = false;
                PromjenaNizaStringa("GodinaU");
                txtGodinaUpotrebe.Clear();
            }
        }

        private void chbFakultet_Click(object sender, RoutedEventArgs e)
        {
            if (chbFakultet.IsChecked == true)
            {
                prvaNaredba[pom++] = "Fakultet";
                cmbFakultet.IsEnabled = true;
            }
            else if (chbFakultet.IsChecked == false)
            {
                cmbFakultet.IsEnabled = false;
                PromjenaNizaStringa("Fakultet");
                cmbFakultet.SelectedItem = null;
            }
        }

        private void chbGodinaFakulteta_Click(object sender, RoutedEventArgs e)
        {
            if (chbGodinaFakulteta.IsChecked == true)
            {
                prvaNaredba[pom++] = "GodinaF";
                txtGodinaFakulteta.IsEnabled = true;
            }
            else if (chbGodinaFakulteta.IsChecked == false)
            {
                txtGodinaFakulteta.IsEnabled = false;
                PromjenaNizaStringa("GodinaF");
                txtGodinaFakulteta.Clear();
            }
        }
    }
}
