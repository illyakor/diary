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
        Dictionary<string, Week> scheduleUser = DataRepository.ReadFileSchedule();
        List<Day> week = new List<Day>();

        // глобальные перменные
        int k = 0, count = 0, q = 0;
        // создание массива расписания факультативов
        string[,,] schedule2 = new string[8, 2, 10];
        // список предметов
        string[] classes = { " ", "бел. язык", "бел. лит.", "русск. язык", "русск. лит.", "англ. язык", "немецк. язык", "математика", "информат.", "чел. и мир", "ист. Беларуси", "мировая ист.", "общствед.", "география", "биология", "физика", "астрономия", "химия", "труд. обуч.", "черчение", "физ. к. и зд.", "ДПЮ", "мед. подгот.", "ОБЖ", "Мастацтва"};
        // список дней недели
        string[] weeks = { " ", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота" };
        // массив расписания звонков
        string[] call = { "Звонки", "09:00 - 09:45", "09:55 - 10:40", "10:55 - 11:40", "11:55 - 12:40", "12:55 - 13:40", "13:50 - 14:35", " ", " " };
        // нумерация для лучшей навигации по таблицам dataDridView1 и dataDridView3
        string number = "№12345678", loginUser = "Qwe";
        public Schedule()
        {
            InitializeComponent();
            //loginUser = login;
            //week = scheduleUser[loginUser].week;
            FillGridSchedule();
            FillAddGrid();
            //FillGrid2();
        }
        public void FillGridSchedule()
        {
            // количество строк в dataGridView1
            this.gridSchedule.RowCount = 9;
            // цикл заполнения таблицы dataGridView1 соответствующим расписанием предметов
            for (k = 0; k < 8; k++)
                for (q = 0; q < 6; q++)
                {
                    // изменение свойства ячейки из textBox в comboBox
                    DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
                    // внесение списка предметов в выбор для редактирования
                    r.Items.AddRange(classes);
                    // внесение предмета соответствующего профиля из массива расписания занятий
                    //r.Value = schedule1[k, q, count];
                    if (scheduleUser.Count > 0)
                        r.Value = scheduleUser[loginUser].week[k].day[q];
                    else
                        r.Value = " ";
                    // вывод списка предметов и предмета соответствующего с расписанием занятий
                    gridSchedule.Rows[k].Cells[q] = r;
                    // ширина всех столбцов в dataGridView1
                    if (k == 7) gridSchedule.Columns[q].Width = 103;
                }
            // отмена добавления последней строчки в таблице dataGridView1
            gridSchedule.AllowUserToAddRows = false;
        }
        public void FillGrid2()
        {
            // количество строк в dataGridView2
            this.dataGridView2.RowCount = 9;
            // цикл заполнения таблицы dataGridView2 для дней недели
            for (k = 0; k < 8; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
                // внесение списка дней недели в выбор для редактирования
                r.Items.AddRange(weeks);
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
        }
        public void FillAddGrid()
        {
            // цикл создания пустой таблицы dataGridView3 для нумерации предметов и расписания звонков
            for (k = 0; k < 8; k++) addGrid.Rows.Add("", "");
            // цикл заполнения таблицы dataGridView3 расписанием звонков
            for (k = 0; k < 9; k++) addGrid[1, k].Value = call[k];
            // цикл заполнения таблицы dataGridView3 нумерацией предметов
            for (k = 0; k < 9; k++) addGrid[0, k].Value = number[k];
        }
        // кнопка изменения данных
        private void Button1_Click(object sender, EventArgs e)
        {
            scheduleUser[loginUser] = new Week(new List<Day>());
            for (q = 0; q < 6; q++)
                for (k = 0; k < 8; k++)
                    scheduleUser[loginUser].week[q].day[k] = Convert.ToString(gridSchedule[q, k].Value);
            week = scheduleUser[loginUser].week;
            DataRepository.WriteFileSchedule(scheduleUser);
            MessageBox.Show("Сохранение прошло успешно!");
        }
    }
}