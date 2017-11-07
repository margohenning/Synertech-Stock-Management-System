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
using iTextSharp.text.pdf;
using System.IO;
using ssms.DataClasses;

namespace ssms.Pages.Products
{
    public partial class Product : UserControl
    {
        List<ProductMain> pm = new List<ProductMain>();
        public Product()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
           ((Main)this.Parent.Parent).ChangeView<AddProduct>();
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateProduct>();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Categories>();
        }

        //Margo
        private void button5_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Brands>();
        }

        //Marius
        private void Product_Load(object sender, EventArgs e)
        {
            try
            {
                List<LTS.Product> prod = new List<LTS.Product>();
                prod = DAT.DataAccess.GetProduct().ToList();

                for (int i = 0; i < prod.Count; i++)
                {
                    ProductMain pmThis = new ProductMain();
                    pmThis.ProductID = prod[i].ProductID;
                    pmThis.ProductName = prod[i].ProductName;
                    pmThis.ProductDescription = prod[i].ProductDescription;
                    pmThis.CategoryID = prod[i].CategoryID;
                    pmThis.BrandID = prod[i].BrandID;
                    pmThis.BarcodeID = prod[i].BarcodeID;

                    pmThis.amountItems = DAT.DataAccess.GetItem().Where(u => u.ProductID == pmThis.ProductID && u.ItemStatus == true).ToList().Count;

                    LTS.Category c = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == prod[i].CategoryID).FirstOrDefault();
                    pmThis.CategoryName = c.CategoryName;
                    pmThis.CategoryDescription = c.CategoryDescription;

                    LTS.Brand b = DAT.DataAccess.GetBrand().Where(o => o.BrandID == prod[i].BrandID).FirstOrDefault();
                    pmThis.BrandName = b.BrandName;
                    pmThis.BrandDescription = b.BrandDescription;

                    LTS.Barcode bar = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeID == prod[i].BarcodeID).FirstOrDefault();
                    pmThis.BarcodeNumber = bar.BarcodeNumber;

                    pm.Add(pmThis);

                    dgvProducts.Rows.Add(pmThis.ProductID, pmThis.ProductName, pmThis.ProductDescription, pmThis.BarcodeNumber, pmThis.BrandName, pmThis.CategoryName, pmThis.amountItems);

                }
                dgvProducts.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }
        
        
        
        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        //Margo
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
                string folderPath = saveFileDialog1.FileName + ".pdf";


                //Creating iTextSharp Table from the DataTable data
                Document pdfDoc = new Document(PageSize.A4);

                PdfPTable pdfTable = new PdfPTable(dgvProducts.ColumnCount);
                pdfTable.DefaultCell.Padding = dgvProducts.DefaultCellStyle.Padding.All;

                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;



                //Adding Header row
                foreach (DataGridViewColumn column in dgvProducts.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dgvProducts.Rows)
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
                Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Products Information                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }
    }
}
