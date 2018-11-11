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
    public partial class ShoolProfInf : Form
    {
        TextBox textBox1;
        DateTimePicker dateTimePicker1;
        string[,] profiles = new string[10, 6];
        string[] headerRow = { "Фамилия", "Имя", "Отчество", "Логин", "Пароль", "Дата рождения" };
        int k = 0, count = 0, q = 0;
        string buf = "";
        public ShoolProfInf(int counter, string[,] bufDataArray)
        {
            InitializeComponent();
            textBox1 = new TextBox();
            count = counter;
            profiles = bufDataArray;
            this.dataGridView1.RowCount = 6;
            for (k = 0; k < 6; k++) dataGridView1.Rows[k].HeaderCell.Value = headerRow[k];
            for (k = 0; k < 5; k++) dataGridView1.Rows[k].Cells[0].Value = profiles[count, k];
            for (q = 0; q < profiles[count, 4].Length; q++) buf = buf + "*";
            dataGridView1.Rows[4].Cells[0].Value = buf;
            textBox1.PasswordChar = '*';
            string character = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ", password = "";
            string[] bufData = profiles[count, 4].Split(new[] { 'o' });
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
            textBox1.Text = password;
            dataGridView1.Controls.Add(textBox1);
            Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(0, 4, true);
            textBox1.Size = new Size(233, 22);
            textBox1.Location = new Point(172, 113);
            textBox1.Click += (sender, e) => { dataGridView1.CurrentCell = dataGridView1[0, 4]; };
            dataGridView1.Rows[5].Cells[0].Value = profiles[count, 5];
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            bool boole = true;
            for (k = 0; k < 4; k++) if (Convert.ToString(dataGridView1.Rows[k].Cells[0].Value) == "") boole = false;
            if (boole == false)
                MessageBox.Show("Введите данные");
            else
            {
                for (k = 0; k < 4; k++) profiles[count, k] = Convert.ToString(dataGridView1.Rows[k].Cells[0].Value);
                string password = textBox1.Text, encryptedb = "", character = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
                profiles[count, 4] = textBox1.Text;
                buf = Convert.ToString(dataGridView1.Rows[5].Cells[0].Value);
                profiles[count, 5] = "";
                for (q = 0; q < 10; q++) profiles[count, 5] = profiles[count, 5] + buf[q];
                StreamWriter fileForWriter = new StreamWriter("Profiles.txt");
                int i = 0;
                for (i = 0; i < 10; i++)
                {
                    string dataRow = "";
                    for (k = 0; k < 6; k++) dataRow = dataRow + profiles[i, k] + '|';
                    fileForWriter.WriteLine(dataRow);
                }
                fileForWriter.Close();
                MessageBox.Show("Сохранение прошло успешно!");
            }
            buf = "";
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 5)
            {
                if (e.ColumnIndex == 0)
                {
                    dateTimePicker1 = new DateTimePicker();
                    dataGridView1.Controls.Add(dateTimePicker1);
                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dateTimePicker1.Size = new Size(233, 21);
                    dateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);
                    dateTimePicker1.TextChanged += new EventHandler(DateTimePickerChange);
                    dateTimePicker1.CloseUp += new EventHandler(DateTimePickerClose);
                }
            }
        }
        private void DateTimePickerChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dateTimePicker1.Text.ToString();
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }
    }
}