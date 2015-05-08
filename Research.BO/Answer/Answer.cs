using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Answer : BaseObject<Answer>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return Answer.TypeInfo.Instance;
        }

        public new static Answer.Result Load(object pk)
        {
            return (Answer.Result)BaseObject<Answer>.Load(pk);
        }

        public static Answer.Result Get(Filter filter)
        {
            return (Answer.Result)BaseObject<Answer>.get(filter);
        }

        public static Answer.Result Set(Filter filter)
        {
            return (Answer.Result)BaseObject<Answer>.set(filter);
        }

        public static Answer.Result GetAll(Filter filter)
        {
            return (Answer.Result)BaseObject<Answer>.getAll(filter);
        }

    }
}
