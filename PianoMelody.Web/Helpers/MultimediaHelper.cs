﻿using PianoMelody.Models;
using PianoMelody.Models.Enumetations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PianoMelody.Web.Helpers
{
    public static class MultimediaHelper
    {
        private static int thumbWidth = int.Parse(ConfigurationManager.AppSettings["thumbWidth"]);

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

                CreateThumbnail(server, filePath, thumbWidth);

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

                    CreateThumbnail(server, filePath, thumbWidth);

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

        private static void CreateThumbnail(HttpServerUtilityBase server, string filePath, int width)
        {
            using (Image imgPhoto = Image.FromFile(filePath))
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                imgPhoto.RotateFlip(RotateFlipType.Rotate180FlipX);
                imgPhoto.RotateFlip(RotateFlipType.Rotate180FlipX);

                float ratio = 0;
                ratio = (float)sourceWidth / sourceHeight;
                int calcHeight = (int)(width / ratio);              

                using (Image thumbnail = imgPhoto.GetThumbnailImage(width, calcHeight, () => false, IntPtr.Zero))
                {
                    string fileName = filePath.Split('\\').Last();
                    string path = Path.Combine(server.MapPath("~/Multimedia/thumbs"), fileName);
                    thumbnail.Save(path);
                }
            }
        }
    }
}