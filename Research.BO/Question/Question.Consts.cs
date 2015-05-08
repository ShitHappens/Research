
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Question : BaseObject<Question>
    {
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string str_text = "str_text";

            public const string fk_type = "fk_type";

            public const string fk_theme = "fk_theme";

            public const string fk_subtheme = "fk_subtheme";

            public const string int_time = "int_time";

            public const string dcm_complexity = "dcm_complexity";


            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
