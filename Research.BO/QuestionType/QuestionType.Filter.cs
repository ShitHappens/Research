
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
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(QuestionType.Info)
            {
            }
            #endregion

            #region Members

            public new int? pk
            {
                set { base.pk = value; }
                get { return (int)base.pk; }
            }


            public String str_description
            {
                set { this[Consts.str_description] = value; }
                get { return (String)this[Consts.str_description]; }
            }


            #endregion
        }
    }
}

