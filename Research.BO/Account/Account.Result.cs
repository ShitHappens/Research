
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
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(Account.Info) { }

            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public String str_email { get { return GetValue<String>(Consts.str_email); } }

            public String str_password { get { return GetValue<String>(Consts.str_password); } }

            public decimal? dcm_avg_rating { get { return GetValueNullable<decimal>(Consts.dcm_avg_rating); } }

            public int int_accounttype { get { return GetValue<int>(Consts.int_accounttype); } }

            public DateTime dt_created { get { return GetValue<DateTime>(Consts.dt_created); } }

            public DateTime dt_updated { get { return GetValue<DateTime>(Consts.dt_updated); } }

        }
    }
}

