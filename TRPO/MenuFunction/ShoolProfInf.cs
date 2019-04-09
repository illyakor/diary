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
    public partial class ShoolProfInf : Form
    {
        Dictionary<string, List<string>> newUserProf = new Dictionary<string, List<string>>();
        List<string> Prof;
        public ShoolProfInf()
        {
            InitializeComponent();
            FillBoxes();
        }
        public void FillBoxes()
        {
            newUserProf = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(GetSet.Get(newUserProf));
            Prof = newUserProf[General.loginUser];
            LastNameTextBox.Text = Prof[0];
            NameTextBox.Text = Prof[1];
            PatronymicTextBox.Text = Prof[2];
            LoginTextBox.Text = Prof[3];
            PasswordTextBox.Text = Prof[4];
            dateTimePicker1.Text = Prof[5];
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {  
            if (AllFieldsValid())
            {
                Prof = new List<string>()
                {
                    LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text, LoginTextBox.Text, PasswordTextBox.Text
                };
                newUserProf[General.loginUser] = Prof;
                GetSet.Set(newUserProf);
                MessageBox.Show("Сохранение прошло успешно!");
            }
            else MessageBox.Show(@"Заполнение всех полей обязательно!");
        }
        private bool AllFieldsValid()
        {
            return (LastNameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "" && LoginTextBox.Text != "" &&
                PasswordTextBox.Text != "");
        }
    }
}