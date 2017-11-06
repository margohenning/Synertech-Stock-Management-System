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

namespace ssms.Pages
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<lblID>();
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateUser>();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<DeactivateUser>();
        }


        //Devon
        private void Users_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        //Devon
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    List<LTS.User> user = new List<LTS.User>();
                    user = DAT.DataAccess.GetUser().ToList();
                    for (int i = 0; i < user.Count; i++)
                    {
                        dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                            user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
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
                    List<LTS.User> user = new List<LTS.User>();
                    user = DAT.DataAccess.GetUser().Where(s => s.UserActivated == true).ToList();//list from db
                    for (int i = 0; i < user.Count; i++)
                    {
                        dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                            user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
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
                    List<LTS.User> user = new List<LTS.User>();
                    user = DAT.DataAccess.GetUser().Where(s => s.UserActivated == false).ToList();//list from db
                    for (int i = 0; i < user.Count; i++)
                    {
                        dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                            user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
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
                    what = "Activated";
                }
                else if (radioButton4.Checked == true)
                {
                    what = "Deactivated";
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
                Paragraph writing = new iTextSharp.text.Paragraph("Synertech Stock Management System " + Environment.NewLine + "Users Information: " + what + "                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

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
