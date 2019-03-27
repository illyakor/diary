using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace TRPO
{
    class DataRepository
    {
        public static Dictionary<string, string> ReadFileUser()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            using (FileStream fs = new FileStream("Users.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    string message = fs.ToString();
                    users = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
                }
                else
                    users = new Dictionary<string, string>();
            }
            return users;
        }
        public static Dictionary<string, User> ReadFileProf()
        {
            Dictionary<string, User> usersProf = new Dictionary<string, User>();
            using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    string message = fs.ToString();
                    usersProf = JsonConvert.DeserializeObject<Dictionary<string, User>>(message);
                }
                else
                    usersProf = new Dictionary<string, User>();
            }
            return usersProf;
        }
        public static Dictionary<string, string> WriteFileUser(Dictionary<string, string> newUsers)
        {
            //DataContractJsonSerializer jsonFormatterUser = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            //using (FileStream fs = new FileStream("Users.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatterUser.WriteObject(fs, newUsers);
            //}
            return newUsers;
        }
        public static Dictionary<string, User> WriteFileProf(Dictionary<string, User> newUserProf)
        {
            //DataContractJsonSerializer jsonFormatterUser = new DataContractJsonSerializer(typeof(Dictionary<string, User>));
            //using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatterUser.WriteObject(fs, newUserProf);
            //}
            return newUserProf;
        }
        public static DataTable ReadTableScheduleUser (string log)
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }
}