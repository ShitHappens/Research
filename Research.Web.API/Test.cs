using DevReactor.Toolbox.API.Attributes;
using DevReactor.Toolbox.API.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Research.Web
{
    [Namespace]
    public class Test
    {
        [AuthMethod]
        public static void Submit(Method mi)
        {
            int ttlScore = mi.Args["Score"].Value<int>();
            var answerIDs = mi.Args["AnswerIDs"];
            int userID = mi.Args["UserID"].Value<int>();
            decimal mark = 0m;

            BO.Theme.Result theme = null;

            foreach (int answerId in answerIDs)
            {
                decimal id = decimal.Parse(answerId.ToString());
                BO.Answer.Result answer = BO.Answer.Load(id);

                if (BO.Theme.Result.IsEmpty(theme))
                {
                    var question = BO.Question.Load(answer.fk_question);
                    theme = BO.Theme.Load(question.fk_theme);
                }

                mark += answer.dcm_mark;
            }

            BO.Account.Result user = BO.Account.Load(userID);

            mark = decimal.Round(mark * 100 / ttlScore, 2, MidpointRounding.AwayFromZero);

            //BO.Account.Set(new BO.Account.Filter()
            //{
            //    dcm_avg_rating = mark,
            //    pk = userID
            //});

            BO.Account2Theme.Result oldAcc2Theme = BO.Account2Theme.Get(new BO.Account2Theme.Filter()
            {
                fk_account = userID,
                fk_theme = theme.pk
            });

            if (BO.Account2Theme.Result.IsEmpty(oldAcc2Theme))
                BO.Account2Theme.Set(new BO.Account2Theme.Filter()
                {
                    dcm_mark = mark,
                    fk_account = userID,
                    fk_theme = theme.pk
                });
            else
            {
                BO.Account2Theme.Set(new BO.Account2Theme.Filter()
                {
                    dcm_mark = mark,
                    pk = oldAcc2Theme.pk
                });
            }

            mi.Result["UserName"] = user.str_name;
            mi.Result["Mark"] = mark;
            mi.Result["Subject"] = theme.str_name;
        }
    }
}