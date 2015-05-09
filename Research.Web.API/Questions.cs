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
    public class Questions
    {
        [AnonymMethod]
        public static void Get(Method mi)
        {
            JArray jQuestions = new JArray();
            BO.Question.Result questions = BO.Question.GetAll(new BO.Question.Filter());

            foreach (BO.Question.Result question in questions)
            {
                JObject jQuestion = new JObject();
                jQuestion["ID"] = question.pk;
                jQuestion["Text"] = question.str_text;
                jQuestions.Add(jQuestion);
            }
            mi.Result["Questions"] = jQuestions;
        }
    }
}