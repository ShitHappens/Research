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
        public abstract class RetCodes
        {
            public const int NoQuestions = 5;
        }

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

        [AuthMethod]
        public static void GetSubjects(Method mi)
        {
            JArray jSubjects = new JArray();
            BO.Theme.Result types = BO.Theme.GetAll(new BO.Theme.Filter());

            foreach (BO.Theme.Result type in types)
            {
                JObject jSubject = new JObject();

                jSubject["ID"] = type.pk;
                jSubject["Description"] = type.str_name;
                jSubjects.Add(jSubject);
            }
            mi.Result["Subjects"] = jSubjects;
        }

        [AuthMethod]
        public static void SetSubject(Method mi)
        {
            string text = mi.Args["Text"].ToString();
            BO.Theme.Filter f = new BO.Theme.Filter();
            f.str_name = text;

            BO.Theme.Set(f);
        }

        [AuthMethod]
        public static void GetQuestionByType(Method mi)
        {
            int typeId = mi.Args["TypeID"].Value<int>();

            JObject jQuestion = new JObject();
            JArray jAnswers = new JArray();
            List<BO.Question.Result> lqs = new List<BO.Question.Result>();

            BO.Question.Result qs = BO.Question.GetAll(new BO.Question.Filter() { fk_type = typeId });

            foreach (BO.Question.Result q in qs)
            {
                lqs.Add(q);
            }

            BO.Question.Result q1 = lqs.Aggregate<BO.Question.Result>((c, d) => c.dcm_complexity < d.dcm_complexity ? c : d);
            jQuestion["ID"] = q1.pk;
            jQuestion["Text"] = q1.str_text;
            jQuestion["Complexity"] = q1.dcm_complexity;

            BO.Answer.Result answers = BO.Answer.GetAll(new BO.Answer.Filter() { fk_question = q1.pk });

            foreach (BO.Answer.Result answer in answers)
            {
                JObject jAnswer = new JObject();

                jAnswer["ID"] = answer.pk;
                jAnswer["Text"] = answer.str_text;

                jAnswers.Add(jAnswer);
            }

            mi.Result["Question"] = jQuestion;
            mi.Result["Answers"] = jAnswers;

        }
        [AuthMethod]
        public static void GetNextQuestion(Method mi)
        {
            int answerId = mi.Args["Answer"].Value<int>();
            BO.Answer.Result answer = BO.Answer.Load(answerId);
            BO.Question.Result lastQuestion = BO.Question.Load(answer.fk_question);
            BO.Question.Result allQuestions = BO.Question.GetAll(new BO.Question.Filter() { fk_type = lastQuestion.fk_type });
            BO.Question.Result newQuestion = null;

            JArray qIds = (JArray)mi.Args["Questions"];

            List<int?> lInt = new List<int?>();
            foreach (JValue j in qIds)
            {
                lInt.Add(j.Value<int>());
            }


            if (answer.dcm_mark == 1)
            {
                foreach (BO.Question.Result q in allQuestions)
                {
                    if (!lInt.Contains(q.pk) && q.dcm_complexity > lastQuestion.dcm_complexity)
                    {
                        newQuestion = q;
                        break;
                    }
                }
            }
            else
            {
                foreach (BO.Question.Result q in allQuestions)
                {
                    if (!lInt.Contains(q.pk) && q.dcm_complexity <= lastQuestion.dcm_complexity)
                    {
                        newQuestion = q;
                        break;
                    }

                }

            }

            if (newQuestion != null)
            {
                JObject jQuestion = new JObject();
                jQuestion["ID"] = newQuestion.pk;
                jQuestion["Text"] = newQuestion.str_text;
                jQuestion["Complexity"] = newQuestion.dcm_complexity;
                mi.Result["Question"] = jQuestion;

                JArray jAnswers = new JArray();

                BO.Answer.Result answers = BO.Answer.GetAll(new BO.Answer.Filter() { fk_question = newQuestion.pk });

                foreach (BO.Answer.Result a in answers)
                {
                    JObject jAnswer = new JObject();

                    jAnswer["ID"] = a.pk;
                    jAnswer["Text"] = a.str_text;

                    jAnswers.Add(jAnswer);
                }
                mi.Result["Answers"] = jAnswers;

            }
            else
            {
                mi.ErrorCode = RetCodes.NoQuestions;
                mi.ErrorMessage = "Test is ended";
            }
        }

        [AuthMethod]
        public static void GetAllForQuestions(Method mi)
        {
            JArray jTypes = new JArray();
            JArray jCategories = new JArray();

            BO.QuestionType.Result types = BO.QuestionType.GetAll(new BO.QuestionType.Filter());
            foreach (BO.QuestionType.Result type in types)
            {
                JObject jType = new JObject();
                jType["ID"] = type.pk;
                jType["Text"] = type.str_description;
                jTypes.Add(jType);
            }

            BO.Theme.Result categories = BO.Theme.GetAll(new BO.Theme.Filter());
            foreach (BO.Theme.Result category in categories)
            {
                JObject jCategory = new JObject();
                jCategory["ID"] = category.pk;
                jCategory["Name"] = category.str_name;
                jCategories.Add(jCategory);
            }
            mi.Result["Types"] = jTypes;
            mi.Result["Categories"] = jCategories;
        }

        [AuthMethod]
        public static void SetQuestion(Method mi)
        {
            string text = mi.Args["Text"].ToString();
            int type = mi.Args["Type"].Value<int>();
            int theme = mi.Args["Category"].Value<int>();
            string cmplx = mi.Args["Complexity"].ToString().Replace('.', ',');
            decimal complexity = 0m;
            decimal.TryParse(cmplx, out complexity);

            BO.Question.Set(new BO.Question.Filter()
            {
                str_text = text,
                fk_theme = theme,
                fk_type = type,
                int_time = 60,
                dcm_complexity = complexity
            });

            mi.ErrorCode = 0;
        }

        [AuthMethod]
        public static void GetQuestions(Method mi)
        {
            string complexity = mi.Args["Complexity"].ToString();
            int subjID = mi.Args["SubjectID"].Value<int>();
            int numberOfQuestions;
            if (!string.IsNullOrEmpty(mi.Args["NumberOfQuestions"].ToString()))
                numberOfQuestions = mi.Args["NumberOfQuestions"].Value<int>();
            else
                numberOfQuestions = 10; 
            BO.Question.Result questions = BO.Question.Get(new BO.Question.Filter()
            {
                fk_theme = subjID,
                pagesize = numberOfQuestions,
                page = 1
            
            });

            JArray jQuestions = new JArray();

            foreach(BO.Question.Result question in questions)
            {
                JObject jq = new JObject();
                jq["ID"] = question.pk;
                jq["Text"] = question.str_text;
                jq["Type"] = question.fk_type;

                JArray jAnswers = new JArray();
                BO.Answer.Result answers = BO.Answer.GetAll(new BO.Answer.Filter() { fk_question = question.pk });
                foreach(BO.Answer.Result answer in answers)
                {
                    JObject jAnswer = new JObject();
                    jAnswer["ID"] = answer.pk;
                    jAnswer["Text"] = answer.str_text;

                    jAnswers.Add(jAnswer);
                }

                jq["Answers"] = jAnswers;

                jQuestions.Add(jq);
            }

            mi.Result["Questions"] = jQuestions;
            mi.ErrorCode = 0;
        }

    }
}