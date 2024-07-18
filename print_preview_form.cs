using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Form_Git_PhillMackinnon
{
    public partial class print_preview_form : Form
    {
        private string GetSelectedGroup()
        {
            if (Form2.form2 != null)
            {
                return Form2.form2.GetSelectedGroup();
            }
            else
            {
                return string.Empty;
            }
        }
        private DateTime dateTimePicker1()
        {
            if (Form2.form2 != null)
            {
                return Form2.form2.dateTimePicker1.Value;
            }
            else
            {
                return DateTime.Now;
            }

        }
        private DateTime dateTimePicker2()
        {
            if (Form2.form2 != null)
            {
                return Form2.form2.dateTimePicker2.Value;
            }
            else
            {
                return DateTime.Now;
            }

        }
        private bool Checkbox1Check()
        {
            if (Form2.form2 != null)
            {
                return Form2.form2.checkBox1.Checked;
            }
            else
            {
                return false;
            }
        }
        private bool Checkbox2Check()
        {
            if (Form2.form2 != null)
            {
                return Form2.form2.checkBox2.Checked;
            }
            else
            {
                return false;
            }
        }
        internal static Form1 form1;
        internal static Form2 form2;
        internal static LoginForm form3;
        internal static registrationform form4;
        internal static datagrid_form form5;
        internal static print_preview_form form6;
        private PrintDocument printDocument1;
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            string[] data = File.ReadAllLines("data");
            string dateString = DateTime.Parse(data[0]).ToShortDateString();
            string lessonString = data[1];
            string teacher = data[2];
            string subject = data[3];
            string ageCategory = data[4];
            string comments = data[5];
            string timehoursmin = data[6];
            string selectedGroup = GetSelectedGroup();
            DateTime startDate = dateTimePicker1();
            DateTime endDate = dateTimePicker2();
            bool isCheckbox1Checked = Checkbox1Check();
            bool isCheckbox2Checked = Checkbox2Check();
            Graphics g = e.Graphics;
            {
                        Image logo = Image.FromFile("logo.png");
                        float logoWidth = logo.Width * 0.25f;
                        float logoHeight = logo.Height * 0.25f;
                        float logoX = e.MarginBounds.Right - logoWidth;
                        float logoY = e.MarginBounds.Top;
                        e.Graphics.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);
                    
               

            float stringWidth = g.MeasureString("Selected group: " + selectedGroup, new Font("Arial", 12)).Width;
            float centerX = e.MarginBounds.Width / 2 - stringWidth / 2;

            g.DrawString("Selected group: " + selectedGroup, new Font("Arial", 12), Brushes.Black, new PointF(centerX, 60));

            float stringWidth2 = g.MeasureString("From: " + startDate.ToString("dd/MM/yyyy"), new Font("Arial", 12)).Width;
            float centerX2 = e.MarginBounds.Width / 2 - stringWidth2 / 2;

                g.DrawString("From: " + startDate.ToString("dd/MM/yyyy"), new Font("Arial", 12), Brushes.Black, new PointF(centerX2, 80));

                float stringWidth3 = g.MeasureString("To: " + endDate.ToString("dd/MM/yyyy"), new Font("Arial", 12)).Width;
                float centerX3 = e.MarginBounds.Width / 2 - stringWidth3 / 2;

                g.DrawString("To: " + endDate.ToString("dd/MM/yyyy"), new Font("Arial", 12), Brushes.Black, new PointF(centerX3, 100));

                float stringWidth4 = g.MeasureString("Date: " + dateString.ToString(), new Font("Arial", 12)).Width;
                float centerX4 = e.MarginBounds.Width / 2 - stringWidth4 / 2;

                g.DrawString("Date: " + dateString.ToString(), new Font("Arial", 12), Brushes.Black, new PointF(centerX4, 120));

                float stringWidth5 = g.MeasureString("Length: " + lessonString.ToString() + " minutes", new Font("Arial", 12)).Width;
                float centerX5 = e.MarginBounds.Width / 2 - stringWidth5 / 2;

                g.DrawString("Length: " + lessonString.ToString() + " minutes", new Font("Arial", 12), Brushes.Black, new PointF(centerX5, 140));

                float stringWidth6 = g.MeasureString("Professor: " + teacher, new Font("Arial", 12)).Width;
                float centerX6 = e.MarginBounds.Width / 2 - stringWidth6 / 2;

                g.DrawString("Professor: " + teacher, new Font("Arial", 12), Brushes.Black, new PointF(centerX6, 160));

                float stringWidth7 = g.MeasureString("Subject: " + subject, new Font("Arial", 12)).Width;
                float centerX7 = e.MarginBounds.Width / 2 - stringWidth7 / 2;

                g.DrawString("Subject: " + subject, new Font("Arial", 12), Brushes.Black, new PointF(centerX7, 180));
                isCheckbox1Checked = Checkbox1Check();
                float stringWidth11 = 0;
                if (isCheckbox1Checked == true)
                {
                    stringWidth11 = g.MeasureString("Organised Group: Yes✅", new Font("Arial", 12)).Width;
                    float centerX11 = e.MarginBounds.Width / 2 - stringWidth11 / 2;
                    g.DrawString("Organised Group: Yes✅", new Font("Arial", 12), Brushes.Black, new PointF(centerX11, 200));
                }
                else
                {
                    stringWidth11 = g.MeasureString("Organised Group: No❎", new Font("Arial", 12)).Width;
                    float centerX11 = e.MarginBounds.Width / 2 - stringWidth11 / 2;
                    g.DrawString("Organised Group: No❎", new Font("Arial", 12), Brushes.Black, new PointF(centerX11, 200));
                }

                float stringWidth8 = g.MeasureString("Age: " + ageCategory, new Font("Arial", 12)).Width;
                float centerX8 = e.MarginBounds.Width / 2 - stringWidth8 / 2;

                g.DrawString("Age: " + ageCategory, new Font("Arial", 12), Brushes.Black, new PointF(centerX8, 220));

                float stringWidth9 = g.MeasureString("Commentary: " + comments, new Font("Arial", 12)).Width;
                float centerX9 = e.MarginBounds.Width / 2 - stringWidth9 / 2;

                g.DrawString("Commentary: " + comments, new Font("Arial", 12), Brushes.Black, new PointF(centerX9, 240));

                float stringWidth10 = g.MeasureString("Time: " + timehoursmin, new Font("Arial", 12)).Width;
                float centerX10 = e.MarginBounds.Width / 2 - stringWidth10 / 2;

                g.DrawString("Time: " + timehoursmin, new Font("Arial", 12), Brushes.Black, new PointF(centerX10, 260));
                isCheckbox2Checked = Checkbox2Check();
                float stringWidth12 = 0;
                if (isCheckbox2Checked == true)
                {
                    stringWidth12 = g.MeasureString("Was Given: Yes✅", new Font("Arial", 12)).Width;
                    float centerX12 = e.MarginBounds.Width / 2 - stringWidth12 / 2;
                    g.DrawString("Was Given: Yes✅", new Font("Arial", 12), Brushes.Black, new PointF(centerX12, 280));
                }
                else
                {
                    stringWidth12 = g.MeasureString("Was Given: No❎", new Font("Arial", 12)).Width;
                    float centerX12 = e.MarginBounds.Width / 2 - stringWidth12 / 2;
                    g.DrawString("Was Given: No❎", new Font("Arial", 12), Brushes.Black, new PointF(centerX12, 300));
                }

            }
        }
        public print_preview_form()
        {
            InitializeComponent();
            printDocument1 = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printDocument1.PrintPage += printDocument1_PrintPage;


        }
        private void previewmethodHandler(object sender, PrintPageEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void print_preview_form_Load(object sender, EventArgs e)
        {
            if (Form2.form2 != null)
            {
                string selectedGroup = GetSelectedGroup();
                DateTime startDate = dateTimePicker1();
                DateTime endDate = dateTimePicker2();
                bool isCheckbox1Checked = Checkbox1Check();
                bool isCheckbox2Checked = Checkbox2Check();
            }
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printPreviewDialog.ShowDialog();
        }
    }
}
