using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TRPO
{
    class DataRepository
    {
        public static Dictionary<string, string> ReadUser()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Prof";
            conn.Open();
            MySqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                users[Reader["Login"].ToString()] = Reader["Password"].ToString();
            }
            conn.Close();
            conn.Dispose();
            return users;
        }
        public static Dictionary<string, User> ReadProf()
        {
            Dictionary<string, User> users = new Dictionary<string, User>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Prof WHERE Login = " + General.loginUser + ";";
            conn.Open();
            MySqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                users[Reader["Login"].ToString()] = new User(Reader["Surname"].ToString(), Reader["Name"].ToString(), Reader["Patronymic"].ToString(), Reader["DateBirth"].ToString(), Reader["Login"].ToString(), Reader["Password"].ToString());
            }
            conn.Close();
            conn.Dispose();
            return users;
        }
        public static Dictionary<string, User> WriteProf(Dictionary<string, User> newUserProf, object sender)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            if ((sender as Button).Text == "Зарегистрироваться")
            {
                cmd.CommandText = "INSERT INTO Prof VALUES(NOW(), '" + newUserProf[General.loginUser].LastName + "', '"
                + newUserProf[General.loginUser].Name + "', '" + newUserProf[General.loginUser].Patronymic + "', '"
                + newUserProf[General.loginUser].BirthDate + "', '" + newUserProf[General.loginUser].Login + "', '"
                + newUserProf[General.loginUser].Password + "');";
            }
            if ((sender as Button).Text == "Сохранить")
            {
                cmd.CommandText = "UPDATE Prof SET Surname = '" + newUserProf[General.loginUser].LastName + "', Name = '"
                    + newUserProf[General.loginUser].Name + "' , Patronymic = '" + newUserProf[General.loginUser].Patronymic +
                    "' , DateBirth = '" + newUserProf[General.loginUser].BirthDate + "' , Login = '"
                    + newUserProf[General.loginUser].Login + "' , Password = '" + newUserProf[General.loginUser].Password +
                    "' WHERE Login = " + General.loginUser + "; ";
            }
            if ((sender as Button).Text == "Удалить аккаунт")
            {
                cmd.CommandText = "DELETE FROM Prof WHERE Login = '" + General.loginUser + "';";
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            return newUserProf;
        }
        public static DataTable ReadTableScheduleUser(string log)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        public static Dictionary<string, List<string>> ReadTeacherAndClasse()
        {
            Dictionary<string, List<string>> classes = new Dictionary<string, List<string>>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM TAC WHERE LoginUser = " + General.loginUser + ";";
            conn.Open();
            MySqlDataReader Reader = cmd.ExecuteReader();
            int i = 0;
            if (Reader.Read())
            {
                classes[Reader["LoginUser"].ToString()] = new List<string>() { Reader["T1"].ToString(), Reader["T2"].ToString(), Reader["T3"].ToString(), Reader["T4"].ToString(), Reader["T5"].ToString(), Reader["T6"].ToString(), Reader["T7"].ToString(), Reader["T8"].ToString(), Reader["T9"].ToString(), Reader["T10"].ToString(), Reader["T11"].ToString(), Reader["T12"].ToString(), Reader["T13"].ToString(), Reader["T14"].ToString(), Reader["T15"].ToString(), Reader["T16"].ToString(), Reader["T17"].ToString(), Reader["T18"].ToString(), Reader["T19"].ToString(), Reader["T20"].ToString(), Reader["T21"].ToString(), Reader["T22"].ToString(), Reader["T23"].ToString(), Reader["T24"].ToString() };
                i++;
            }
            conn.Close();
            conn.Dispose();
            return classes;
        }
    }
}