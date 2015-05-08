using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Answer : BaseObject<Answer>
    {
        public class TypeInfo : DevReactor.Toolbox.BO.TypeInfo
        {

            public static Answer.TypeInfo Instance
            {
                get
                {
                    return Singleton<Answer.TypeInfo>.Instance;
                }
            }

            public override DevReactor.Toolbox.BO.Result CreateResult() { return new Answer.Result(); }
            public override DevReactor.Toolbox.BO.Filter CreateFilter() { return new Answer.Filter(); }

            public override string Entity { get { return "Answer"; } }
            public override string DbId { get { return DevReactor.Toolbox.BO.Consts.DbId.Default; } }
            public override DevReactor.Toolbox.BO.Result Get(DevReactor.Toolbox.BO.Filter filter) { return Answer.get(filter); }
        }
    }
}
