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
        Dictionary<string, string> User = DataRepository.ReadFileUser();
        Dictionary<string, User> UserProf = DataRepository.ReadFileProf();
        string LoginUser;
        public ShoolProfInf(string login)
        {
            InitializeComponent();
            LoginUser = login;
            FillBox();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (LoginUser != LoginTextBox.Text)
            {
                UserProf.Remove(LoginUser);
                User.Remove(LoginUser);

                User[LoginTextBox.Text] = PasswordTextBox.Text;
                UserProf[LoginTextBox.Text] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text);
            }
            else
            {
                User[LoginUser] = PasswordTextBox.Text;
                UserProf[LoginUser] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text);
            }

            DataRepository.WriteFileProf(UserProf);
            DataRepository.WriteFileUser(User);
        }
        public void FillBox()
        {
            LastNameTextBox.Text = UserProf[LoginUser].LastName;
            NameTextBox.Text = UserProf[LoginUser].Name;
            PatronymicTextBox.Text = UserProf[LoginUser].Patronymic;
            LoginTextBox.Text = LoginUser;
            PasswordTextBox.Text = User[LoginUser];
            dateTimePicker1.Text = UserProf[LoginUser].BirthDate;
        }
    }
}