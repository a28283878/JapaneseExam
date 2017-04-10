using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NewJapaneseExam.Models
{
    public class Repository
    {
        protected static string ConnectionString = string.Empty;

        public static void Init()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public static List<Verb> GetAllWord()
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {
               
                return cn.Query<Verb>("verbexam.GetAllWord", new { }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Verb> GetAllWordByType(int type)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetAllWordByType",new { type = type }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Verb> GetWordByTypeAndNumber(int type, int number)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetWordByTypeAndNumbrt", new { type = type , number = number}, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static void AddorMinusChineseToJapaneseWrongPoint(int id,int points)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                cn.Query<Verb>("verbexam.AddorMinusChineseToJapaneseWrongPoint", new { id = id ,points = points}, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddorMinusVoiceToChineseWrongPoint(int id, int points)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                cn.Query<Verb>("verbexam.AddorMinusVoiceToChineseWrongPoint", new { id = id, points = points }, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<Verb> GetChineseToJapaneseWordWrong(int type)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetChineseToJapaneseWordWrong", new { type = type }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Verb> GetVoiceToChineseWordWrong(int type)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetVoiceToChineseWordWrong", new { type = type }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<Verb> GetOneDayWordByType(DateTime OneDay, int type)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetOneDayWordByType",new { OneDay = OneDay , type = type }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static Verb GetOneWordById(int id)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                return cn.Query<Verb>("verbexam.GetOneWordById", new { id = id }, commandType: CommandType.StoredProcedure).First();
            }
        }

        public static void InsertNewWord(string chinesecol,string verbcol, int type)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                cn.Query("verbexam.InsertNewWord",new {chinesecol = chinesecol,verbcol = verbcol, type = type }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void UpdateWord(int id,string chinese, string japanese, string note)
        {
            using (var cn = new MySqlConnection(ConnectionString))
            {

                cn.Query("verbexam.UpdateWord", new { id = id ,chinese = chinese, japanese = japanese,note = note }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}