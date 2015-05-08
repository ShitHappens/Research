using DevReactor.Toolbox.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Research.BO
{
    public partial class QuestionType : BaseObject<QuestionType>
    {
        public override DevReactor.Toolbox.BO.TypeInfo GetInfo()
        {
            return QuestionType.TypeInfo.Instance;
        }

        public new static QuestionType.Result Load(object pk)
        {
            return (QuestionType.Result)BaseObject<QuestionType>.Load(pk);
        }

        public static QuestionType.Result Get(Filter filter)
        {
            return (QuestionType.Result)BaseObject<QuestionType>.get(filter);
        }

        public static QuestionType.Result Set(Filter filter)
        {
            return (QuestionType.Result)BaseObject<QuestionType>.set(filter);
        }

        public static QuestionType.Result GetAll(Filter filter)
        {
            return (QuestionType.Result)BaseObject<QuestionType>.getAll(filter);
        }

    }
}
