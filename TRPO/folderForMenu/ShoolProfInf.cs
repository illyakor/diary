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
        public ShoolProfInf()
        {
            InitializeComponent();
            FillBoxes();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, User> newUserProf = new Dictionary<string, User>
            {
                [General.loginUser] = new User(LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text, LoginTextBox.Text, PasswordTextBox.Text)
            };          
            DataRepository.WriteProf(newUserProf, sender);
            MessageBox.Show("Сохранение прошло успешно!");
        }
        public void FillBoxes()
        {
            Dictionary<string, User> userProf = DataRepository.ReadProf();
            LastNameTextBox.Text = userProf[General.loginUser].LastName;
            NameTextBox.Text = userProf[General.loginUser].Name;
            PatronymicTextBox.Text = userProf[General.loginUser].Patronymic;
            LoginTextBox.Text = userProf[General.loginUser].Login;
            PasswordTextBox.Text = userProf[General.loginUser].Password;
            dateTimePicker1.Text = userProf[General.loginUser].BirthDate;
        }
    }
}