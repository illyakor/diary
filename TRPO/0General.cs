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
    public partial class General : Form
    {
        private static General general;
        public static string newLoginUser, loginUser;
        private General()
        {
            InitializeComponent();
        }
        public static General GetGeneral()
        {
            if (general == null)
                general = new General();
            return general;
        }
        private void ButtonInput_Click(object sender, EventArgs e)
        {
            CheckUser();
        }
        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            OpenRegistrationForm();
        }
        private void ButtonPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта функция не реализована");
        }
        private void CheckUser()
        {
            Dictionary<string, string> users = DataRepository.ReadFileUser();
            if (users != null && users.ContainsKey(textBoxLogin.Text) && users[textBoxLogin.Text] == textBoxPassword.Text)
            {
                OpenMenuForm();
            }
            else
            {
                MessageBox.Show("Неверно введён логин и/или пароль!");
            }
        }
        private void OpenMenuForm()
        {
            loginUser = textBoxLogin.Text;
            newLoginUser = textBoxLogin.Text;
            this.Hide();
            Menu menuForm = new Menu();
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            menuForm.Show();
        }
        private void OpenRegistrationForm()
        {
            this.Hide();
            Registration regForm = new Registration(textBoxName.Text, textBoxSurname.Text, dateTimePickerBirthdate.Value);
            regForm.Show();
        }
        private void General_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void ButtonInput_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.DarkGreen;
        }

        private void ButtonInput_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
        }
    }
}
//System.Environment.FailFast("Палундра!");
//Process.GetCurrentProcess().Kill();
//Application.Exit();