using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Account : BaseObject<Account>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static Account.TypeInfo Instance
            {
                get
                {
                    return Singleton<Account.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new Account.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new Account.Filter(); }

            public override string Entity { get { return "Account"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return Account.get(filter); }
        }

    }
}
