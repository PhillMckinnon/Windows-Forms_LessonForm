using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Form_Git_PhillMackinnon
{
    public partial class registrationform : Form
    {
        private List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>();

        public registrationform()
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

        private void SaveUserData()
        {
            File.WriteAllLines("users", users.Select(user => $"{user.Key}:{user.Value}"));
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Please fill all of the fields with correct data.");
                return;
            }


            if (users.Any(user => user.Key == usernameTextBox.Text))
            {
                MessageBox.Show("This username is already taken.");
                return;
            }

            users.Add(new KeyValuePair<string, string>(usernameTextBox.Text, passwordTextBox.Text));

            SaveUserData();

            MessageBox.Show("Successfully registered.");
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
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
