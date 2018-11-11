using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Numerics;

namespace TRPO
{
    public partial class Registration : Form
    {
        string[,] schedule = new string[10, 64];
        string[,] teachersAndClasses = new string[10, 24];
        string[,] events = new string[10, 96];
        string[,] profiles = new string[10, 6];
        string[,] additionalInf = new string[10, 29];
        string[] addArrayForAddInf = { " ", " ", " ", "0", "0", " ", "0", " ", "0", " ", "0", " ", "0", " ", " ", " ", " ", " ", " ", "0", " ", " ", " ",
            " ", "0", "0", "0", "0", "0", "1"};
        int count = 0, k = 0, i = 0;
        string bufData = "";
        public Registration(string textbox1, string textbox2, DateTimePicker datetimepicker1)
        {
            InitializeComponent();
            nameTextBox.Text = textbox1;
            surnameTextBox.Text = textbox2;
            dateTimePicker1.Value = datetimepicker1.Value;
            StreamReader fileForReader = new StreamReader("Profiles.txt");
            while ((bufData = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufData.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 6; k++) profiles[i, k] = dataRow[k]; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
            i = 0;
            fileForReader = new StreamReader("Schedule.txt");
            while ((bufData = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufData.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 64; k++) schedule[i, k] = dataRow[k]; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
            i = 0;
            fileForReader = new StreamReader("AddInformation.txt");
            while ((bufData = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufData.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 29; k++) additionalInf[i, k] = dataRow[k]; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
            i = 0;
            fileForReader = new StreamReader("TeacherAndClasses.txt");
            while ((bufData = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufData.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 24; k++) teachersAndClasses[i, k] = dataRow[k]; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
            i = 0;
            fileForReader = new StreamReader("Events.txt");
            while ((bufData = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufData.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 96; k++) events[i, k] = dataRow[k]; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            General form1 = new General();
            form1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(nameTextBox.Text) != "" && Convert.ToString(surnameTextBox.Text) != "" && Convert.ToString(middleTextBox.Text)
                != "" && Convert.ToString(loginTextBox.Text) != "" && Convert.ToString(passwordTextBox.Text) != "")
            {
                bool bol = true;
                for (i = 0; i < 10; i++)
                {
                    if (loginTextBox.Text == profiles[i, 3]) { bol = false; break; }
                    else continue;
                }
                if (bol == true)
                {
                    i = 0;
                    StreamReader fileForReader = new StreamReader("Profiles.txt");
                    while ((bufData = fileForReader.ReadLine()) != null)
                    {
                        if (i == 9) break;
                        else
                        {
                            if (bufData == "||||||") { count = i; break; }
                            else { i++; continue; }
                        }
                    }
                    fileForReader.Close();
                    for (k = 0; k < 96; k++)
                    {
                        if (((k + 2) % 4) == 0) events[count, k] = "12.12.12";
                        else events[count, k] = " ";
                    }
                    profiles[count, 5] = "";
                    int q;
                    for (q = 0; q < 10; q++) profiles[count, 5] = profiles[count, 5] + Convert.ToString(dateTimePicker1.Value)[q];
                    profiles[count, 0] = nameTextBox.Text;
                    profiles[count, 1] = surnameTextBox.Text;
                    profiles[count, 2] = middleTextBox.Text;
                    profiles[count, 3] = loginTextBox.Text;
                    {
                        string password = passwordTextBox.Text, encryptedb = "", character = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        int P = 97, Q = 521, E = 1259, t, h, u, N, M, D;
                        N = P * Q; M = (P - 1) * (Q - 1); D = E * 2 + 1;
                        while (true)
                        {
                            if ((E * D) % M == 1) break;
                            else D++;
                        }
                        BigInteger[] bufDataEncrypted;
                        bufDataEncrypted = new BigInteger[password.Length];
                        for (t = 0; t < password.Length; t++)
                        {
                            for (h = 0; h < 62; h++)
                            {
                                if (password[t] == character[h]) bufDataEncrypted[t] = BigInteger.Pow(h, E) % N;
                                else continue;
                            }
                        }
                        for (u = 0; u < bufDataEncrypted.Length; u++) encryptedb = encryptedb + bufDataEncrypted[u] + "o";
                        encryptedb = encryptedb + D + "o" + N;
                        profiles[count, 4] = encryptedb;
                    }
                    for (i = 0; i < 24; i++) teachersAndClasses[count, i] = " ";
                    for (i = 0; i < 64; i++) schedule[count, i] = " ";
                    for (i = 0; i < 29; i++) additionalInf[count, i] = addArrayForAddInf[i];
                    string dataRow;
                    StreamWriter fileForWriter = new StreamWriter("Profiles.txt");
                    for (i = 0; i < 10; i++)
                    {
                        dataRow = "";
                        for (k = 0; k < 6; k++) dataRow = dataRow + profiles[i, k] + '|';
                        fileForWriter.WriteLine(dataRow);
                    }
                    fileForWriter.Close();
                    fileForWriter = new StreamWriter("TeacherAndClasses.txt");
                    for (i = 0; i < 10; i++)
                    {
                        dataRow = "";
                        for (k = 0; k < 24; k++) dataRow = dataRow + teachersAndClasses[i, k] + '|';
                        fileForWriter.WriteLine(dataRow);
                    }
                    fileForWriter.Close();
                    fileForWriter = new StreamWriter("Schedule.txt");
                    for (i = 0; i < 10; i++)
                    {
                        dataRow = "";
                        for (k = 0; k < 64; k++) dataRow = dataRow + schedule[i, k] + '|';
                        fileForWriter.WriteLine(dataRow);
                    }
                    fileForWriter.Close();
                    fileForWriter = new StreamWriter("Events.txt");
                    for (i = 0; i < 10; i++)
                    {
                        dataRow = "";
                        for (k = 0; k < 96; k++) dataRow = dataRow + events[i, k] + '|';
                        fileForWriter.WriteLine(dataRow);
                    }
                    fileForWriter.Close();
                    fileForWriter = new StreamWriter("AddInformation.txt");
                    for (i = 0; i < 10; i++)
                    {
                        dataRow = "";
                        for (k = 0; k < 29; k++) dataRow = dataRow + additionalInf[i, k] + '|';
                        fileForWriter.WriteLine(dataRow);
                    }
                    fileForWriter.Close();
                    nameTextBox.Text = "";
                    surnameTextBox.Text = "";
                    middleTextBox.Text = "";
                    loginTextBox.Text = "";
                    passwordTextBox.Text = "";
                    MessageBox.Show(@"Вы успешно зарегестрированы!");
                    i = 0; k = 0; count = 0; dataRow = "";
                }
                else MessageBox.Show(@"Ошибка. Вы кто такие? Я вас не звал! Идите на хуй!");
            }
            else MessageBox.Show(@"Ошибка. Заполните все поля данными!");
        }
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
            (sender as Control).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        }
    }
}