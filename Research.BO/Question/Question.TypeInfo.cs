using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Question : BaseObject<Question>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static Question.TypeInfo Instance
            {
                get
                {
                    return Singleton<Question.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new Question.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new Question.Filter(); }

            public override string Entity { get { return "Question"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return Question.get(filter); }
        }
    }
}
