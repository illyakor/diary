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
        private void ButtonRegistration(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && surnameTextBox.Text != "" && middleTextBox.Text != "" && loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                Dictionary<string, string> newUsers = DataRepository.ReadFileUser();
                newUsers[loginTextBox.Text] = passwordTextBox.Text;
                newUsers = DataRepository.WriteFileUser(newUsers);
                Dictionary<string, User> newUserProf = DataRepository.ReadFileProf();
                newUserProf[loginTextBox.Text] = new User(nameTextBox.Text, surnameTextBox.Text, middleTextBox.Text, dateTimePicker1.Text);
                newUserProf = DataRepository.WriteFileProf(newUserProf);
                MessageBox.Show(@"Вы успешно зарегистрированы!");
            }
            else MessageBox.Show(@"Заполнение всех полей обязательно!");
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            General.GetGeneral().Show();
            this.Close();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputProtection.TextBox_KeyPress(sender, e);
        }
        private void LoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputProtection.LoginTextBox_KeyPress(sender, e);
        }
        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputProtection.PasswordTextBox_KeyPress(sender, e);
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