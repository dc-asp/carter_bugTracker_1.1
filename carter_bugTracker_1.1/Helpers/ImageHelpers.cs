using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace carter_bugTracker_1._1.Helpers
{
    public static class ImageHelpers
    {
        public static bool IsWebFriendlyImage(HttpPostedFileBase file)
        {
            if (file == null)
                return false;

            if(file.ContentLength > 2 * 1024 * 2024 || file.ContentLength < 1024)
                return false;

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(img.RawFormat) ||
                        ImageFormat.Png.Equals(img.RawFormat) ||
                        ImageFormat.Icon.Equals(img.RawFormat) ||
                        ImageFormat.Bmp.Equals(img.RawFormat) ||
                        ImageFormat.Gif.Equals(img.RawFormat) ||;
                };
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidAttachment(HttpPostedFileBase file)
        {
            try
            {
                //var valid = IsWebFriendlyImage(file);
                if (file == null)
                    return false;

                if (file.ContentLength > 5 * 1024 * 1024 || file.ContentLength < 1024)
                    return false;

                var extValid = false;
                foreach(var ext in WebConfigurationManager.AppSettings["AllowedAttachmentExtensions"].Split(','))
                {
                    if(Path.GetExtension(file.FileName) == ext)
                    {
                        extValid = true;
                        break;
                    }
                }
                //var validExtensions = new List<string>();
                //validExtensions.Add("pdf");
                //validExtensions.Add("doc");
                //validExtensions.Add("docx");
                //validExtensions.Add("xls");
                //validExtensions.Add("xlsx");
                //validExtensions.Add("txt");
                //validExtensions.Add("html");
                //validExtensions.Add("xml");
                //validExtensions.Add("json");
                return IsWebFriendlyImage(file) || extValid;
            }
            catch
            {
                return false;
            }
        }
        //public string GetIconPath(string filePath)
        //{
        //    switch(Path.GetExtension(filePath))
        //    {
        //        case ".png":
        //        case ".bmp":
        //        case ".tif":
        //        case ".ico":
        //        case ".jpg":
        //        case ".jpeg":
        //            return filePath;
        //        case ".pdf":
        //            return "/Images/pdf.png";
        //        case ".png":
        //            return "/Images/doc.png";
        //        case ".png":
        //            return "/Images/docx.png";
        //        case ".png":
        //            return "/Images/xls.png";
        //        case ".png":
        //            return "/Images/xlsx.png";
        //    }
        //}
    }
}