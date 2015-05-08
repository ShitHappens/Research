
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Theme : BaseObject<Theme>
    {
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(Theme.Info) { }

            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public String str_name { get { return GetValue<String>(Consts.str_name); } }

            public Int32? fk_parent { get { return GetValueNullable<Int32>(Consts.fk_parent); } }

        }
    }
}

