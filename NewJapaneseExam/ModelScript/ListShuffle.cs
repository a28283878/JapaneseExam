using NewJapaneseExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJapaneseExam.ModelScript
{
    public class ListShuffle
    {
        public static List<Verb> Shuffle(List<Verb> target)
        {
            Random rdm = new Random();
            int targetNumber = target.Count;
            for (int time = 0; time < 5; time++)
            {
                for (int i = 0; i < targetNumber; i++)
                {
                    
                    int num = rdm.Next(0,targetNumber);

                    Verb temp = new Verb();
                    temp = target[i];
                    target[i] = target[num];
                    target[num] = temp;

                }
            }
            return target; 
        }
    }
}