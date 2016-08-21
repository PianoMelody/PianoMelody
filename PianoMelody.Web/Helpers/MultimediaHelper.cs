using PianoMelody.Models;
using PianoMelody.Models.Enumetations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace PianoMelody.Web.Helpers
{
    public static class MultimediaHelper
    {
        public static Multimedia CreateSingle
        (
            HttpServerUtilityBase server, 
            HttpPostedFileBase fileBase, 
            string baseUrl, 
            MultimediaType type = MultimediaType.SingleElement, 
            string content = ""
        )
        {
            string fileName = string.Empty;

            if (fileBase != null && fileBase.ContentLength > 0)
            {
                var realName = Path.GetFileName(fileBase.FileName);
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(realName);
                var path = "~/Multimedia";
                var filePath = Path.Combine(server.MapPath(path), fileName);
                fileBase.SaveAs(filePath);

                CreateThumbnail(server, filePath, 200, 150);

                var url = baseUrl + "Multimedia/" + fileName;

                var multimedia = new Multimedia()
                {
                    Type = type,
                    Created = DateTime.Now,
                    Url = url,
                    DataSize = GetDataSize(filePath),
                    Content = content
                };

                return multimedia;
            }

            return null;
        }

        public static void DeleteSingle(HttpServerUtilityBase server, Multimedia multimedia)
        {
            var fileName = multimedia.Url.Split('/').Last();
            var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
            File.Delete(filePath);
            var thumbPath = Path.Combine(server.MapPath("~/Multimedia/thumbs"), fileName);
            File.Delete(thumbPath);
        }

        public static ICollection<Multimedia> CreateMultiple
        (
            HttpServerUtilityBase server,
            IEnumerable<HttpPostedFileBase> fileBases,
            string baseUrl,
            MultimediaType type = MultimediaType.SingleElement,
            string content = ""
        )
        {
            var result = new List<Multimedia>();

            foreach (var fileBase in fileBases)
            {
                string fileName = string.Empty;

                if (fileBase != null && fileBase.ContentLength > 0)
                {
                    var realName = Path.GetFileName(fileBase.FileName);
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(realName);
                    var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
                    fileBase.SaveAs(filePath);

                    CreateThumbnail(server, filePath, 200, 150);

                    var url = baseUrl + "Multimedia/" + fileName;

                    var multimedia = new Multimedia()
                    {
                        Type = type,
                        Created = DateTime.Now,
                        Url = url,
                        DataSize = GetDataSize(filePath),
                        Content = content
                    };

                    result.Add(multimedia);
                }
            }

            return result.Count > 0 ? result : null;
        }

        public static void DeleteMultiple(HttpServerUtilityBase server, ICollection<Multimedia> multimedias)
        {
            foreach (var multimedia in multimedias)
            {
                var fileName = multimedia.Url.Split('/').Last();
                var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
                File.Delete(filePath);
                var thumbPath = Path.Combine(server.MapPath("~/Multimedia/thumbs"), fileName);
                File.Delete(thumbPath);
            }
        }

        private static string GetDataSize(string filePath)
        {
            string dataSize = string.Empty;

            using (Image imgPhoto = Image.FromFile(filePath))
            {
                dataSize = string.Format("{0}x{1}", imgPhoto.Width, imgPhoto.Height);
            }

            return dataSize;
        }

        private static void CreateThumbnail(HttpServerUtilityBase server, string filePath, int width, int height)
        {
            using (Image imgPhoto = Image.FromFile(filePath))
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = (width / (float)sourceWidth);
                nPercentH = (height / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = Convert.ToInt16((width -
                                  (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = Convert.ToInt16((height -
                                  (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(width, height,
                                  PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                 imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.White);
                grPhoto.InterpolationMode =
                        InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();

                var fileName = filePath.Split('\\').Last();
                var path = Path.Combine(server.MapPath("~/Multimedia/thumbs"), fileName);
                bmPhoto.Save(path);
                bmPhoto.Dispose();
            }
        }
    }
}