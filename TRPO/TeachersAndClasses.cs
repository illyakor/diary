using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TRPO
{
    public partial class TeachersAndClasses : Form
    {
        int counter;
        string[,] bufData;
        string[,] teacherAndClasses = new string[10, 24];
        int k = 0, count = 0;
        string[] classes = { "бел. язык", "бел. лит.", "русск. язык", "русск. лит.", "англ. язык", "немецк. язык", "математика", "информат.", "чел. и мир", "ист. Беларуси", "мировая ист.", "общствед.", "география", "биология", "физика", "астрономия", "химия", "труд. обуч.", "черчение", "физ. к. и зд.", "ДПЮ", "мед. подгот.", "ОБЖ", "Мастацтва"};
        public TeachersAndClasses()
        {
            InitializeComponent();
            count = counter;
            teacherAndClasses = bufData;
            this.dataGridView1.RowCount = 24;
            for (k = 0; k < 24; k++) dataGridView1.Rows[k].HeaderCell.Value = classes[k];
            for (k = 0; k < 24; k++) dataGridView1.Rows[k].Cells[0].Value = teacherAndClasses[count, k];
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int i = 0, q, d = 0;
            for (q = 0; q < 24; q++) if ((String)dataGridView1.Rows[q].Cells[0].Value == "") d = 1;
            if (d == 0)
            {
                for (k = 0; k < 24; k++) teacherAndClasses[count, k] = Convert.ToString(dataGridView1.Rows[k].Cells[0].Value);
                StreamWriter file = new StreamWriter("TeacherAndClasses.txt");
                for (i = 0; i < 10; i++)
                {
                    string dataRow = "";
                    for (k = 0; k < 24; k++) dataRow = dataRow + teacherAndClasses[i, k] + '|';
                    file.WriteLine(dataRow);
                }
                file.Close();
                MessageBox.Show("Сохранение прошло успешно!");
            }
            else MessageBox.Show("Введите данные!");
        }
    }
}