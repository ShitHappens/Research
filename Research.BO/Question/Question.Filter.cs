
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
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(Question.Info)
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


            public Int32 fk_type
            {
                set { this[Consts.fk_type] = value; }
                get { return (Int32)this[Consts.fk_type]; }
            }


            public Int32 fk_theme
            {
                set { this[Consts.fk_theme] = value; }
                get { return (Int32)this[Consts.fk_theme]; }
            }


            public Int32 fk_subtheme
            {
                set { this[Consts.fk_subtheme] = value; }
                get { return (Int32)this[Consts.fk_subtheme]; }
            }


            public Int32 int_time
            {
                set { this[Consts.int_time] = value; }
                get { return (Int32)this[Consts.int_time]; }
            }


            public decimal dcm_complexity
            {
                set { this[Consts.dcm_complexity] = value; }
                get { return (decimal)this[Consts.dcm_complexity]; }
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

