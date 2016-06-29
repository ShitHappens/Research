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

            foreach (var answerId in answerIDs)
            {
                decimal id = decimal.Parse(answerId.ToString());
                BO.Answer.Result answer = BO.Answer.Load(id);

                mark += answer.dcm_mark;
            }

            BO.Account.Result user = BO.Account.Load(userID);

            mark = decimal.Round(mark * 100 / ttlScore, 2, MidpointRounding.AwayFromZero);

            BO.Account.Set(new BO.Account.Filter()
            {
                dcm_avg_rating = mark,
                pk = userID
            });

            mi.Result["UserName"] = user.str_name;
            mi.Result["Mark"] = mark;
        }
    }
}