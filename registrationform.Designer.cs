
namespace Print_Form_Git_PhillMackinnon
{
    partial class registrationform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.username_label = new System.Windows.Forms.Label();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.register_btn = new System.Windows.Forms.Button();
            this.button_log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(193, 124);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 23);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(193, 49);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 23);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameTextBox_KeyPress);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(211, 31);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(60, 15);
            this.username_label.TabIndex = 4;
            this.username_label.Text = "Username";
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(214, 106);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(57, 15);
            this.passwordlabel.TabIndex = 4;
            this.passwordlabel.Text = "Password";
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.register_btn.Location = new System.Drawing.Point(179, 193);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(132, 23);
            this.register_btn.TabIndex = 5;
            this.register_btn.Text = "Register";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // button_log
            // 
            this.button_log.BackColor = System.Drawing.Color.Gainsboro;
            this.button_log.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_log.Location = new System.Drawing.Point(366, 242);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(132, 23);
            this.button_log.TabIndex = 12;
            this.button_log.Text = "Log in";
            this.button_log.UseVisualStyleBackColor = false;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // registrationform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(510, 277);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.register_btn);
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "registrationform";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.Button button_log;
    }
}