using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevReactor.Toolbox.BO;
using DevReactor.Toolbox.Tools;

namespace Research.BO
{
    public partial class Account2Theme : BaseObject<Account2Theme>
    {
        public class Filter : DevReactor.Toolbox.BO.Filter
        {
            #region ctor
            public Filter()
                : base(Account2Theme.Info)
            {
            }
            #endregion

            #region Members

            public new int? pk
            {
                set { base.pk = value; }
                get { return (int)base.pk; }
            }


            public int? fk_account
            {
                set { this[Consts.fk_account] = value; }
                get { return (int?)this[Consts.fk_account]; }
            }

            public int? fk_theme
            {
                set { this[Consts.fk_theme] = value; }
                get { return (int?)this[Consts.fk_theme]; }
            }

            public decimal dcm_mark
            {
                set { this[Consts.dcm_mark] = value; }
                get { return (decimal)this[Consts.dcm_mark]; }
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
        }
    }
}

