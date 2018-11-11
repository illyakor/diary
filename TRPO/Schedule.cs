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
    public partial class Schedule : Form
    {
        // глобальные перменные
        int k = 0, count = 0, q = 0;
        // создание массива расписания занятий
        string[,,] schedule1 = new string[8, 6, 10];
        // создание массива расписания факультативов
        string[,,] schedule2 = new string[8, 2, 10];
        // список предметов
        string[] classes = { " ", "бел. язык", "бел. лит.", "русск. язык", "русск. лит.", "англ. язык", "немецк. язык", "математика", "информат.", "чел. и мир", "ист. Беларуси", "мировая ист.", "общствед.", "география", "биология", "физика", "астрономия", "химия", "труд. обуч.", "черчение", "физ. к. и зд.", "ДПЮ", "мед. подгот.", "ОБЖ", "Мастацтва"};
        // список дней недели
        string[] week = { " ", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота" };
        // массив расписания звонков
        string[] call = { "Звонки", "09:00 - 09:45", "09:55 - 10:40", "10:55 - 11:40", "11:55 - 12:40", "12:55 - 13:40", "13:50 - 14:35", " ", " " };
        // нумерация для лучшей навигации по таблицам dataDridView1 и dataDridView3
        string number = "№12345678";
        public Schedule(int counter, string[,,] bufData1, string[,,] bufData2)
        {
            InitializeComponent();
            count = counter;
            schedule1 = bufData1;
            schedule2 = bufData2;
            // количество строк в dataGridView1
            this.dataGridView1.RowCount = 9;
            // цикл заполнения таблицы dataGridView1 соответствующим расписанием предметов
            for (k = 0; k < 8; k++)
                for (q = 0; q < 6; q++)
                {
                    // изменение свойства ячейки из textBox в comboBox
                    DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
                    // внесение списка предметов в выбор для редактирования
                    r.Items.AddRange(classes);
                    // внесение предмета соответствующего профиля из массива расписания занятий
                    r.Value = schedule1[k, q, count];
                    // вывод списка предметов и предмета соответствующего с расписанием занятий
                    dataGridView1.Rows[k].Cells[q] = r;
                    // ширина всех столбцов в dataGridView1
                    if (k == 7) dataGridView1.Columns[q].Width = 103;
                }
            // отмена добавления последней строчки в таблице dataGridView1
            dataGridView1.AllowUserToAddRows = false;
            // количество строк в dataGridView2
            this.dataGridView2.RowCount = 9;
            // цикл заполнения таблицы dataGridView2 для дней недели
            for (k = 0; k < 8; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
                // внесение списка дней недели в выбор для редактирования
                r.Items.AddRange(week);
                // внесение дня недели соответствующего профиля из массива расписания факультативов
                r.Value = schedule2[k, 0, count];
                // вывод списка дней недели и дня недели соответствующего с расписанием факультативов 
                dataGridView2.Rows[k].Cells[0] = r;
            }
            // цикл заполнения таблицы dataGridView2 для предметов
            for (k = 0; k < 8; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
                // внесение списка предметов в выбор для редактирования
                r.Items.AddRange(classes);
                // внесение предмета соответствующего профиля из массива расписания факультативов
                r.Value = schedule2[k, 1, count];
                // вывод списка предметов и предмета соответствующего с расписанием факультативов
                dataGridView2.Rows[k].Cells[1] = r;
            }
            // ширина нулевого столбца в dataGridView2
            dataGridView2.Columns[0].Width = 103;
            // ширина первого столбца в dataGridView2
            dataGridView2.Columns[1].Width = 103;
            // отмена добавления последней строчки в таблице dataGridView2
            dataGridView2.AllowUserToAddRows = false;
            // цикл создания пустой таблицы dataGridView3 для нумерации предметов и расписания звонков
            for (k = 0; k < 8; k++) dataGridView3.Rows.Add("", "");
            // цикл заполнения таблицы dataGridView3 расписанием звонков
            for (k = 0; k < 9; k++) dataGridView3[1, k].Value = call[k];
            // цикл заполнения таблицы dataGridView3 нумерацией предметов
            for (k = 0; k < 9; k++) dataGridView3[0, k].Value = number[k];
        }
        // кнопка изменения данных
        private void Button1_Click(object sender, EventArgs e)
        {
            // цикл изменения массива расписания занятий
            for (k = 0; k < 8; k++) for (q = 0; q < 6; q++) schedule1[k, q, count] = Convert.ToString(dataGridView1[q, k].Value);
            // цикл изменения массива расписания факультативов
            for (k = 0; k < 8; k++)
            {
                // изменение дней недели в нулевом столбце массива 
                schedule2[k, 0, count] = Convert.ToString(dataGridView2[0, k].Value);
                // изменение занятий в первом столбце массива
                schedule2[k, 1, count] = Convert.ToString(dataGridView2[1, k].Value);
            }
            // открытие файла для внесения изменений
            StreamWriter file = new StreamWriter("Schedule.txt");
            // цикл перезаписи файла с учётом внесённых изменений из таблиц dataGridView1 и dataGridView2
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                string text0 = "";
                // цикл внесения изменений расписания занятий из dataGridView1 в массив расписания занятий
                for (k = 0; k < 6; k++) for (q = 0; q < 8; q++) text0 = text0 + schedule1[q, k, i] + '|';
                // цикл внесения изменений расписания факультативов из dataGridView2 в массив расписания факультативов
                for (k = 0; k < 2; k++) for (q = 0; q < 8; q++) text0 = text0 + schedule2[q, k, i] + '|';
                // внесение новой строки в файл в качестве переменной text
                file.WriteLine(text0);
            }
            // закрытие файла
            file.Close();
            // сообщение об успешном сохранении изменений
            MessageBox.Show("Сохранение прошло успешно!");
        }
    }
}