using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Print_Form_Git_PhillMackinnon
{
    public partial class Form2 : Form
    {

        internal static Form1 form1;
        internal static Form2 form2;
        internal static LoginForm form3;
        internal static registrationform form4;
        internal static datagrid_form form5;
        private float textY;
        print_preview_form printshown = new print_preview_form();



        public DateTime date { get; set; }
        public int studentsCount { get; set; }
        public string teacher { get; set; }
        public string subject { get; set; }
        public string ageCategory { get; set; }
        public string comments { get; set; }
        public Form2()
        {
            InitializeComponent();
            if (!Form1.form1.isitchecked())
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            if (Form1.form1.checkBox2.Checked == false)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Value = DateTime.Now;

            string[] data = File.ReadAllLines("data");
            if (data != null)
            {
                string dateString = DateTime.Parse(data[0]).ToShortDateString();
                string lessonString = data[1];
                string teacher = data[2];
                string subject = data[3];
                string ageCategory = data[4];
                string comments = data[5];
                string timehoursmin = data[6];
                Action setValues = () =>
                {
                    textBox1.Text = teacher;
                    textBox2.Text = subject;
                    textBox3.Text = ageCategory;
                    commentsTextBox.Text = comments;
                    textBox5.Text = timehoursmin;
                    textBox6.Text = lessonString;
                    textBox4.Text = dateString;
                    printbtn.Enabled = false;
                };
                if (InvokeRequired)
                {
                    BeginInvoke(setValues);
                }
                else
                {
                    setValues();
                }
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {



        }
        public string GetSelectedGroup()
        {

            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            else
            {
                return radioButton3.Text;
            }
        }
        private void ClearAndReinitializePrintshown()
        {

            print_preview_form printshown = new print_preview_form();


            this.Controls.Add(printshown);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                printshown.Show();
                printshown.Hide();
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = new PrintDocument();

                printDialog.Document.PrintPage += new PrintPageEventHandler(PrintPageHandler);


                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    PrinterSettings printerSettings = printDialog.PrinterSettings;

                    printDialog.Document.Print();

                    MessageBox.Show("Form data was printed on " + printerSettings.PrinterName);
                    print_preview_form printshown = new print_preview_form();
                }
                if (printDialog.ShowDialog() == DialogResult.Cancel)
                {



                    MessageBox.Show("Form data was NOT printed");
                    printbtn.Enabled = false;
                }
                else
                {
                    print_preview_form printshown = new print_preview_form();
                    printbtn.Enabled = false;
                }
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();


                printDialog.Document = new PrintDocument();

                printDialog.Document.PrintPage += new PrintPageEventHandler(PrintPageHandler);

                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    PrinterSettings printerSettings = printDialog.PrinterSettings;

                    printDialog.Document.Print();

                    MessageBox.Show("Form data was printed on " + printerSettings.PrinterName);
                    printbtn.Enabled = false;
                }
            }
        }
        private void PrintPreviewForm()
        {

        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            string[] data = File.ReadAllLines("data");
            string dateString = DateTime.Parse(data[0]).ToShortDateString();
            string lessonString = data[1];
            string teacher = data[2];
            string subject = data[3];
            string ageCategory = data[4];
            string comments = data[5];
            string timehoursmin = data[6];
            Graphics g = e.Graphics;
            string selectedGroup = GetSelectedGroup();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
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
            bool isCheckbox1Checked = checkBox1.Checked;
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
            bool isCheckbox2Checked = checkBox2.Checked;
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


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form1.Show();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to revert entered data", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }

        }

        private void printbtn_Click(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {

                DialogResult result = MessageBox.Show("Are you certain that you want to save the entered data?", "Saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    RadioButton[] radioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton3 };

                    if (!Enumerable.Range(0, 3).Any(i => radioButtons[i].Checked))
                    {
                        MessageBox.Show("Please fill all of the fields with correct data.");
                    }
                    else
                    {
                        printbtn.Enabled = true;
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you certain that you want to save the entered data?", "Saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    RadioButton[] radioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton3 };

                    if (!Enumerable.Range(0, 3).Any(i => radioButtons[i].Checked))
                    {
                        MessageBox.Show("Please fill all of the fields with correct data. (Check for: Group, No Group, Both)");
                    }
                    else
                    {
                        printbtn.Enabled = true;
                    }
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Tolabel_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void checked3()
        {
            checkBox4.Checked = false;
        }
        private void checked4()
        {
            checkBox3.Checked = false;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checked3();
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checked4();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you certain that you want to close the program?", "Exit?", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }

    }

}
