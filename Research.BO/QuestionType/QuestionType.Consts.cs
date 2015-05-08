
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
        public class Consts : DevReactor.Toolbox.BO.Consts.BaseObject
        {

            public const string str_description = "str_description";


            public enum Type
            {
                OneFromTwo = 1,
                OneFromMany = 2,
                ManyFromMany  = 3,
                Number = 4,
                Interval = 5,
                FuzzySet = 6,
                Word = 7
            }

            public abstract class Sort
            {
            }
            public abstract class RetCode
            {
            }
        }
    }
}
