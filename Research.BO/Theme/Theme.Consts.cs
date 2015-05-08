
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Theme : BaseObject<Theme>
    {
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string str_name = "str_name";

            public const string fk_parent = "fk_parent";


            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
