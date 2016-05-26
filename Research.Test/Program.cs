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

            UploadImage(96, @"C:\TestImages");
            //BO.Account.Result acc = BO.Account.Load(1);
            //Console.Write(acc.dcm_avg_rating);
            //Console.ReadLine();

            //#region test
            //LTest test = new LTest();
            //test.SimpleTestByTheme();
            //#endregion test

            Console.ReadLine();

            Logger.Instance.LogInfo("Finished");
        }

        public static void DownloadImage(int questionId, string imagePath)
        {
            byte[] imgdata = System.IO.File.ReadAllBytes(imagePath);
            BO.Question.Set(new BO.Question.Filter()
            {
                pk = questionId,
                bin_image = imgdata
            });
        }

        public static void UploadImage(int questionId, string pathTo)
        {
            if (!Directory.Exists(pathTo))
                Directory.CreateDirectory(pathTo);

            BO.Question.Result qty = BO.Question.Load(questionId);
            byte[] img = BO.Question.Result.GetImage(qty.pk.Value);
            if (img != null)
            {
                string fileName = string.Format("{0}.jpg", questionId);
                string finalPath = Path.Combine(pathTo, fileName);

                File.WriteAllBytes(finalPath, img);
            }
        }
    }
}
