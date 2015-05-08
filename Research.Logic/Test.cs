using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.Logic
{
    public class Test
    {
        public void SimpleTestByTheme()
        {
            BO.Theme.Result themes = BO.Theme.GetAll(new BO.Theme.Filter() { });

            foreach (BO.Theme.Result theme in themes)
            {
                Console.WriteLine(string.Format("{0} {1}", theme.pk, theme.str_name));
            }

            Console.WriteLine("Выберите тему теста");

            decimal score = 0m;
            decimal totalScore = 0m;

            int themeNum;

            string strThemNum = Console.ReadLine();

            if (int.TryParse(strThemNum, out themeNum))
            {
                BO.Question.Result qs = BO.Question.GetAll(new BO.Question.Filter() { fk_theme = themeNum });

                if (BO.Question.Result.IsEmpty(qs))
                {
                    Console.WriteLine("Вопросов для такой темы нету");
                }
                else
                {
                    foreach (BO.Question.Result q in qs)
                    {
                        Console.WriteLine(string.Format("{0} {1}", q.pk, q.str_text));

                        BO.Answer.Result answers = BO.Answer.GetAll(new BO.Answer.Filter() { fk_question = q.pk });

                        foreach (BO.Answer.Result answer in answers)
                        {
                            totalScore += answer.dcm_mark;
                            Console.WriteLine(string.Format("{0} {1}", answer.pk, answer.str_text));
                        }

                        Console.WriteLine("Виберите правильный ответ");

                        int answerNum;

                        string strAnswerNum = Console.ReadLine();

                        if (int.TryParse(strAnswerNum, out answerNum))
                        {
                            BO.Answer.Result finalAnswer = BO.Answer.Load(answerNum);
                            score += finalAnswer.dcm_mark;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не число!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
            }

            Console.WriteLine(string.Format("Ваша оценка {0} из {1}", score, totalScore));

        }
    }
}
