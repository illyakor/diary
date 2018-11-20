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
            using (FileStream fs = new FileStream("People.json", FileMode.OpenOrCreate))
            {
                try
                {
                    users = (Dictionary<string, string>)jsonFormatter.ReadObject(fs);
                }
                catch
                {
                    //users = null;
                }
            }
            return users;
        }
        public static Dictionary<string, User> ReadFileProf()
        {
            Dictionary<string, User> usersProf = new Dictionary<string, User>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, User>));
            using (FileStream fs = new FileStream("ProfFile.json", FileMode.OpenOrCreate))
            {
                try
                {
                    usersProf = (Dictionary<string, User>)jsonFormatter.ReadObject(fs);
                }
                catch
                {
                    //users = null;
                }
            }
            return usersProf;
        }
    }
}
