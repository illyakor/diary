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
    public partial class Events : Form
    {
        int counter;
        string[,,] bufData;
        int k = 0, count = 0;
        string[,,] events = new string[24, 4, 10];
        DateTimePicker dateTimePicker1;
        public Events()
        {
            InitializeComponent();
            count = counter;
            events = bufData;
            this.BindDataGridView();
        }
        private void BindDataGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[4] { new DataColumn("Мероприятие", typeof(string)), new DataColumn("Место", typeof(string)), new DataColumn("Дата", typeof(DateTime)), new DataColumn("Время", typeof(string)) });
            for (k = 0; k < 24; k++) dataTable.Rows.Add(events[k, 0, count], events[k, 1, count], DateTime.Parse(events[k, 2, count]), events[k, 3, count]);
            this.dataGridView1.DataSource = dataTable;
            foreach (DataGridViewColumn sort in dataGridView1.Columns) sort.SortMode = DataGridViewColumnSortMode.NotSortable;
            k = 0;
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 2)
                {
                    dateTimePicker1 = new DateTimePicker();
                    dataGridView1.Controls.Add(dateTimePicker1);
                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(2, e.RowIndex, true);
                    dateTimePicker1.Size = new Size(226, 21);
                    dateTimePicker1.Location = new Point(455, oRectangle.Y);
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
        private void Button1_Click(object sender, EventArgs e)
        {
            int q, d = 0;
            for (q = 0; q < 24; q++)
                for (k = 0; k < 4; k++)
                {
                    if (k == 2) continue;
                    else if ((String)dataGridView1.Rows[q].Cells[k].Value == "") d = 1;
                }
            if (d == 0)
            {
                for (k = 0; k < 24; k++)
                {
                    for (q = 0; q < 4; q++)
                    {
                        if (q == 2) events[k, q, count] = Convert.ToString(dataGridView1.Rows[k].Cells[2].Value);
                        else events[k, q, count] = Convert.ToString(dataGridView1.Rows[k].Cells[q].Value);
                    }
                }
                int i;
                StreamWriter fileForWriter = new StreamWriter("Events.txt");
                for (i = 0; i < 10; i++)
                {
                    string dataRow = "";
                    for (k = 0; k < 24; k++) for (q = 0; q < 4; q++) dataRow = dataRow + events[k, q, i] + '|';
                    fileForWriter.WriteLine(dataRow);
                }
                fileForWriter.Close();
                MessageBox.Show("Сохранение прошло успешно!");
            }
            else MessageBox.Show("Введите данные!");
        }
    }
}