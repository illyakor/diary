using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRPO
{
    public partial class Registration : Form
    {
        public Registration(string textbox1, string textbox2, DateTime datetimepicker1)
        {
            InitializeComponent();
            LastNameTextBox.Text = textbox1;    
            NameTextBox.Text = textbox2;
            dateTimePicker1.Value = datetimepicker1;
        }
        private void ButtonRegistration(object sender, EventArgs e)
        {
            if (AllFieldsValid())
            {
                Dictionary<string, string> newUsers = DataRepository.ReadFileUser();
                newUsers[LoginTextBox.Text] = PasswordTextBox.Text;
                DataRepository.WriteFileUser(newUsers);
                Dictionary<string, User> newUserProf = DataRepository.ReadFileProf();
                newUserProf[LoginTextBox.Text] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text);
                DataRepository.WriteFileProf(newUserProf);
                MessageBox.Show(@"Вы успешно зарегистрированы!");
            }
            else MessageBox.Show(@"Заполнение всех полей обязательно!");
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            General.GetGeneral().Show();
            this.Close();
        }
        private bool AllFieldsValid()
        {
            return (LastNameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "" && LoginTextBox.Text != "" &&
                PasswordTextBox.Text != "");
        }
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.DarkGreen;
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
        }
        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.White;
            ((Label)sender).Font = DefaultFont;
        }
        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Blue;
            Font underlineFont = new Font(DefaultFont.Name, DefaultFont.Size, FontStyle.Underline, DefaultFont.Unit, DefaultFont.GdiCharSet, 
                DefaultFont.GdiVerticalFont);
            ((Label)sender).Font = underlineFont;
        }
    }
}