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
        [AuthMethod]
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
        [AuthMethod]
        public static void GetTypes(Method mi)
        {
            JArray jTypes = new JArray();
            BO.QuestionType.Result types = BO.QuestionType.GetAll(new BO.QuestionType.Filter());

            foreach (BO.QuestionType.Result type in types)
            {
                JObject jType = new JObject();

                BO.Question.Result questionsByType = BO.Question.GetAll(new BO.Question.Filter() { fk_type = type.pk });

                jType["ID"] = type.pk;
                jType["Description"] = type.str_description;
                jType["NumberOfQuestions"] = questionsByType.Count;
                jTypes.Add(jType);
            }
            mi.Result["Types"] = jTypes;
        }

    }
}