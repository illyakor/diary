using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace TRPO
{
    class DataRepository
    {
        public static Dictionary<string, string> ReadFileUser()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            using (FileStream fs = new FileStream("Users.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    users = (Dictionary<string, string>)jsonFormatter.ReadObject(fs);
                else
                    users = new Dictionary<string, string>();
            }
            return users;
        }
        public static Dictionary<string, User> ReadFileProf()
        {
            Dictionary<string, User> usersProf = new Dictionary<string, User>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, User>));
            using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    usersProf = (Dictionary<string, User>)jsonFormatter.ReadObject(fs);
                else
                    usersProf = new Dictionary<string, User>();
            }
            return usersProf;
        }
        public static Dictionary<string, string> WriteFileUser(Dictionary<string, string> newUsers)
        {
            DataContractJsonSerializer jsonFormatterUser = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            using (FileStream fs = new FileStream("Users.json", FileMode.OpenOrCreate))
            {
                jsonFormatterUser.WriteObject(fs, newUsers);
            }
            return newUsers;
        }
        public static Dictionary<string, User> WriteFileProf(Dictionary<string, User> newUserProf)
        {
            DataContractJsonSerializer jsonFormatterUser = new DataContractJsonSerializer(typeof(Dictionary<string, User>));
            using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            {
                jsonFormatterUser.WriteObject(fs, newUserProf);
            }
            return newUserProf;
        }
        public static Dictionary<string, Week> ReadFileSchedule()
        {
            Dictionary<string, Week> schedule = new Dictionary<string, Week>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, Week>));
            using (FileStream fs = new FileStream("Schedule.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    schedule = (Dictionary<string, Week>)jsonFormatter.ReadObject(fs);
                else
                    schedule = new Dictionary<string, Week>();
            }
            return schedule;
        }
        public static Dictionary<string, Week> WriteFileSchedule(Dictionary<string, Week> newSchedule)
        {
            DataContractJsonSerializer jsonFormatterUser = new DataContractJsonSerializer(typeof(Dictionary<string, Week>));
            using (FileStream fs = new FileStream("Schedule.json", FileMode.OpenOrCreate))
            {
                jsonFormatterUser.WriteObject(fs, newSchedule);
            }
            return newSchedule;
        }
    }
}