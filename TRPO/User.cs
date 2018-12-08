using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TRPO
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Patronymic { get; set; }
        [DataMember]
        public string BirthDate { get; set; }

        public User(string name, string lastName, string patronymic, string birthDate)
        {
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            BirthDate = birthDate;
        }
    }
}
