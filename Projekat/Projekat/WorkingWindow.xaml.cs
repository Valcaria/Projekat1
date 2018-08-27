﻿using System;
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
using MySql.Data.MySqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Projekat.Properties;

namespace ProjekatTMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkingWindow : System.Windows.Window
    {
        string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
        string brSobe = "";
        string dom = "";
        string paviljon = "";
        string maticniBr = "";
        public WorkingWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcherTimer.Start();
            
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            try
            {
                // datagrdTabela.Items.Clear();
                System.Data.DataTable dG = new System.Data.DataTable();
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();

                // MySqlCommand command = new MySqlCommand("select * from studenti", conn);

                MySqlDataAdapter sAdapter = new MySqlDataAdapter("Select ID,IME,PREZIME,MATICNI_BROJ,MJESTO_STANOVANJA,BROJ_TELEFONA,USLUGA,DATE_FORMAT(DATUM_ZADUZIVANJA, '%d/%m/%Y') as DATUM_ZADUZIVANJA From studenti", conn);
                sAdapter.Fill(dG);
                datagrdTabela.ItemsSource = dG.DefaultView;
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Greska: "  + e.Message.ToString());
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.ShowDialog();
            FillDataGrid();          
        }

        private void btnUkloni_Click(object sender, RoutedEventArgs e)
        {
           if (datagrdTabela.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
              
                MessageBoxResult message = MessageBox.Show("Da li ste sigurni da želite da uklonite studenta "+dataRow.Row.ItemArray[1].ToString() + " "+dataRow.Row.ItemArray[2].ToString()+"?", " ", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (message == MessageBoxResult.OK)
                {
                    try
                    { 
                        string cellValue = dataRow.Row.ItemArray[0].ToString();
                        maticniBr = dataRow.Row.ItemArray[3].ToString();

                        pronadjiStudenta();

                        MySqlConnection conn = new MySqlConnection(connstr);
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM studenti WHERE maticni_broj = " + (maticniBr), conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
  
                        oslobodiSobu();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                    FillDataGrid();
                }
                
            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
          
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           if(datagrdTabela.SelectedItem != null)
            {
                btnUkloni.IsEnabled = true;
                btnIzmijeni.IsEnabled = true;
            }
           else
            {
                btnUkloni.IsEnabled = false;
                btnIzmijeni.IsEnabled = false;
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)datagrdTabela.SelectedItem;
            //string cellValue = dataRow.Row.ItemArray[0].ToString();
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from studenti", conn);
            MySqlDataReader rReader = cmd.ExecuteReader();
            while(rReader.Read())
            {
                if(rReader[3].ToString() == dataRow.Row.ItemArray[3].ToString())
                {
                    Settings.Default.datum = rReader[10].ToString();
                    for (int i = 0, j = 0; i < dataRow.Row.ItemArray[7].ToString().Length; i++)
                    {
                        if (dataRow.Row.ItemArray[7].ToString()[i] != '/')
                        {
                            switch (j)
                            {
                                case 0:
                                    Settings.Default.dan += dataRow.Row.ItemArray[7].ToString()[i];
                                    break;
                                case 1:
                                    Settings.Default.mjesec += dataRow.Row.ItemArray[7].ToString()[i];
                                    break;
                                case 2:
                                    Settings.Default.godina += dataRow.Row.ItemArray[7].ToString()[i];
                                    break;
                            }
                        }
                        else
                        {
                            j++;
                        }
                    }

                    //MessageBox.Show(Settings.Default.dan + "." + Settings.Default.mjesec + "." + Settings.Default.godina);
                    AddWindow addWindow = new AddWindow(rReader[0].ToString(), rReader[1].ToString(), rReader[2].ToString(), rReader[3].ToString(), rReader[4].ToString(), rReader[5].ToString(), rReader[6].ToString(), rReader[7].ToString(), rReader[8].ToString(), rReader[9].ToString(), rReader[12].ToString(), rReader[13].ToString(), rReader[14].ToString());
                    addWindow.ShowDialog();
                    FillDataGrid();
                    this.Show();
                }
            }
            conn.Close();
        }

        private void ExportToExcel()
        {
            /*  datagrdTabela.SelectAllCells();
              datagrdTabela.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
              ApplicationCommands.Copy.Execute(null, datagrdTabela);
              String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
              String result = (string)Clipboard.GetData(DataFormats.Text);
              datagrdTabela.UnselectAllCells();
              System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\Intel\test.xls");
              file1.WriteLine(result.Replace(',', ' '));
              file1.Close();*/


            using (new WaitCursor())
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    excel.Visible = true;
                    Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < datagrdTabela.Columns.Count; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true;
                        sheet1.Columns[j + 1].ColumnWidth = 15;
                        myRange.Value2 = datagrdTabela.Columns[j].Header;
                    }
                    for (int i = 0; i < datagrdTabela.Columns.Count; i++)
                    {
                        for (int j = 0; j < datagrdTabela.Items.Count; j++)
                        {
                            TextBlock b = datagrdTabela.Columns[i].GetCellContent(datagrdTabela.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Greska: " + e.Message.ToString());
                }
            }

        }
        void oslobodiSobu()
        {
            int brSlobonihSoba = 0;
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sobe", conn);
            MySqlDataReader rReader = cmd.ExecuteReader();
            while (rReader.Read())
            {
                if (dom == rReader[1].ToString() && paviljon == rReader[2].ToString() && brSobe == rReader[3].ToString())
                {
                    try
                    {
                        brSlobonihSoba = Convert.ToInt32(rReader[5].ToString());
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Greska: " + error.Message.ToString());
                    }
                }
            }
            conn.Close();
            conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd2 = new MySqlCommand("UPDATE sobe SET slobodnih = REPLACE(slobodnih, '" + brSlobonihSoba + "', '" + (brSlobonihSoba + 1) + "') WHERE SOBA ='" + brSobe+ "' AND DOM = '" + dom + "' AND PAVILJON = '" + paviljon + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        void pronadjiStudenta()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from studenti", conn);
            MySqlDataReader rReader = cmd.ExecuteReader();

            while(rReader.Read())
            {
                if(maticniBr == rReader[3].ToString())
                {
                    dom = rReader[6].ToString();
                    paviljon = rReader[7].ToString();
                    brSobe = rReader[8].ToString();
                }
            }

            conn.Close();
        }
        private void btnIzvjestaj_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }

    }
}
