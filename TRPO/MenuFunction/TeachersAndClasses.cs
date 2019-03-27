﻿using System;
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
        string message = "message";
        Dictionary<string, List<string>> Classes = new Dictionary<string, List<string>>();
        List<string> UserClasses;
        public TeachersAndClasses()
        {
            InitializeComponent();
            FillGrid();
        }
        public void FillGrid()
        {
            Classes = GetTAC();
            UserClasses = Classes[General.loginUser];
            for (k = 1; k < 25; k++)
            {
                dataGridView1.Rows[k - 1].HeaderCell.Value = Schedule.teacher[k];
                dataGridView1.Rows[k - 1].Cells[0].Value = UserClasses[k - 1];
            }
        }
        private Dictionary<string, List<string>> GetTAC()
        {
            try
            {
                message = JsonConvert.SerializeObject(Classes);
                Client.SendMessageFromSocket(11000, message);
                Classes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Client.msgg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Classes = new Dictionary<string, List<string>>();
            }
            return Classes;
        }
        private void SetTAC(Dictionary<string, List<string>> tac)
        {
            try
            {
                message = JsonConvert.SerializeObject(tac);
                Client.SendMessageFromSocket(11000, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            UserClasses = new List<string>();
            for (k = 0; k < 24; k++)
            {
                UserClasses.Add(dataGridView1.Rows[k].Cells[0].Value.ToString());
            }
            Classes[General.loginUser] = UserClasses;
            SetTAC(Classes);
            MessageBox.Show("Сохранение прошло успешно!(ЭТО ШУТКА)");
        }
    }
}