using DevReactor.Toolbox.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTest = Research.Logic.Test; 

namespace Research.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            #region test
            LTest test = new LTest();
            test.SimpleTestByTheme();
            #endregion test

            Console.ReadLine();

            Logger.Instance.LogInfo("Finished");
        }
    }
}
