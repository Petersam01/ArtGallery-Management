using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ArtGallary.Controllers
{
    public class Util
    {
        public static string ByteArrayToImage(byte[] bta)
        {
            using (MemoryStream memoryStream = new MemoryStream(bta))
            {

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                string imgSrc = string.Format("data:image/jpg;base64,{0}", base64String);
                return imgSrc;


                //can also work for png
                // string imgSrc = string.Format("data:image/png;base64,{0}", base64String);
            }

        }
        public static string ByteArrayToPdf(byte[] bta)
        {
            using (MemoryStream memoryStream = new MemoryStream(bta))
            {

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                string pdfSrc = string.Format("data:document/pdf;base64,{0}", base64String);
                return pdfSrc;


                //can also work for png
                // string imgSrc = string.Format("data:image/png;base64,{0}", base64String);
            }

        }
    }
}