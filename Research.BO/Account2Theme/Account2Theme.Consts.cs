using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Account2Theme : BaseObject<Account2Theme>
    {
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string fk_account = "fk_account";

            public const string fk_theme = "fk_theme";

            public const string dcm_mark = "dcm_mark";

            public const string dt_created = "dt_created";

            public const string dt_updated = "dt_updated";

            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
