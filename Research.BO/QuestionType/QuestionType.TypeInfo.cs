using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class QuestionType : BaseObject<QuestionType>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static QuestionType.TypeInfo Instance
            {
                get
                {
                    return Singleton<QuestionType.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new QuestionType.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new QuestionType.Filter(); }

            public override string Entity { get { return "question_type"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return QuestionType.get(filter); }
        }
    }
}
