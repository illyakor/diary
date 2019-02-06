using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO
{
    public class User
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string lastName, string name, string patronymic, string birthDate, string login, string password)
        {
            LastName = lastName;
            Name = name;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Login = login;
            Password = password;
        }
    }
}