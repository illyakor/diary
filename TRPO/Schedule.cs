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
        // глобальные перменные
        int k = 0, count = 0, q = 0;
        // создание массива расписания факультативов
        string[,,] schedule2 = new string[8, 2, 10];
        // список предметов
        string[] classes = { " ", "бел. язык", "бел. лит.", "русск. язык", "русск. лит.", "англ. язык", "немецк. язык", "математика", "информат.", "чел. и мир", "ист. Беларуси", "мировая ист.", "общствед.", "география", "биология", "физика", "астрономия", "химия", "труд. обуч.", "черчение", "физ. к. и зд.", "ДПЮ", "мед. подгот.", "ОБЖ", "Мастацтва"};
        // список дней недели
        string[] days = { " ", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота" };
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
            this.gridSchedule.RowCount = Day.lessonCount + 1;
            // цикл заполнения таблицы dataGridView1 соответствующим расписанием предметов
            for (k = 0; k < Week.dayCount; k++)
            {
                for (q = 0; q < Day.lessonCount; q++)
                {
                    // изменение свойства ячейки из textBox в comboBox
                    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                    // внесение списка предметов в выбор для редактирования
                    cell.Items.AddRange(classes);
                    // внесение предмета соответствующего профиля из массива расписания занятий
                    if (scheduleUser.Count > 0)
                    {
                        cell.Value = scheduleUser[loginUser].week[k].day[q];
                    }
                    else
                    {
                        cell.Value = " ";
                    }
                    // вывод списка предметов и предмета соответствующего с расписанием занятий
                    gridSchedule.Rows[q].Cells[k] = cell;
                }
                // ширина всех столбцов в dataGridView1
                gridSchedule.Columns[k].Width = 103;
            }
            // отмена добавления последней строчки в таблице dataGridView1
            gridSchedule.AllowUserToAddRows = false;
        }
        public void FillGrid2()
        {
            // количество строк в dataGridView2
            this.dataGridView2.RowCount = Day.lessonCount + 1;
            // цикл заполнения таблицы dataGridView2 для дней недели
            for (k = 0; k < Day.lessonCount; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                // внесение списка дней недели в выбор для редактирования
                cell.Items.AddRange(days);
                // внесение дня недели соответствующего профиля из массива расписания факультативов
                cell.Value = schedule2[k, 0, count];
                // вывод списка дней недели и дня недели соответствующего с расписанием факультативов 
                dataGridView2.Rows[k].Cells[0] = cell;
            }
            // цикл заполнения таблицы dataGridView2 для предметов
            for (k = 0; k < Day.lessonCount; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                // внесение списка предметов в выбор для редактирования
                cell.Items.AddRange(classes);
                // внесение предмета соответствующего профиля из массива расписания факультативов
                cell.Value = schedule2[k, 1, count];
                // вывод списка предметов и предмета соответствующего с расписанием факультативов
                dataGridView2.Rows[k].Cells[1] = cell;
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
            for (k = 0; k < Day.lessonCount; k++) addGrid.Rows.Add("", "");
            for (k = 0; k < Day.lessonCount + 1; k++)
            {
                // заполнение таблицы нумерацией предметов
                addGrid[0, k].Value = number[k];
                // заполнение таблицы расписанием звонков
                addGrid[1, k].Value = call[k];
            } 
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            for (q = 0; q < Week.dayCount; q++)
            {
                for (k = 0; k < Day.lessonCount; k++)
                {
                    scheduleUser[loginUser].week[q].day[k] = Convert.ToString(gridSchedule[q, k].Value);
                }
            }
            DataRepository.WriteFileSchedule(scheduleUser);
            MessageBox.Show("Сохранение прошло успешно!");
        }
    }
}