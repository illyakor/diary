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
    public partial class Starting : Form
    {
        public Starting()
        { 
            InitializeComponent();
            this.Hide();
            General generalForm = new General();
            generalForm.ShowDialog();
        }
    }
}
