using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRPO
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void LabelExit_Click(object sender, EventArgs e)
        {
            General.GetGeneral().Show();
            this.Close();
        }
        private void LabelProfile_Click(object sender, EventArgs e)
        {
            var shoolProfInfForm = new ShoolProfInf() { MdiParent = this };
            shoolProfInfForm.Show();
        }
        private void LabelSchedule_Click(object sender, EventArgs e)
        {
            var scheduleForm = new Schedule() { MdiParent = this };
            scheduleForm.Show();
        }
        private void LabelTeacherAndClasses_Click(object sender, EventArgs e)
        {
            var techersandclassesForm = new TeachersAndClasses() { MdiParent = this };
            techersandclassesForm.Show();
        }
        private void LabelEvents_Click(object sender, EventArgs e)
        {
            //var eventsForm = new Events() { MdiParent = this };
            //eventsForm.Show();
        }
        private void LabelAditionalInf_Click(object sender, EventArgs e)
        {
            //var addform = new AIForm() { MdiParent = this };
            //addform.Show();
        }
        private void ButtonDeleteAccount_Click(object sender, EventArgs e)
        {
            DeleteProfUser(sender);
            MessageBox.Show("Эта функция реализована не польностью");
        }
        private void DeleteProfUser(object sender)
        {
            Dictionary<string, User> userProf = DataRepository.ReadProf();
            DataRepository.WriteProf(userProf, sender);
        }
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = Color.Blue;
            Font underlineFont = new Font(DefaultFont.Name, DefaultFont.Size, FontStyle.Underline, DefaultFont.Unit, DefaultFont.GdiCharSet, DefaultFont.GdiVerticalFont);
            ((Label)sender).Font = underlineFont;
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            ((Label)sender).Font = DefaultFont;
            labelExit.ForeColor = Color.White;
        }
    }
}
