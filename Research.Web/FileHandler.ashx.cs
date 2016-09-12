using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Research.Web
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.Form[0]);
                var image = context.Request.Files[0];
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(context.Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                }

                if (fileData != null)
                    BO.Theme.Set(new BO.Theme.Filter() {
                        bin_image = fileData,
                        pk = id
                    });

            }
            catch(Exception ex)
            {

            }

            context.Response.ContentType = "text/plain";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}