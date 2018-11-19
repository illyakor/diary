using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace TRPO
{
    public partial class Registration : Form
    {
        public Registration(string textbox1, string textbox2, DateTime datetimepicker1)
        {
            InitializeComponent();
            nameTextBox.Text = textbox1;
            surnameTextBox.Text = textbox2;
            dateTimePicker1.Value = datetimepicker1;

        }
        private void Label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            General form1 = new General();
            form1.Show();
        }
        //Dictionary<string, string> newUsers = new Dictionary<string, string>();
        private void ButtonRegistration(object sender, EventArgs e)
        {
            General gen = new General();
            Dictionary<string, string> newUsers = gen.GetUser;
            newUsers.Add(loginTextBox.Text, passwordTextBox.Text);
            DataContractJsonSerializer jsonFormatter0 = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter0.WriteObject(fs, newUsers);
            }
            Dictionary<string, User> newUserProf = new Dictionary<string, User>
            { [loginTextBox.Text] = new User(nameTextBox.Text, surnameTextBox.Text, middleTextBox.Text, dateTimePicker1.Text) };
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, User[]>));
            using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, newUserProf);
            }
            if (nameTextBox.Text != "" && surnameTextBox.Text != "" && middleTextBox.Text != "" && loginTextBox.Text != "" && 
                passwordTextBox.Text != "")
            {
                
            }
            else MessageBox.Show(@"Заполнение всех полей обязательно!");
        }
        //public Dictionary<string, string> GetUser => newUsers;
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '`' && e.KeyChar != '-')
                e.Handled = true;
        }
        private void LoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '`')
                e.Handled = true;
        }
        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58))
                e.Handled = true;
        }
        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Blue;
            Font underlineFont = new Font(DefaultFont.Name, DefaultFont.Size, FontStyle.Underline, DefaultFont.Unit, DefaultFont.GdiCharSet, DefaultFont.GdiVerticalFont);
            ((Label)sender).Font = underlineFont;
        }
        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.White;
            ((Label)sender).Font = DefaultFont;
        }
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.DarkGreen;
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
        }
    }
}