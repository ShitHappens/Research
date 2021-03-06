﻿using DevReactor.Toolbox.API.Attributes;
using DevReactor.Toolbox.API.Methods;
using DevReactor.Toolbox.API.Sessions;
using DevReactor.Toolbox.Tools;
using Newtonsoft.Json.Linq;
using System;

namespace Research.Web
{
    [Namespace]
    public partial class Account
    {
        public abstract class RetCodes
        {
            public abstract class Login
            {
                public const int InvalidCredentials = 101;
            }

            public abstract class PasswordRequest
            {
                public const int InvalidMail = 997;
            }

            public abstract class Registration
            {
                public const int AccountAlreadyExists = 998;
                public const int Unfilled = 999;
                public const int WrongPassword = 996;
                public const int Mismatch = 995;
                public const int InvalidInvite = 994;
                public const int InviteAlreadyUsed = 993;
            }

            public abstract class Verification
            {
                public const int EmailMismatch = 201;
                public const int PhoneMismatch = 202;
            }
        }


        [AnonymMethod]
        public static void Login(Method mi)
        {
            BO.Account.Result account = BO.Account.Get(new BO.Account.Filter()
            {
                str_email = mi.Args["Email"].ToString(),
                str_password = mi.Args["Password"].ToString()
            });

            if (BO.Account.Result.IsEmpty(account))
            {
                mi.ErrorCode = RetCodes.Login.InvalidCredentials;
            }
            else
            {
                var dt = DevReactor.Toolbox.Tools.Helpers.Date.Now().AddMinutes(
                    DevReactor.Toolbox.API.Sessions.Settings.SessionTimeout);

                SessionItem si = new SessionItem(
                    account.pk.ToString(),
                    mi.Request.Params["UserAgent"] == null ? null : mi.Request.Params["UserAgent"].ToString(),
                    mi.Request.Params["IP"] == null ? null : mi.Request.Params["IP"].ToString(),
                    SourceType.API_WEB,
                    DevReactor.Toolbox.Tools.Config.Instance.Common["api-url"],
                    dt
                    );

                si = SessionManager.Instance.Add(si);

                mi.Request.AccountId = account.pk;
                mi.Data["SessionID"] = si.ID;
                mi.Data["UserID"] = (int)account.pk;
            }
        }


        [AuthMethod]
        public static void Read(Method mi)
        {
            int accountID = mi.Request.CurrentAccountAsIntGet();

            BO.Account.Result account = BO.Account.Load(accountID);

            JObject jAccount = new JObject();
            jAccount["ID"] = account.pk;
            jAccount["Email"] = account.str_email;
            jAccount["Rate"] = account.dcm_avg_rating;
            jAccount["Type"] = account.int_accounttype;

            mi.Result.Add("Account", jAccount);
        }

        [AnonymMethod]
        public static void Registration(Method mi)
        {
            string email = mi.Args["Email"].ToString();
            string password = mi.Args["Password"].ToString();
            string passwordRepeat = mi.Args["RepeatPassword"].ToString();

            if (password == passwordRepeat)
            {
                try
                {
                    BO.Account.Set(
                        new BO.Account.Filter()
                        {
                            str_email = email,
                            str_password = password,
                            int_accounttype = (int)BO.Account.Consts.AccountType.Operator
                        });
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogError(ex);
                    mi.ErrorCode = RetCodes.Registration.AccountAlreadyExists;
                }
            }
            else
            {
                mi.ErrorCode = RetCodes.Registration.Mismatch;
            }
        }

        #region logout
        [AnonymMethod]
        public static void Logout(Method mi)
        {
            SessionManager.Instance.Remove(mi.Request.SessionID);
            mi.Request.AccountId = null;
        }
        #endregion logout

        [AuthMethod]
        public static void GetStudents(Method mi)
        {
            JArray jStudents = new JArray();
            BO.Account.Result students = BO.Account.GetAll(new BO.Account.Filter() { int_accounttype = (int)BO.Account.Consts.AccountType.Student});

            foreach(BO.Account.Result student in students)
            {
                JObject jStudent = new JObject();
                jStudent["Name"] = student.str_name;
                jStudent["Email"] = student.str_email;

                JArray jSubjects = new JArray();
                BO.Account2Theme.Result acc2Themes = BO.Account2Theme.GetAll(new BO.Account2Theme.Filter()
                {
                    fk_account = student.pk
                });

                foreach (BO.Account2Theme.Result acc2Theme in acc2Themes)
                {
                    JObject accTheme = new JObject();
                    BO.Theme.Result theme = BO.Theme.Load(acc2Theme.fk_theme);
                    string mark = string.Format("{0}: {1}", theme.str_name, acc2Theme.dcm_mark);
                    accTheme["Text"] = mark;
                    jSubjects.Add(accTheme);
                }

                jStudent["Subjects"] = jSubjects;
                //jStudent["Mark"] = student.dcm_avg_rating;
                jStudent["ID"] = student.pk;

                jStudents.Add(jStudent);
            }

            mi.Result["Students"] = jStudents;
            mi.ErrorCode = 0;
        }
        [AuthMethod]
        public static void SetStudent(Method mi)
        {
            string name = mi.Args["Name"].Value<string>();
            string email = mi.Args["Email"].Value<string>();
            //decimal mark = mi.Args["Mark"].Value<decimal>();

            BO.Account.Set(new BO.Account.Filter()
            {
                str_name = name,
                str_email = email,
                //dcm_avg_rating = mark,
                str_password = "11111",
                int_accounttype = (int)BO.Account.Consts.AccountType.Student,
            });
        } 
    }
}