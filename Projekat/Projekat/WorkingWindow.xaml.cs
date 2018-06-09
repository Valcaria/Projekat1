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
using MySql.Data.MySqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace projekatTMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkingWindow : System.Windows.Window
    {
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
            // datagrdTabela.Items.Clear();
            System.Data.DataTable dG = new System.Data.DataTable();
            string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

           // MySqlCommand command = new MySqlCommand("select * from studenti", conn);
            
            MySqlDataAdapter sAdapter = new MySqlDataAdapter("select * from studenti",conn);
            sAdapter.Fill(dG);
            
            

            datagrdTabela.ItemsSource = dG.DefaultView;

            conn.Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            

            Projekat.AddWindow add = new Projekat.AddWindow();
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
                    string connstr = "Server=localhost;Uid=root;pwd= ;database=projekat1;SslMode=none";
                    MySqlConnection conn = new MySqlConnection(connstr);
                    conn.Open();
                    string cellValue = dataRow.Row.ItemArray[0].ToString();
                    MySqlCommand komanda = new MySqlCommand("DELETE FROM studenti WHERE ID = " + (cellValue), conn);
                    komanda.ExecuteNonQuery();

                    conn.Close();
                    FillDataGrid();
                }
                
            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            Projekat.MainWindow main = new Projekat.MainWindow();
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
          //  string cellValue = dataRow.Row.ItemArray[0].ToString();
            Projekat.AddWindow addWindow = new Projekat.AddWindow(dataRow.Row.ItemArray[0].ToString(), dataRow.Row.ItemArray[1].ToString(), dataRow.Row.ItemArray[2].ToString(), dataRow.Row.ItemArray[3].ToString(), dataRow.Row.ItemArray[4].ToString(), dataRow.Row.ItemArray[5].ToString(), dataRow.Row.ItemArray[6].ToString());
            addWindow.ShowDialog();
            FillDataGrid();

            this.Show();
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

        private void btnIzvjestaj_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
    }
}
