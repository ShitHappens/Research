using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Theme : BaseObject<Theme>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return Theme.TypeInfo.Instance;
        }

        public new static Theme.Result Load(object pk)
        {
            return (Theme.Result)BaseObject<Theme>.Load(pk);
        }

        public static Theme.Result Get(Filter filter)
        {
            return (Theme.Result)BaseObject<Theme>.get(filter);
        }

        public static Theme.Result Set(Filter filter)
        {
            return (Theme.Result)BaseObject<Theme>.set(filter);
        }

        public static Theme.Result GetAll(Filter filter)
        {
            return (Theme.Result)BaseObject<Theme>.getAll(filter);
        }

    }
}
