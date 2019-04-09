using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TRPO
{
    public partial class TeachersAndClasses : Form
    {
        int k = 0;
        Dictionary<string, List<string>> Classes = new Dictionary<string, List<string>>();
        List<string> UserClasses;
        public TeachersAndClasses()
        {
            InitializeComponent();
            FillGrid();
        }
        public void FillGrid()
        {
            Classes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(GetSet.Get(Classes));
            UserClasses = Classes[General.loginUser];
            for (k = 1; k < 25; k++)
            {
                dataGridView1.Rows[k - 1].HeaderCell.Value = Schedule.teacher[k];
                dataGridView1.Rows[k - 1].Cells[0].Value = UserClasses[k - 1];
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            UserClasses = new List<string>();
            for (k = 0; k < 24; k++)
            {
                UserClasses.Add(dataGridView1.Rows[k].Cells[0].Value.ToString());
            }
            Classes[General.loginUser] = UserClasses;
            GetSet.Set(UserClasses);
            MessageBox.Show("Сохранение прошло успешно!(ЭТО ШУТКА)");
        }
    }
}