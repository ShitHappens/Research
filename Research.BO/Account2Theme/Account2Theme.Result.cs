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
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(Account2Theme.Info) { }

            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public int fk_account { get { return GetValue<int>(Consts.fk_account); } }
            public int fk_theme { get { return GetValue<int>(Consts.fk_theme); } }
            public decimal dcm_mark { get { return GetValue<decimal>(Consts.dcm_mark); } }
            public DateTime dt_created { get { return GetValue<DateTime>(Consts.dt_created); } }

            public DateTime dt_updated { get { return GetValue<DateTime>(Consts.dt_updated); } }

        }
    }
}

