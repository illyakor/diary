using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRPO
{
    class InputProtection
    {
        public static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '`' && e.KeyChar != '-')
                e.Handled = true;
        }
        public static void LoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || 
                e.KeyChar >= 58) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '`')
                e.Handled = true;
        }
        public static void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123) && e.KeyChar != 8 && (e.KeyChar <= 47 || 
                e.KeyChar >= 58))
                e.Handled = true;
        }
    }
}