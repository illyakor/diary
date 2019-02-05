using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TRPO
{
    class RepositoryCreateTableMySQL
    {
        public static void CreateTableProf()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Prof";
            conn.Open();
            MySqlDataReader Reader;
            try
            {
                Reader = cmd.ExecuteReader();
            }
            catch(MySqlException)
            {
                cmd.CommandText = "CREATE TABLE Prof (DateReg DATETIME, Surname VARCHAR(255), Name VARCHAR(255), Patronymic VARCHAR(255), DateBirth VARCHAR(255), Login VARCHAR(255), Password VARCHAR(255));";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static void CreateTableTeacherAndClasses()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM TAC";
            conn.Open();
            MySqlDataReader Reader;
            try
            {
                Reader = cmd.ExecuteReader();
            }
            catch (MySqlException)
            {
                cmd.CommandText = "CREATE TABLE TAC (LoginUser VARCHAR(255), T1 VARCHAR(255), T2 VARCHAR(255), T3 VARCHAR(255), T4 VARCHAR(255), T5 VARCHAR(255), T6 VARCHAR(255), T7 VARCHAR(255), T8 VARCHAR(255), T9 VARCHAR(255), T10 VARCHAR(255), T11 VARCHAR(255), T12 VARCHAR(255), T13 VARCHAR(255), T14 VARCHAR(255), T15 VARCHAR(255), T16 VARCHAR(255), T17 VARCHAR(255), T18 VARCHAR(255), T19 VARCHAR(255), T20 VARCHAR(255), T21 VARCHAR(255), T22 VARCHAR(255), T23 VARCHAR(255), T24 VARCHAR(255));";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static void CreateTableAdditionalInformation()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM AddInf";
            conn.Open();
            MySqlDataReader Reader;
            try
            {
                Reader = cmd.ExecuteReader();
            }
            catch (MySqlException)
            {
                cmd.CommandText = "CREATE TABLE AddInf (DateReg DATETIME, Surname VARCHAR(255), Name VARCHAR(255), Patronymic VARCHAR(255), DateBirth VARCHAR(255), Login VARCHAR(255), Password VARCHAR(255));";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
