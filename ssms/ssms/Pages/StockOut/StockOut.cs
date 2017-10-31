using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace ssms.Pages.StockOut
{
    public partial class StockOut : UserControl
    {
        public StockOut()
        {
            InitializeComponent();
        }
        //Tiaan
        private void StockOut_Load(object sender, EventArgs e)
        {
            List<LTS.Item> item = new List<LTS.Item>();
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();
            List<LTS.BookOut> bookOut = new List<LTS.BookOut>();
            List<LTS.Product> product = new List<LTS.Product>();
            List<LTS.User> user = new List<LTS.User>();
            item = DAT.DataAccess.GetItem().Where(y => y.ItemStatus == false).ToList();
            barcode = DAT.DataAccess.GetBarcode().ToList();
            bookOut = DAT.DataAccess.GetBookOut().ToList();
            product = DAT.DataAccess.GetProduct();
            user = DAT.DataAccess.GetUser().ToList();
            for (int i = 0; i < bookOut.Count; i++)
            {
                LTS.Item it  = item.Where(a => a.ItemID == bookOut[i].ItemID).FirstOrDefault();
                LTS.Product p = product.Where(r => r.ProductID == it.ProductID).FirstOrDefault();
                LTS.Barcode b = barcode.Where(q => q.BarcodeID == p.BarcodeID).FirstOrDefault();
                LTS.User u = user.Where(w => w.UserID == bookOut[i].UserID).FirstOrDefault();

                
                dataGridView1.Rows.Add(bookOut[i].BookOutID, it.TagEPC, b.BarcodeNumber, p.ProductName,
                                       bookOut[i].Reason, bookOut[i].Project, bookOut[i].Date, u.UserName, u.UserSurname);
            }
        }

        
    

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.BookStockOut>();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOutUpdate>();
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockBookOutRemoval>();
        }

        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        //Margo
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
            string folderPath = saveFileDialog1.FileName + ".pdf";


            //Creating iTextSharp Table from the DataTable data
            Document pdfDoc = new Document(PageSize.A4);

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = dataGridView1.DefaultCellStyle.Padding.All;

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 0;



            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // pdfTable.AddCell(cell.Value.ToString());
                    PdfPCell cellRows = new PdfPCell(new Phrase(cell.Value.ToString(), font));
                    int R = cell.Style.BackColor.R;
                    int G = cell.Style.BackColor.G;
                    int B = cell.Style.BackColor.B;
                    if (R == 0 && G == 0 && B == 0)
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }
                    cellRows.BackgroundColor = new iTextSharp.text.BaseColor(R, G, B);
                    cellRows.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cellRows);

                }
            }
            Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Stock Book Out Information                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(writing);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }

        
    }
}

