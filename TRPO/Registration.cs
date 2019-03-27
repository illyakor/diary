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
    public partial class Registration : Form
    {
        string message = "message";
        Dictionary<string, List<string>> newUserProf = new Dictionary<string, List<string>>();
        public Registration(string textbox1, string textbox2, DateTime datetimepicker1)
        {
            InitializeComponent();
            LastNameTextBox.Text = textbox1;
            NameTextBox.Text = textbox2;
            dateTimePicker1.Value = datetimepicker1;
        }
        private Dictionary<string, List<string>> GetProf()
        {
            try
            {
                message = JsonConvert.SerializeObject(newUserProf);
                Client.SendMessageFromSocket(11000, message);
                newUserProf = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Client.msgg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                newUserProf = new Dictionary<string, List<string>>();
            }
            return newUserProf;
        }
        private void SetProf(Dictionary<string, List<string>> prof)
        {
            try
            {
                message = JsonConvert.SerializeObject(prof);
                Client.SendMessageFromSocket(11000, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ButtonRegistration(object sender, EventArgs e)
        {
            if (AllFieldsValid())
            {
                newUserProf = GetProf();
                List<string> Prof = new List<string>()
                {
                    LastNameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, dateTimePicker1.Text, LoginTextBox.Text, PasswordTextBox.Text
                };
                newUserProf[LoginTextBox.Text] = Prof;
                SetProf(newUserProf);
                General.loginUser = LoginTextBox.Text;
                MessageBox.Show(@"Вы успешно зарегистрированы!");
            }
            else MessageBox.Show(@"Заполнение всех полей обязательно!");
        }
        private bool AllFieldsValid()
        {
            return (LastNameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "" && LoginTextBox.Text != "" &&
                PasswordTextBox.Text != "");
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
        }
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.DarkGreen;
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            General.GetGeneral().Show();
            this.Close();
        }
        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.White;
            ((Label)sender).Font = DefaultFont;
        }
        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Blue;
            Font underlineFont = new Font(DefaultFont.Name, DefaultFont.Size, FontStyle.Underline, DefaultFont.Unit, DefaultFont.GdiCharSet,
                DefaultFont.GdiVerticalFont);
            ((Label)sender).Font = underlineFont;
        }
    }
}
