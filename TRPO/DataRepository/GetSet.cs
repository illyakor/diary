using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace TRPO
{
    class GetSet
    {
        public static string Get(object obj)
        {
            string ot = "";
            try
            {
                string message = JsonConvert.SerializeObject(obj) + "|read";
                Client.SendMessageFromSocket(11000, message);
                ot = Client.answer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ot = "{}";
            }
            return ot;
        }
        public static void Set(object obj)
        {
            try
            {
                Client.SendMessageFromSocket(11000, JsonConvert.SerializeObject(obj));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
