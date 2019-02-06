using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TRPO
{
    public partial class Schedule : Form
    {
        public string connect = "server=localhost;user=root;database=diarydb;password=toor;charset=utf8";
        // глобальные перменные
        DataTable scheduleUser;
        int k = 0, count = 0, q = 0;
        public static int lessonCount = 8, dayCount = 6;
        // создание массива расписания факультативов
        string[,,] schedule2 = new string[8, 2, 10];
        // список предметов
        public static string[] teacher = { " ", "бел. язык", "бел. лит.", "русск. язык", "русск. лит.", "англ. язык", "немецк. язык", "математика", "информат.", "чел. и мир", "ист. Беларуси", "мировая ист.", "общствед.", "география", "биология", "физика", "астрономия", "химия", "труд. обуч.", "черчение", "физ. к. и зд.", "ДПЮ", "мед. подгот.", "ОБЖ", "Мастацтва"};
        // список дней недели
        string[] days = { " ", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота" };
        // массив расписания звонков
        string[] numberAndCall = { "1 | 09:00 - 09:45", "2 | 09:55 - 10:40", "3 | 10:55 - 11:40", "4 | 11:55 - 12:40", "5 | 12:55 - 13:40", "6 | 13:50 - 14:35", "7 | ", "8 | " };
        string loginUser = "QWE", buff;
        public Schedule()
        {
            InitializeComponent();
            //loginUser = login;
            FillGridSchedule();
            //FillGrid2();
        }
        public void FillGridSchedule()
        {
            // заполнение заголовок строк
            for (q = 0; q < lessonCount; q++) gridSchedule.Rows[q].HeaderCell.Value = numberAndCall[q];
            // внесение списка предметов в выбор для редактирования
            this.dataGridViewTextBoxColumn11.Items.AddRange(teacher);
            this.dataGridViewTextBoxColumn12.Items.AddRange(teacher);
            this.dataGridViewTextBoxColumn13.Items.AddRange(teacher);
            this.dataGridViewTextBoxColumn14.Items.AddRange(teacher);
            this.dataGridViewTextBoxColumn15.Items.AddRange(teacher);
            this.dataGridViewTextBoxColumn16.Items.AddRange(teacher);
            //
            string cmdMysql = "SHOW TABLES;";
            MySqlConnection mySqlConn = new MySqlConnection(connect);
            using (MySqlCommand cmd = new MySqlCommand(cmdMysql, mySqlConn))
            {
                buff = cmd.ExecuteScalar().ToString();
                /*
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                     
                }
                else
                {
                    
                }
                */
                //inv.Load(dr);
                //dr.Close();
            }

            gridSchedule.DataSource = scheduleUser;

            // цикл заполнения таблицы dataGridView1 соответствующим расписанием предметов
            for (k = 0; k < dayCount; k++)
            {
                for (q = 0; q < lessonCount; q++)
                {
                    // вывод предмета соответствующего с расписанием занятий
                    gridSchedule.Rows[q].Cells[k].Value = " ";
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            /*
            Week s1 = new Week(new List<Day>());
            for (q = 0; q < dayCount; q++)
            {
                Day s2 = new Day(new List<string>());
                for (k = 0; k < lessonCount; k++)
                {
                    s2.day.Add(Convert.ToString(gridSchedule[q, k].Value));
                    //scheduleUser[loginUser].week[q].day[k] = Convert.ToString(gridSchedule[q, k].Value);
                }
                s1.week.Add(s2);
            }
            
            for (q = dayCount - 1; q > -1; q--)
            {
                for (k = lessonCount - 1; k > -1; k--)
                {
                    s2.day.Add(Convert.ToString(gridSchedule[q, k].Value));
                }
                s1.week.Add(s2);
            }
            */
            
            DataTable dataTableScheduleUser = new DataTable(loginUser);
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn11");
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn12");
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn13");
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn14");
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn15");
            dataTableScheduleUser.Columns.Add("dataGridViewTextBoxColumn16");

            //scheduleUser[loginUser] = dataTableScheduleUser;

            MessageBox.Show("Сохранение прошло успешно!");
        }
        public void FillGrid2()
        {
            // количество строк в dataGridView2
            this.dataGridView2.RowCount = lessonCount + 1;
            // цикл заполнения таблицы dataGridView2 для дней недели
            for (k = 0; k < lessonCount; k++)
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
            for (k = 0; k < lessonCount; k++)
            {
                // изменение свойства ячейки из textBox в comboBox
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                // внесение списка предметов в выбор для редактирования
                cell.Items.AddRange(teacher);
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
    }
}