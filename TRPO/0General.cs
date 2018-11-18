// rest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TRPO
{
    public partial class General : Form
    { 
        Dictionary<string, string> users;
        public General()
        {
            InitializeComponent();
        }
        private void ButtonInput_Click(object sender, EventArgs e)
        {
            ReadFile();
            ChekUser();
        }
        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            OpenRegistrationForm();
        }
        private void ButtonPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта функция не реализована");
        }
        private void ReadFile()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                //users = (Dictionary<string, string>)jsonFormatter.ReadObject(fs);
                try
                {
                    users = (Dictionary<string, string>)jsonFormatter.ReadObject(fs);
                }
                catch
                {
                    //users = null;
                }
            }
        }
        private void ChekUser()
        {
            if (users != null && users.ContainsKey(textBoxLogin.Text))
            {
                string password;
                if ((password = users[textBoxLogin.Text]) == textBoxPassword.Text)
                {
                    OpenMenuForm();
                }
                else
                {
                    MessageBox.Show("Неверный введён пароль!");
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }
        private void OpenMenuForm()
        {
            this.Hide();
            Menu menuForm = new Menu(textBoxLogin.Text);
            menuForm.Show();
        }
        private void OpenRegistrationForm()
        {
            DateTimePicker bufDateTimePickerBirthdate = new DateTimePicker();
            bufDateTimePickerBirthdate.Value = dateTimePickerBirthdate.Value;
            this.Hide();
            Registration regForm = new Registration(textBoxName.Text, textBoxSurname.Text, bufDateTimePickerBirthdate);
            regForm.Show();
        }
        private void General_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void TextBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '`')
                e.Handled = true;
        }
        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58))
                e.Handled = true;
        }
        private void TextBoxNameAndSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '`' && e.KeyChar != '-')
                e.Handled = true;
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
/*
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, persons);
            }
*/
