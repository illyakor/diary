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
        Dictionary<string, string> user;
        Dictionary<string, User> userProf = DataRepository.ReadFileProf();
        public ShoolProfInf()
        {
            InitializeComponent();
            user = DataRepository.ReadFileUser();
            FillBoxes();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (General.loginUser != LoginTextBox.Text)
            {
                userProf.Remove(General.loginUser);
                user.Remove(General.loginUser);
                General.newLoginUser = LoginTextBox.Text;
            }
            user[General.newLoginUser] = PasswordTextBox.Text;
            userProf[General.newLoginUser] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text);
            DataRepository.WriteFileProf(userProf);
            DataRepository.WriteFileUser(user);
            MessageBox.Show("Сохранение прошло успешно!");
        }
        public void FillBoxes()
        {
            LastNameTextBox.Text = userProf[General.newLoginUser].LastName;
            NameTextBox.Text = userProf[General.newLoginUser].Name;
            PatronymicTextBox.Text = userProf[General.newLoginUser].Patronymic;
            LoginTextBox.Text = General.newLoginUser;
            PasswordTextBox.Text = user[General.newLoginUser];
            dateTimePicker1.Text = userProf[General.newLoginUser].BirthDate;
        }
    }
}