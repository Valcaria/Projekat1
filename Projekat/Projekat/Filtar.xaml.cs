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
    /// Interaction logic for Filtar.xaml
    /// </summary>
    public partial class Filtar : Window
    {

        string naredba = "";
        string[] prvaNaredba = { "","","","","","","",""};
        int pom = 0;
        public Filtar()
        {
            InitializeComponent();
            string g = "";
            naredba = "SELECT * FROM STUDENTI ";
            for (int i = 0; i < prvaNaredba.Length; i++)
            {
                g += prvaNaredba[i] +" ";
            }
            MessageBox.Show(g);
        }

        private void PromjenaNizaStringa(string naziv)
        {
            for (int i = 0; i< prvaNaredba.Length; i++)
            {
                if(prvaNaredba[i].ToString() == naziv)
                {
                    for (int j = i; j < (prvaNaredba.Length - 1); j++)
                    {
                        prvaNaredba[j] = null;
                        prvaNaredba[j] = prvaNaredba[j + 1].ToString();
                    }
                    if (i == prvaNaredba.Length - 1)
                        prvaNaredba[i] = null;
                }
            }
            string g = "";
            for (int i = 0; i < prvaNaredba.Length; i++)
            {
                g += prvaNaredba[i] + " ";
            }
            MessageBox.Show(g);
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

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            for(int i =0;i<prvaNaredba.Length;i++)
            {
                switch(prvaNaredba[i].ToString())
                {
                    case "Mjesto":
                        if(i==0)
                        {
                            naredba += "WHERE MJESTO_STANOVANJA ='"+txtMjestoStanovanja.Text+"' ";
                        }
                        else
                        {
                            naredba += "AND MJESTO_STANOVANJA ='" + txtMjestoStanovanja.Text + "' ";
                        }
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
                        break;
                    case "Usluga":
                        if (i == 0)
                        {
                            if (rbtnHranaiSoba.IsChecked == true)
                            {
                                naredba += "WHERE USLUGA = 'Hrana i soba' ";
                            }
                            else if (rbtnPaviljonZ.IsChecked == true)
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
                            else if (rbtnPaviljonZ.IsChecked == true)
                            {
                                naredba += "AND USLUGA = 'Hrana' ";
                            }
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
                        break;
                    case "Fakultet":
                        if (i == 0)
                        {
                            naredba += "WHERE FAKULTET ='" + cmbFakultet.SelectedItem.ToString() + "' ";
                        }
                        else
                        {
                            naredba += "AND FAKULTET ='" + cmbFakultet.SelectedItem.ToString() + "' ";
                        }
                        break;
                    case "Godina":
                        if (i == 0)
                        {
                            naredba += "WHERE GODINA ='" + txtGodinaFakulteta.Text + "' ";
                        }
                        else
                        {
                            naredba += "AND GODINA ='" + txtGodinaFakulteta.Text + "' ";
                        }
                        break;
                }
            }
            MessageBox.Show(naredba);
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
                //cmbFakultet.sele
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
