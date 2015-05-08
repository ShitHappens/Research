
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Answer : BaseObject<Answer>
    {
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(Answer.Info) { }

            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public String str_text { get { return GetValue<String>(Consts.str_text); } }

            public Int32 fk_question { get { return GetValue<Int32>(Consts.fk_question); } }

            public decimal dcm_mark { get { return GetValue<decimal>(Consts.dcm_mark); } }

        }
    }
}

