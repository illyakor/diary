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
    public partial class Menu : Form
    {
        string[,,] schedule1 = new string[8, 6, 10];
        string[,,] schedule2 = new string[8, 2, 10];
        string[,] teachersAndClasses = new string[10, 24];
        string[,,] events = new string[24, 4, 10];
        string[,] profiles = new string[10, 6];
        string[,] additionalInf = new string[10, 29];
        int count = 0, k = 0, i = 0, j = 0;
        public Menu(string Login)
        {
            InitializeComponent();
            //count = counter;
            //profiles = bufDataArray;
            string bufDataRow = "";
            int rowCount = 0;
            StreamReader fileForReader = new StreamReader("Schedule.txt");
            while ((bufDataRow = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufDataRow.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 6; k++) for (j = 0; j < 8; j++) { schedule1[j, k, i] = dataRow[rowCount]; rowCount++; }
                    for (k = 0; k < 2; k++) for (j = 0; j < 8; j++) { schedule2[j, k, i] = dataRow[rowCount]; rowCount++; }
                    rowCount = 0; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
            i = 0;
            fileForReader = new StreamReader("AddInformation.txt");
            while ((bufDataRow = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufDataRow.Split(new[] { '|' });
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
            while ((bufDataRow = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufDataRow.Split(new[] { '|' });
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
            while ((bufDataRow = fileForReader.ReadLine()) != null)
            {
                string[] dataRow = bufDataRow.Split(new[] { '|' });
                try
                {
                    for (k = 0; k < 24; k++) for (j = 0; j < 4; j++) { events[k, j, i] = dataRow[rowCount]; rowCount++; }
                    rowCount = 0; i++;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка в данных файла!");
                }
            }
            fileForReader.Close();
        }
        private void LabelExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            General generalForm = new General();
            generalForm.Show();
        }
        private void LabelProfile_Click(object sender, EventArgs e)
        {
            var shoolProfInfForm = new ShoolProfInf(count, profiles) { MdiParent = this };
            shoolProfInfForm.Show();
        }
        private void LabelSchedule_Click(object sender, EventArgs e)
        {
            var scheduleForm = new Schedule(count, schedule1, schedule2) { MdiParent = this };
            scheduleForm.Show();
        }
        private void LabelTeacherAndClasses_Click(object sender, EventArgs e)
        {
            var techersandclassesForm = new TeachersAndClasses(count, teachersAndClasses) { MdiParent = this };
            techersandclassesForm.Show();
        }
        private void LabelEvents_Click(object sender, EventArgs e)
        {
            var eventsForm = new Events(count, events) { MdiParent = this };
            eventsForm.Show();
        }
        private void LabelAditionalInf_Click(object sender, EventArgs e)
        {
            var addform = new AIForm(count, additionalInf) { MdiParent = this };
            addform.Show();
        }
        private void ButtonDeleteAccount_Click(object sender, EventArgs e)
        {
            string dataRow = "";
            StreamWriter fileForWriter = new StreamWriter("Profiles.txt");
            for (i = 0; i < 10; i++)
            {
                dataRow = "";
                if (i == count) dataRow = "||||||";
                else for (k = 0; k < 6; k++) dataRow = dataRow + profiles[i, k] + '|';
                fileForWriter.WriteLine(dataRow);
            }
            fileForWriter.Close();
            fileForWriter = new StreamWriter("TeacherAndClasses.txt");
            for (i = 0; i < 10; i++)
            {
                dataRow = "";
                if (i == count) dataRow = "||||||||||||||||||||||||";
                else for (k = 0; k < 24; k++) dataRow = dataRow + teachersAndClasses[i, k] + '|';
                fileForWriter.WriteLine(dataRow);
            }
            fileForWriter.Close();
            fileForWriter = new StreamWriter("Schedule.txt");
            for (i = 0; i < 10; i++)
            {
                dataRow = "";
                if (i == count) dataRow = "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
                else
                {
                    for (k = 0; k < 6; k++) for (j = 0; j < 8; j++) dataRow = dataRow + schedule1[j, k, i] + '|';
                    for (k = 0; k < 2; k++) for (j = 0; j < 8; j++) dataRow = dataRow + schedule2[j, k, i] + '|';
                }
                fileForWriter.WriteLine(dataRow);
            }
            fileForWriter.Close();
            fileForWriter = new StreamWriter("Events.txt");
            for (i = 0; i < 10; i++)
            {
                dataRow = "";
                if (i == count) dataRow = "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
                else for (k = 0; k < 24; k++) for (j = 0; j < 4; j++) dataRow = dataRow + events[k, j, i] + '|';
                fileForWriter.WriteLine(dataRow);
            }
            fileForWriter.Close();
            fileForWriter = new StreamWriter("AddInformation.txt");
            for (i = 0; i < 10; i++)
            {
                dataRow = "";
                if (i == count) dataRow = "|||||||||||||||||||||||||||||";
                else for (k = 0; k < 29; k++) dataRow = dataRow + additionalInf[i, k] + '|';
                fileForWriter.WriteLine(dataRow);
            }
            fileForWriter.Close();
            MessageBox.Show(@"Удаление прошло успешно");
            this.Hide();
            General generalForm = new General();
            generalForm.Show();
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Blue;
            Font underlineFont = new Font(DefaultFont.Name, DefaultFont.Size, FontStyle.Underline, DefaultFont.Unit, DefaultFont.GdiCharSet, DefaultFont.GdiVerticalFont);
            ((Label)sender).Font = underlineFont;
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            ((Label)sender).Font = DefaultFont;
            labelExit.ForeColor = Color.White;
        }
    }
}