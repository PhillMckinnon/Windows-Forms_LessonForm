using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Form_Git_PhillMackinnon
{
    public partial class datagrid_form : Form
    {
        public datagrid_form()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}
