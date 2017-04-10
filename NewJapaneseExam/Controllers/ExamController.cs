using NewJapaneseExam.Models;
using NewJapaneseExam.ModelScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Speech.Synthesis;

namespace NewJapaneseExam.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        [HttpGet]
        public ActionResult AllWord()
        {
            List<Verb> Verbs = Repository.GetAllWord();
            return View(Verbs);
        }

        public ActionResult AllwordPartial(int type)
        {
            List<Verb> Verbs = Repository.GetAllWordByType(type);
            return PartialView("_AllwordPartial",Verbs);

        }

        [HttpGet]
        public ActionResult Insert(int type)
        {
            ViewBag.Type = type;
            return View();
        }

        [HttpGet]
        public ActionResult VoiceToChineseAllRandom(int type)
        {
            List<Verb> Verbs = Repository.GetAllWordByType(type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "All Random";
            return View("VoiceToChinese", Verbs);
        }

        [HttpGet]
        public ActionResult VoiceToChineseTodayRandom(int type)
        {
            List<Verb> Verbs = Repository.GetOneDayWordByType(DateTime.Today, type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "Today Random";
            return View("VoiceToChinese", Verbs);
        }

        [HttpGet]
        public ActionResult VoiceToChineseSelectOneDayRandom(DateTime date, int type)
        {
            List<Verb> Verbs = Repository.GetOneDayWordByType(date, type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.date = date.ToShortDateString();
            ViewBag.Title = date.ToShortDateString() + " Random";
            return View("VoiceToChinese", Verbs);
        }

        [HttpGet]
        public ActionResult VoiceToChineseWordWrong(int type)
        {
            List<Verb> Verbs = Repository.GetVoiceToChineseWordWrong(type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "Wrong Random";
            return View("VoiceToChinese", Verbs);
        }

        [HttpGet]
        public ActionResult VoiceToChineseGetWordByTypeAndNumber(int type, int number)
        {
            List<Verb> Verbs = Repository.GetWordByTypeAndNumber(type, number);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = number + " Random";
            return View("VoiceToChinese", Verbs);
        }

        //Chinese to japanese

        [HttpGet]
        public ActionResult GetWordByTypeAndNumber(int type, int number)
        {
            List<Verb> Verbs = Repository.GetWordByTypeAndNumber(type, number);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = number + " Random";
            return View("ChineseToJapanese", Verbs);
        }

        [HttpGet]
        public ActionResult AllRandom(int type)
        {
            List<Verb> Verbs = Repository.GetAllWordByType(type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "All Random";
            return View("ChineseToJapanese", Verbs);
        }

        [HttpGet]
        public ActionResult TodayRandom(int type)
        {
            List<Verb> Verbs = Repository.GetOneDayWordByType(DateTime.Today, type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "Today Random";
            return View("ChineseToJapanese", Verbs);
        }

        [HttpGet]
        public ActionResult SelectOneDayRandom(DateTime date, int type)
        {
            List<Verb> Verbs = Repository.GetOneDayWordByType(date, type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.date = date.ToShortDateString();
            ViewBag.Title = date.ToShortDateString() + " Random";
            return View("ChineseToJapanese", Verbs);
        }

        [HttpGet]
        public ActionResult Setting(int id)
        {
            Verb Verb = Repository.GetOneWordById(id);
            return View(Verb);
        }

        [HttpGet]
        public ActionResult ChineseToJapaneseWordWrong(int type)
        {
            List<Verb> Verbs = Repository.GetChineseToJapaneseWordWrong(type);
            Verbs = ListShuffle.Shuffle(Verbs);
            ViewBag.Title = "Wrong Random";
            return View("ChineseToJapanese", Verbs);
        }

        [HttpPost]
        public void Send(string chinese, string japanese, int type)
        {
            Repository.InsertNewWord(chinese, japanese, type);
        }

        [HttpPost]
        public void UpdateVerb(int id, string chinese, string japanese, string note)
        {
            Repository.UpdateWord(id, chinese, japanese, note);
        }

        [HttpPost]
        public void AddorMinusChineseToJapaneseWrongPoint(int id, int point)
        {
            Repository.AddorMinusChineseToJapaneseWrongPoint(id, point);
        }

        [HttpPost]
        public void AddorMinusVoiceToChineseWrongPoint(int id, int point)
        {
            Repository.AddorMinusVoiceToChineseWrongPoint(id, point);
        }
    }
}