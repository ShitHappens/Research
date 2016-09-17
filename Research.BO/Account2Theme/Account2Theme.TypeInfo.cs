using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Account2Theme : BaseObject<Account2Theme>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static Account2Theme.TypeInfo Instance
            {
                get
                {
                    return Singleton<Account2Theme.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new Account2Theme.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new Account2Theme.Filter(); }

            public override string Entity { get { return "Account2Theme"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return Account2Theme.get(filter); }
        }

    }
}
