using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssms.DataClasses;

using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;


namespace ssms.Pages.Items
{
    public partial class Items : UserControl
    {
        List<ItemMain> imList = new List<ItemMain>();
        public Items()
        {
            InitializeComponent();

          
        }

        //Devon
        private void Stock_Load(object sender, EventArgs e)
        {

            radioButton1.Checked = true;

        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddStock>();
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateStock>();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ViewItemsPerStore>();
        }

        //Margo
        private void button5_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ScanItemsInStore>();
        }


        //Devon
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    List<LTS.Item> i = new List<LTS.Item>();
                    i = DAT.DataAccess.GetItem().ToList();//list from db
                    List<ItemMain> imList = new List<ItemMain>();

                    for (int x = 0; x < i.Count; x++)
                    {
                        ItemMain im = new ItemMain();
                        //assign the item info to the ItemMain object
                        im.itemID = i[x].ItemID;
                        im.EPC = i[x].TagEPC;
                        im.ItemStatus = i[x].ItemStatus;
                        im.ProductID = i[x].ProductID;
                        im.StoreID = i[x].StoreID;

                        //get the specific product and assign the info to the ItemMain object
                        LTS.Product p = new LTS.Product();
                        p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
                        im.ProductName = p.ProductName;
                        im.ProductDescription = p.ProductDescription;
                        im.BrandID = p.BrandID;
                        im.CategoryID = p.CategoryID;
                        im.BarcodeID = p.BarcodeID;

                        //get the specific store and assign the info to the ItemMain object
                        LTS.Store s = new LTS.Store();
                        s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
                        im.StoreName = s.StoreName;
                        im.StoreLocation = s.StoreLocation;

                        //get the specific brand and assign the info to the ItemMain object
                        LTS.Brand b = new LTS.Brand();
                        b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
                        im.BrandName = b.BrandName;
                        im.BrandDescription = b.BrandDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Category c = new LTS.Category();
                        c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
                        im.CategoryName = c.CategoryName;
                        im.CategoryDescription = c.CategoryDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Barcode ba = new LTS.Barcode();
                        ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
                        im.BarcodeNumber = ba.BarcodeNumber;

                        imList.Add(im);
                        dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                            , im.ItemStatus, im.StoreName);

                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        //Devon
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked)
                {
                    List<LTS.Item> i = new List<LTS.Item>();
                    i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == true).ToList();//list from db
                    List<ItemMain> imList = new List<ItemMain>();

                    for (int x = 0; x < i.Count; x++)
                    {
                        ItemMain im = new ItemMain();
                        //assign the item info to the ItemMain object
                        im.itemID = i[x].ItemID;
                        im.EPC = i[x].TagEPC;
                        im.ItemStatus = i[x].ItemStatus;
                        im.ProductID = i[x].ProductID;
                        im.StoreID = i[x].StoreID;

                        //get the specific product and assign the info to the ItemMain object
                        LTS.Product p = new LTS.Product();
                        p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
                        im.ProductName = p.ProductName;
                        im.ProductDescription = p.ProductDescription;
                        im.BrandID = p.BrandID;
                        im.CategoryID = p.CategoryID;
                        im.BarcodeID = p.BarcodeID;

                        //get the specific store and assign the info to the ItemMain object
                        LTS.Store s = new LTS.Store();
                        s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
                        im.StoreName = s.StoreName;
                        im.StoreLocation = s.StoreLocation;

                        //get the specific brand and assign the info to the ItemMain object
                        LTS.Brand b = new LTS.Brand();
                        b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
                        im.BrandName = b.BrandName;
                        im.BrandDescription = b.BrandDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Category c = new LTS.Category();
                        c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
                        im.CategoryName = c.CategoryName;
                        im.CategoryDescription = c.CategoryDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Barcode ba = new LTS.Barcode();
                        ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
                        im.BarcodeNumber = ba.BarcodeNumber;

                        imList.Add(im);
                        dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                            , im.ItemStatus, im.StoreName);
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        //Devon
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    List<LTS.Item> i = new List<LTS.Item>();
                    i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == false).ToList();//list from db
                    List<ItemMain> imList = new List<ItemMain>();

                    for (int x = 0; x < i.Count; x++)
                    {
                        ItemMain im = new ItemMain();
                        //assign the item info to the ItemMain object
                        im.itemID = i[x].ItemID;
                        im.EPC = i[x].TagEPC;
                        im.ItemStatus = i[x].ItemStatus;
                        im.ProductID = i[x].ProductID;
                        im.StoreID = i[x].StoreID;

                        //get the specific product and assign the info to the ItemMain object
                        LTS.Product p = new LTS.Product();
                        p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
                        im.ProductName = p.ProductName;
                        im.ProductDescription = p.ProductDescription;
                        im.BrandID = p.BrandID;
                        im.CategoryID = p.CategoryID;
                        im.BarcodeID = p.BarcodeID;

                        //get the specific store and assign the info to the ItemMain object
                        LTS.Store s = new LTS.Store();
                        s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
                        im.StoreName = s.StoreName;
                        im.StoreLocation = s.StoreLocation;

                        //get the specific brand and assign the info to the ItemMain object
                        LTS.Brand b = new LTS.Brand();
                        b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
                        im.BrandName = b.BrandName;
                        im.BrandDescription = b.BrandDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Category c = new LTS.Category();
                        c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
                        im.CategoryName = c.CategoryName;
                        im.CategoryDescription = c.CategoryDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Barcode ba = new LTS.Barcode();
                        ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
                        im.BarcodeNumber = ba.BarcodeNumber;

                        imList.Add(im);
                        dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                            , im.ItemStatus, im.StoreName);

                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
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
                string what = "";
                if (radioButton1.Checked == true)
                {
                    what = "All";
                }
                else if (radioButton2.Checked == true)
                {
                    what = "Items in stock";
                }
                else if (radioButton4.Checked == true)
                {
                    what = "Items out of stock";
                }
                else
                {
                    what = "All";
                }
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
                Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Items Information: " + what + "                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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
