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
        int k = 0;
        public TeachersAndClasses()
        {
            InitializeComponent();
            FillGrid();
        }
        public void FillGrid()
        {
            Dictionary<string, List<string>> classes = DataRepository.ReadTeacherAndClasse();
            List<string> userClasses = classes[General.loginUser];
            for (k = 1; k < 25; k++)
            {
                dataGridView1.Rows[k-1].HeaderCell.Value = Schedule.teacher[k];
                dataGridView1.Rows[k-1].Cells[0].Value = userClasses[k - 1];
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сохранение прошло успешно!(ЭТО ШУТКА)");
        }
    }
}