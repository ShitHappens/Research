
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
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string str_text = "str_text";

            public const string fk_question = "fk_question";

            public const string dcm_mark = "dcm_mark";


            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
