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
    public partial class ShoolProfInf : Form
    {
        Dictionary<string, string> user = DataRepository.ReadFileUser();
        Dictionary<string, User> userProf = DataRepository.ReadFileProf();
        string loginUser;
        public ShoolProfInf(string login)
        {
            InitializeComponent();
            loginUser = login;
            FillBoxes();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (loginUser != LoginTextBox.Text)
            {
                userProf.Remove(loginUser);
                user.Remove(loginUser);
                loginUser = LoginTextBox.Text;
            }
            user[loginUser] = PasswordTextBox.Text;
            userProf[loginUser] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text);
            DataRepository.WriteFileProf(userProf);
            DataRepository.WriteFileUser(user);
            MessageBox.Show("Сохранение прошло успешно!");
        }
        public void FillBoxes()
        {
            LastNameTextBox.Text = userProf[loginUser].LastName;
            NameTextBox.Text = userProf[loginUser].Name;
            PatronymicTextBox.Text = userProf[loginUser].Patronymic;
            LoginTextBox.Text = loginUser;
            PasswordTextBox.Text = user[loginUser];
            dateTimePicker1.Text = userProf[loginUser].BirthDate;
        }
    }
}