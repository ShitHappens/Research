using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Account : BaseObject<Account>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return Account.TypeInfo.Instance;
        }

        public new static Account.Result Load(object pk)
        {
            return (Account.Result)BaseObject<Account>.Load(pk);
        }

        public static Account.Result Get(Filter filter)
        {
            return (Account.Result)BaseObject<Account>.get(filter);
        }

        public static Account.Result Set(Filter filter)
        {
            return (Account.Result)BaseObject<Account>.set(filter);
        }

        public static Account.Result GetAll(Filter filter)
        {
            return (Account.Result)BaseObject<Account>.getAll(filter);
        }
    }
}
