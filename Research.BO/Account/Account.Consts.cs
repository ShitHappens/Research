
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Account : BaseObject<Account>
    {
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string str_email = "str_email";

            public const string str_name = "str_name";

            public const string str_password = "str_password";

            public const string dcm_avg_rating = "dcm_avg_rating";

            public const string int_accounttype = "int_accounttype";

            public const string dt_created = "dt_created";

            public const string dt_updated = "dt_updated";

            public enum AccountType
            {
                Admin = 0,
                Student = 1,
            }
            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
