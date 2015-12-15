
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Account : BaseObject<Account>
    {
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(Account.Info)
            {
            }
            #endregion

            #region Members

            public new int? pk
            {
                set { base.pk = value; }
                get { return (int)base.pk; }
            }


            public String str_email
            {
                set { this[Consts.str_email] = value; }
                get { return (String)this[Consts.str_email]; }
            }

            public String str_name
            {
                set { this[Consts.str_name] = value; }
                get { return (String)this[Consts.str_name]; }
            }

            public String str_password
            {
                set { this[Consts.str_password] = value; }
                get { return (String)this[Consts.str_password]; }
            }

            public decimal? dcm_avg_rating
            {
                set { this[Consts.dcm_avg_rating] = value; }
                get { return (decimal?)this[Consts.dcm_avg_rating]; }
            }

            public int int_accounttype
            {
                set { this[Consts.int_accounttype] = value; }
                get { return (int)this[Consts.int_accounttype]; }
            }

            public DateTime dt_created
            {
                set { this[Consts.dt_created] = value; }
                get { return (DateTime)this[Consts.dt_created]; }
            }


            public DateTime dt_updated
            {
                set { this[Consts.dt_updated] = value; }
                get { return (DateTime)this[Consts.dt_updated]; }
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

