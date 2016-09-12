
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System.Data.SqlClient;

namespace Research.BO
{
    public partial class Question : BaseObject<Question>
    {
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(Question.Info) { }

            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public String str_text { get { return GetValue<String>(Consts.str_text); } }

            public Int32 fk_type { get { return GetValue<Int32>(Consts.fk_type); } }

            public Int32 fk_theme { get { return GetValue<Int32>(Consts.fk_theme); } }

            public Int32 fk_subtheme { get { return GetValue<Int32>(Consts.fk_subtheme); } }

            public Int32 int_time { get { return GetValue<Int32>(Consts.int_time); } }

            public decimal dcm_complexity { get { return GetValue<decimal>(Consts.dcm_complexity); } }

        }
    }
}

