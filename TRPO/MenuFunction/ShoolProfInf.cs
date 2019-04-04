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
            newUserProf = GetProf();
            Prof = newUserProf[General.loginUser];
            LastNameTextBox.Text = Prof[0];
            NameTextBox.Text = Prof[1];
            PatronymicTextBox.Text = Prof[2];
            LoginTextBox.Text = Prof[3];
            PasswordTextBox.Text = Prof[4];
            dateTimePicker1.Text = Prof[5];
        }
        private Dictionary<string, List<string>> GetProf()
        {
            try
            {
                Client.SendMessageFromSocket(11000, JsonConvert.SerializeObject(newUserProf) + "|read");
                newUserProf = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Client.msgg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                newUserProf = new Dictionary<string, List<string>>();
            }
            return newUserProf;
        }
        private void SetProf(Dictionary<string, List<string>> prof, object sender)
        {
            try
            {
                Client.SendMessageFromSocket(11000, JsonConvert.SerializeObject(prof));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                SetProf(newUserProf, sender);
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