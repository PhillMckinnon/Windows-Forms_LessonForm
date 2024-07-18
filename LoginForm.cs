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
    public partial class LoginForm : Form
    {
        Form1 mainForm = new Form1();
        private List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>();

        public LoginForm()
        {
            InitializeComponent();

            LoadUserData();
        }

        private void LoadUserData()
        {
            if (File.Exists("users"))
            {
                string[] lines = File.ReadAllLines("users");
                users = lines.Select(line => line.Split(':')).ToDictionary(parts => parts[0], parts => parts[1]).ToList();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Please fill all of the fields with correct data.");
                return;
            }

            KeyValuePair<string, string> user = new KeyValuePair<string, string>();
            foreach (var u in users)
            {
                if (u.Key == usernameTextBox.Text && u.Value == passwordTextBox.Text)
                {
                    user = u;
                    break;
                }
            }

            if (user.Key != null)
            {
                MessageBox.Show($"Successfully logged in {usernameTextBox.Text}.");

                this.Hide();
                if (mainForm == null)
                {
                    Form1 mainForm = new Form1();
                }
                mainForm.Show();


            }
            else
            {
                MessageBox.Show("Invalid password or username.");
            }
        }

        private void button_reg_Click(object sender, EventArgs e)
        {
            this.Hide();
            registrationform register = new registrationform();
            register.Show();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!passwordTextBox.Focused)
            {
                e.Handled = true;
            }
            else if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!usernameTextBox.Focused)
            {
                e.Handled = true;
            }
            else if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
