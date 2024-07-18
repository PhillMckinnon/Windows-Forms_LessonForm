using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Form_Git_PhillMackinnon
{
    public partial class Form1 : Form
    {
        internal static Form1 form1;
        internal static Form2 form2;
        internal static LoginForm form3;
        internal static registrationform form4;
        internal static datagrid_form form5;
        internal static print_preview_form form6;
        public Form1()
        {
            InitializeComponent();
            TimePicker.Format = DateTimePickerFormat.Custom;
            TimePicker.CustomFormat = "HH:mm";
            reportButton.Enabled = false;
            //Checkbox for if the lesson/lecture was given or not
            checkBox2.Checked = false;
            form1 = this;
            if (!File.Exists("ages"))
            {
                string[] ages = new string[]
                {
                    "5-7",
                    "8-11",
                    "12-15"
                };
                File.WriteAllLines("ages", ages);
            }
            if (!File.Exists("teachers"))
            {

                string[] teachers = new string[]
                {
                "Peter Python",
                "Viktor Pascal",
                "Jane Engineer",
                "John Programmer",
                "Alexander Ceesharp",
                "William Javascript"
                };
                File.WriteAllLines("teachers", teachers);
            }


            if (!File.Exists("subjects"))
            {

                string[] subjects = new string[]
                {
                "3D in TinkerCad",
                "Roblox Studio",
                "Kodu Game Lab",
                "Game Creating Platform Construct",
                "Tilda",
                "Wordpress",
                "Figma"
                };
                File.WriteAllLines("subjects", subjects);
            }
            if (File.Exists("teachers"))
            {

                string[] teachers = File.ReadAllLines("teachers");
                teacherComboBox.Items.AddRange(teachers);
            }

            if (File.Exists("subjects"))
            {

                string[] subjects = File.ReadAllLines("subjects");


                subjectComboBox.Items.AddRange(subjects);
            }
            if (File.Exists("subjects"))
            {

                string[] ages = File.ReadAllLines("ages");


                ageCategoryComboBox.Items.AddRange(ages);
            }
        }
        private bool ValidateData()
        {
            if (ValidateDateTime() == false)
            {
                return false;

            }

            if (string.IsNullOrEmpty(dateDateTimePicker.Text) ||
                string.IsNullOrEmpty(numericUpDown1.Text) ||
                teacherComboBox.SelectedItem == null ||
                TimePicker.Text == null ||
                subjectComboBox.SelectedItem == null ||
                ageCategoryComboBox.SelectedItem == null ||
                string.IsNullOrEmpty(commentsTextBox.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ValidateDateTime()
        {
            if (!DateTime.TryParse(TimePicker.Text, out DateTime enteredTime))
            {
                return false;
            }

            TimeSpan startTime = new TimeSpan(9, 0, 0); // 09:00:00
            TimeSpan endTime = new TimeSpan(20, 0, 0); // 20:00:00
            TimeSpan enteredTimeSpan = enteredTime.TimeOfDay;

            if (enteredTimeSpan < startTime || enteredTimeSpan > endTime)
            {
                return false;
            }

            return true;
        }
        protected void savebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to save the entered data?", "Saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (ValidateData() == false)
                {
                    MessageBox.Show("Please fill all of the fields with correct data.");
                }
                else
                {
                    DateTime date = dateDateTimePicker.Value.Date;
                    int lessonlength = (int)numericUpDown1.Value;
                    string teacher = teacherComboBox.SelectedItem.ToString();
                    string subject = subjectComboBox.SelectedItem.ToString();
                    string ageCategory = ageCategoryComboBox.SelectedItem.ToString();
                    string comments = commentsTextBox.Text;
                    string timehoursmin = TimePicker.Text;
                    string checkedbox1string = "";
                    string checkedbox2string = "";
                    if (checkBox1.Checked == true)
                    {
                        checkedbox1string = "Yes";
                    }
                    else
                    {
                        checkedbox1string = "No";
                    }
                    if (checkBox2.Checked == true)
                    {
                        checkedbox2string = "Yes";
                    }
                    else
                    {
                        checkedbox2string = "No";
                    }

                    reportButton.Enabled = true;
                    SaveDataToTxt(date, lessonlength, teacher, subject, ageCategory, comments, timehoursmin, checkedbox1string, checkedbox2string);
                    LoadDataGrid();
                    Form2 reportForm = new Form2();
                }
            }
        }
        private void LoadDataGrid()
        {
            label9.BackColor = Color.Transparent;
            if (File.Exists("data"))
            {
                string[] data = File.ReadAllLines("data");
                if (data != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[]
                    {
                new DataColumn("Date", typeof(DateTime)),
                new DataColumn("Length", typeof(int)),
                new DataColumn("Professor", typeof(string)),
                new DataColumn("Subject", typeof(string)),
                new DataColumn("Age", typeof(string)),
                new DataColumn("Commentary", typeof(string)),
                new DataColumn("Time (Hour:Min)", typeof(string)),
                new DataColumn("Organised Group", typeof(string)),
                new DataColumn("Was Given", typeof(string))
                    });
                    dt.Rows.Add(
                        DateTime.Parse(data[0]),
                        int.Parse(data[1]),
                        data[2],
                        data[3],
                        data[4],
                        data[5],
                        data[6],
                        data[7],
                        data[8]
                    );
                    dataGridView1.DataSource = dt;
                }
            }
        }
        public void SaveDataToTxt(DateTime date, int lessonlength, string teacher, string subject, string ageCategory, string comments, string timehoursmin, string checkedbox1string, string checkedbox2string)
        {
            string[] data = new string[] {
            date.ToString(),
            lessonlength.ToString(),
            teacher,
            subject,
            ageCategory,
            comments,
            timehoursmin,
            checkedbox1string,
            checkedbox2string
        };

            File.WriteAllLines("data", data);
        }
        private void clearallbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you certain that you want to clear all entered data?", "Clear Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ClearFields();
            }
        }
        private void ClearFields()
        {
            dateDateTimePicker.Text = "";
            numericUpDown1.Value = 0;
            teacherComboBox.SelectedItem = null;
            subjectComboBox.SelectedItem = null;
            ageCategoryComboBox.SelectedItem = null;
            commentsTextBox.Text = "";
            TimePicker.Text = "";
            checkBox1.Checked = false;
            reportButton.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            checkBox2.Checked = false;

        }
        public bool isitchecked()
        {
            return checkBox1.Checked;
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 reportForm = new Form2();
            reportForm.Show();
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you sure that you want to quit?", "Exit Program?", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }

        private void CloseAllForms()
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (reportButton.Enabled == false)
            {

            }
            else
            {
                datagrid_form datagridshow = new datagrid_form();
                datagridshow.Show();
            }

        }

        private void teacherComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
