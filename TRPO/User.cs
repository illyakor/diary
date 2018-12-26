using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TRPO
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Patronymic { get; set; }
        [DataMember]
        public string BirthDate { get; set; }

        public User(string lastName, string name, string patronymic, string birthDate)
        {
            LastName = lastName;
            Name = name;
            Patronymic = patronymic;
            BirthDate = birthDate;
        }
    }
}