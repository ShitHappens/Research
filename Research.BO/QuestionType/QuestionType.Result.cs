
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class QuestionType : BaseObject<QuestionType>
    {
        public class Result : DevReactor.Toolbox.BO.Result
        {
            public Result() : base(QuestionType.Info) { }
            public int? pk { get { return GetValue<int>(Consts.pk); } }

            public String str_description { get { return GetValue<String>(Consts.str_description); } }

        }
    }
}

