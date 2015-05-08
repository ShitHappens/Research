
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
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(Answer.Info)
            {
            }
            #endregion

            #region Members

            public new int? pk
            {
                set { base.pk = value; }
                get { return (int)base.pk; }
            }


            public String str_text
            {
                set { this[Consts.str_text] = value; }
                get { return (String)this[Consts.str_text]; }
            }


            public Int32? fk_question
            {
                set { this[Consts.fk_question] = value; }
                get { return (Int32)this[Consts.fk_question]; }
            }


            public decimal dcm_mark
            {
                set { this[Consts.dcm_mark] = value; }
                get { return (decimal)this[Consts.dcm_mark]; }
            }


            #endregion

            #region CacheTime
            //public override TimeSpan? CacheTime 
            //{ 
            //    get 
            //    {
            //        TimeSpan? ret = null;

            //        try
            //        {
            //            //if (this[Consts.pk] != null)
            //            //    ret = cCacheTimeGetStandard;
            //        }
            //        catch (Exception ex)
            //        {
            //            string err = ex.ToString();
            //        }

            //        return ret;
            //    } 
            //}
            #endregion
        }
    }
}

