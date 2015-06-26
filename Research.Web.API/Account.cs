using DevReactor.Toolbox.API.Attributes;
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
                            int_accounttype = (int)BO.Account.Consts.Type.User
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

    }
}