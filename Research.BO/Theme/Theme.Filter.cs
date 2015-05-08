
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
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(Theme.Info)
            {
            }
            #endregion

            #region Members

            public new int? pk
            {
                set { base.pk = value; }
                get { return (int)base.pk; }
            }


            public String str_name
            {
                set { this[Consts.str_name] = value; }
                get { return (String)this[Consts.str_name]; }
            }


            public Int32 fk_parent
            {
                set { this[Consts.fk_parent] = value; }
                get { return (Int32)this[Consts.fk_parent]; }
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

