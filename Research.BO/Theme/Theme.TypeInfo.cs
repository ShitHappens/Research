using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Theme : BaseObject<Theme>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static Theme.TypeInfo Instance
            {
                get
                {
                    return Singleton<Theme.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new Theme.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new Theme.Filter(); }

            public override string Entity { get { return "Theme"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return Theme.get(filter); }
        }
    }
}
