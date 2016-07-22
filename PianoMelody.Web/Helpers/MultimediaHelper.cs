using PianoMelody.Models;
using PianoMelody.Models.Enumetations;
using System;
using System.Collections.Generic;
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
                var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
                fileBase.SaveAs(filePath);
                var url = baseUrl + "Multimedia/" + fileName;

                var multimedia = new Multimedia()
                {
                    Type = type,
                    Created = DateTime.Now,
                    Url = url,
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
                    var url = baseUrl + "Multimedia/" + fileName;

                    var multimedia = new Multimedia()
                    {
                        Type = type,
                        Created = DateTime.Now,
                        Url = url,
                        Content = content
                    };

                    result.Add(multimedia);
                }
            }

            return result.Count > 0 ? result : null;
        }

        internal static void DeleteMultiple(HttpServerUtilityBase server, ICollection<Multimedia> multimedias)
        {
            foreach (var multimedia in multimedias)
            {
                var fileName = multimedia.Url.Split('/').Last();
                var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
                File.Delete(filePath);
            }
        }
    }
}