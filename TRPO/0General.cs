//rest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Numerics;

namespace TRPO
{
    public partial class General : Form
    {
        string[,] profiles = new string[10, 6];
        int count = 0, i = 0;
        public General()
        {
            InitializeComponent();
            StreamReader openFile = new StreamReader("Profiles.txt");
            //string bufDataRowfile;
            while (/*(bufDataRowfile = */openFile.ReadLine()/*)*/ != null)
            {
                string[] dataRow = Convert.ToString(openFile)/*bufDataRowfile*/.Split(new[] { '|' });
                try
                {
                    int k;
                    for (k = 0; k < 6; k++) profiles[i, k] = dataRow[k];
                    i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            openFile.Close();
        }
        private void ButtonInput_Click(object sender, EventArgs e)
        {
            bool booleForOpenFormMenu = false;
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Ошибка. Введите данные!");
            }
            else
            {
                for (i = 0; i < 10; i++)
                {
                    string character = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ", password = "";
                    string[] bufData = profiles[i, 4].Split(new[] { 'o' });
                    int D = Convert.ToInt32(bufData[bufData.Length - 2]), N = Convert.ToInt32(bufData[bufData.Length - 1]), h, t;
                    BigInteger[] decrypted;
                    decrypted = new BigInteger[bufData.Length - 2];
                    for (int kkk = 0; kkk < bufData.Length - 2; kkk++) decrypted[kkk] = BigInteger.Pow(Convert.ToInt32(bufData[kkk]), D) % N;
                    for (t = 0; t < bufData.Length - 2; t++)
                    {
                        for (h = 0; h < 62; h++)
                        {
                            if (decrypted[t] == h) password = password + character[h];
                            else continue;
                        }
                    }
                    if (textBoxLogin.Text == profiles[i, 3] && textBoxPassword.Text == password)
                    {
                        count = i; booleForOpenFormMenu = true;
                        break;
                    }
                    else continue;
                }

            }
            if (booleForOpenFormMenu == true) this.OpenMenuForm();
            else
            {
                textBoxLogin.Text = ""; textBoxPassword.Text = "";
                MessageBox.Show("Ошибка. Такого пользователя не существует. Проверьте логин и/или пароль!");
            }
            i = 0; count = 0;
        }
        private void OpenMenuForm()
        {
            this.Hide();
            Menu menuForm = new Menu(count, profiles);
            menuForm.Show();
        }
        private void ButtonPassword_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                MessageBox.Show("Ошибка. Введите логин!");
            }
            else
            {
                for (i = 0; i < 10; i++)
                {
                    if (textBoxLogin.Text == profiles[i, 3])
                    {
                        MessageBox.Show("Ваш пароль: " + profiles[i, 4] + "!");
                        break;
                    }
                }
            }
        }
        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxSurname.Text == "")
            {
                MessageBox.Show("Ошибка. Введите данные!");
            }
            else
            {
                string bufTextBoxName = "", bufTextBoxSurname = "";
                DateTimePicker bufDateTimePickerBirthdate = new DateTimePicker();
                bufTextBoxName = textBoxName.Text; bufTextBoxSurname = textBoxSurname.Text; bufDateTimePickerBirthdate.Value = dateTimePickerBirthdate.Value;
                this.Hide();
                Registration registrationForm = new Registration(bufTextBoxName, bufTextBoxSurname, bufDateTimePickerBirthdate);
                registrationForm.Show();
            }
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