using System;

namespace NewJapaneseExam.Models
{
    public class Verb
    {
        public int id { get; set; }
        public string japanese { get; set; }
        public string chinese { get; set; }
        public DateTime insert_date { get; set; }
        public int VoiceToChineseWrong { get; set; }
        public int ChineseToJapaneseWrong { get; set; }
        public int star { get; set; }
        public int type { get; set; }
        public string note { get; set; }
    }
}