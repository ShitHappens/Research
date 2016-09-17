using DevReactor.Toolbox.Tools;
using Research.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using LTest = Research.Logic.Test;
using File = System.IO.File;

namespace Research.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            //string imgPath = @"C:\learning.jpg";
            //byte[] imgdata = System.IO.File.ReadAllBytes(imgPath);
            //DownloadImage(5, @"C:\TestImages\97.pdf");
            //UploadImage(97, @"C:\TestImages");
            //BO.Account.Result acc = BO.Account.Load(1);
            //Console.Write(acc.dcm_avg_rating);
            //Console.ReadLine();

            //#region test
            //LTest test = new LTest();
            //test.SimpleTestByTheme();
            //#endregion test

            BO.Account2Theme.Set(new BO.Account2Theme.Filter()
            {
                fk_account = 11,
                fk_theme = 11, 
                dcm_mark = 5
            });

            Console.ReadLine();

            Logger.Instance.LogInfo("Finished");
        }

        public static void DownloadImage(int themeId, string imagePath)
        {
            byte[] imgdata = System.IO.File.ReadAllBytes(imagePath);
            BO.Theme.Set(new BO.Theme.Filter()
            {
                pk = themeId,
                bin_image = imgdata
            });
        }

        public static void UploadImage(int themeId, string pathTo)
        {
            if (!Directory.Exists(pathTo))
                Directory.CreateDirectory(pathTo);

            BO.Theme.Result qty = BO.Theme.Load(themeId);
            byte[] img = BO.Theme.Result.GetImage(qty.pk.Value);
            if (img != null)
            {
                string fileName = string.Format("{0}.pdf", themeId);
                string finalPath = Path.Combine(pathTo, fileName);

                File.WriteAllBytes(finalPath, img);
            }
        }
    }
}
