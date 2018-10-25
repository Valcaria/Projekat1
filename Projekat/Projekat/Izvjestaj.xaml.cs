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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Izvjestaj.xaml
    /// </summary>
    public partial class Izvjestaj : System.Windows.Window
    {
        private System.Data.DataTable dataTable;
        private string pom;
        public Izvjestaj(System.Data.DataTable dataTable, string pom)
        {
            InitializeComponent();
            this.dataTable = dataTable;
            this.pom = pom;
            imgPdf.Source = new ImageSourceConverter().ConvertFromString(@"..\..\Resources\pdf.png") as ImageSource;
            imgExcel.Source = new ImageSourceConverter().ConvertFromString(@"..\..\Resources\excel.png") as ImageSource;
        }


        public void ExportToPdf(System.Data.DataTable dt)
        {

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvjestaj"; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension

            // save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            try
            {

                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;

                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                    document.AddTitle("Izvjestaj");

                    document.AddCreationDate();

                    document.Open();
                    iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

                    PdfPTable table = new PdfPTable(dt.Columns.Count);

                    if (pom == "_Arhiva")
                    {
                        float[] widths = new float[] { 1f, 3f, 3f, 3f, 4f, 3f, 3f, 4f };
                        table.SetWidths(widths);

                        table.WidthPercentage = 100;
                        PdfPCell cell = new PdfPCell(new Phrase("Elementi"));

                        cell.Colspan = dt.Columns.Count;

                        foreach (DataColumn c in dt.Columns)
                        {

                            table.AddCell(new Phrase(c.ColumnName, font5));
                        }

                        foreach (DataRow r in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                table.AddCell(new Phrase(r[0].ToString(), font5));
                                table.AddCell(new Phrase(r[1].ToString(), font5));
                                table.AddCell(new Phrase(r[2].ToString(), font5));
                                table.AddCell(new Phrase(r[3].ToString(), font5));
                                table.AddCell(new Phrase(r[4].ToString(), font5));
                                table.AddCell(new Phrase(r[5].ToString(), font5));
                                table.AddCell(new Phrase(r[6].ToString(), font5));
                                table.AddCell(new Phrase(r[7].ToString(), font5));
                            }
                        }


                    }
                    else
                    {
                        float[] widths = new float[] { 1f, 3f, 3f, 3f, 4f, 3f, 3f, 4f, 4f };
                        table.SetWidths(widths);

                        table.WidthPercentage = 100;
                        // int iCol = 0;
                        // string colname = "";
                        PdfPCell cell = new PdfPCell(new Phrase("Elementi"));

                        cell.Colspan = dt.Columns.Count;

                        foreach (DataColumn c in dt.Columns)
                        {

                            table.AddCell(new Phrase(c.ColumnName, font5));
                        }

                        foreach (DataRow r in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                table.AddCell(new Phrase(r[0].ToString(), font5));
                                table.AddCell(new Phrase(r[1].ToString(), font5));
                                table.AddCell(new Phrase(r[2].ToString(), font5));
                                table.AddCell(new Phrase(r[3].ToString(), font5));
                                table.AddCell(new Phrase(r[4].ToString(), font5));
                                table.AddCell(new Phrase(r[5].ToString(), font5));
                                table.AddCell(new Phrase(r[6].ToString(), font5));
                                table.AddCell(new Phrase(r[7].ToString(), font5));
                                table.AddCell(new Phrase(r[8].ToString(), font5));

                            }
                        }


                    }
                    //dodavanje naslova

                    iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                    iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 12);
                    iTextSharp.text.Paragraph title;
                    iTextSharp.text.Paragraph text;
                    title = new iTextSharp.text.Paragraph("Izvještaj", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    text = new iTextSharp.text.Paragraph("Datum:_____________", regularFont);
                    text.Alignment = Element.ALIGN_RIGHT;
                    document.Add(text);
                    document.Add(new iTextSharp.text.Paragraph(" "));
                    document.Add(new iTextSharp.text.Paragraph(" "));

                    document.Add(table);
                    document.Close();
                    this.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }





        private void ExportToExcel(System.Data.DataTable dataTable)
        {
            using (new ProjekatTMP.WaitCursor())//Poziv wait cursora
            {
                Microsoft.Office.Interop.Excel.Application excel = null;
                Microsoft.Office.Interop.Excel.Workbook wb = null;

                object missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Worksheet ws = null;
                Microsoft.Office.Interop.Excel.Range rng = null;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    wb = excel.Workbooks.Add();
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

                    for (int Idx = 0; Idx < dataTable.Columns.Count; Idx++)
                    {
                        ws.Range["A1"].Offset[0, Idx].Value = dataTable.Columns[Idx].ColumnName;
                        ws.Cells[1, Idx + 1].Font.Bold = true;
                        ws.Columns[Idx + 1].ColumnWidth = 20;
                    }

                    for (int Idx = 0; Idx < dataTable.Rows.Count; Idx++)
                    {  
                        string d = "D" + (Idx + 2), f = "F" + (Idx + 2);

                        ws.Range[d].NumberFormat = "@";
                        ws.Range[f].NumberFormat = "@";

                        ws.Range["A2"].Offset[Idx].Resize[1, dataTable.Columns.Count].Value =
                        dataTable.Rows[Idx].ItemArray;
                    }

                    excel.Visible = true;
                    wb.Activate();
                    this.Close();
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show("Error accessing Excel: " + ex.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }

        }

        private void imgPdf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ExportToPdf(dataTable);
        }

        private void imgExcel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ExportToExcel(dataTable);
        }
    }
}

