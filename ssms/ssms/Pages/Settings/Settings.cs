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
using ssms.DataClasses;

namespace ssms.Pages.Settings
{
    public partial class Settings : UserControl
    {
        //Margo
        List<SettingsMain> settings = new List<SettingsMain>();

        public Settings()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddSettings>();
        }

        //Margo
        private void button1_Click_1(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<SelectSetting>();
        }

        //Margo
        private void buttonUpdateSettings_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateSettings>();
        }

        //Margo
        private void buttonExportPDF_Click(object sender, EventArgs e)
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

                PdfPTable pdfTable = new PdfPTable(dataGridViewSettings.ColumnCount);
                pdfTable.DefaultCell.Padding = dataGridViewSettings.DefaultCellStyle.Padding.All;

                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;



                //Adding Header row
                foreach (DataGridViewColumn column in dataGridViewSettings.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dataGridViewSettings.Rows)
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
                Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Settings Information                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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

        //Margo
        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                List<LTS.Settings> set = new List<LTS.Settings>();
                set = DAT.DataAccess.GetSettings().ToList();

                for (int x = 0; x < set.Count; x++)
                {
                    SettingsMain sm = new SettingsMain();
                    sm.SettingsID = set[x].SettingsID;
                    sm.SettingsName = set[x].SettingsName;
                    sm.SettingsSelect = set[x].SettingsSelect;
                    sm.StoreID = set[x].StoreID;

                    LTS.Store store = DAT.DataAccess.GetStore().Where(i => i.StoreID == sm.StoreID).FirstOrDefault();
                    sm.StoreLocation = store.StoreLocation;
                    sm.StoreName = store.StoreName;

                    List<LTS.Reader> readers = new List<LTS.Reader>();
                    readers = DAT.DataAccess.GetReader().Where(j => j.SettingsID == sm.SettingsID).ToList();
                    for (int j = 0; j < readers.Count; j++)
                    {
                        ReaderMain rm = new ReaderMain();
                        rm.ReaderID = readers[j].ReaderID;
                        rm.IPaddress = readers[j].IPaddress;
                        rm.NumAntennas = readers[j].NumAntennas;
                        rm.antennas = DAT.DataAccess.GetAntenna().Where(q => q.ReaderID == rm.ReaderID).ToList();

                        sm.Readers.Add(rm);

                    }

                    settings.Add(sm);

                }

                for (int i = 0; i < settings.Count; i++)
                {
                    dataGridViewSettings.Rows.Add(settings[i].SettingsID, settings[i].SettingsName, settings[i].SettingsSelect, settings[i].Readers.Count, settings[i].TotalAmountAntennas().ToString(), settings[i].StoreName);
                }
                dataGridViewSettings.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           


        }
    }
}
