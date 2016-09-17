using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Account2Theme : BaseObject<Account2Theme>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return Account2Theme.TypeInfo.Instance;
        }

        public new static Account2Theme.Result Load(object pk)
        {
            return (Account2Theme.Result)BaseObject<Account2Theme>.Load(pk);
        }

        public static Account2Theme.Result Get(Filter filter)
        {
            return (Account2Theme.Result)BaseObject<Account2Theme>.get(filter);
        }

        public static Account2Theme.Result Set(Filter filter)
        {
            return (Account2Theme.Result)BaseObject<Account2Theme>.set(filter);
        }

        public static Account2Theme.Result GetAll(Filter filter)
        {
            return (Account2Theme.Result)BaseObject<Account2Theme>.getAll(filter);
        }
    }
}
