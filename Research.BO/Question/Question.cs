using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class Question : BaseObject<Question>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return Question.TypeInfo.Instance;
        }

        public new static Question.Result Load(object pk)
        {
            return (Question.Result)BaseObject<Question>.Load(pk);
        }

        public static Question.Result Get(Filter filter)
        {
            return (Question.Result)BaseObject<Question>.get(filter);
        }

        public static Question.Result Set(Filter filter)
        {
            return (Question.Result)BaseObject<Question>.set(filter);
        }

        public static Question.Result GetAll(Filter filter)
        {
            return (Question.Result)BaseObject<Question>.getAll(filter);
        }

    }
}
