using PianoMelody.Models;
using PianoMelody.Models.Enumetations;
using System;
using System.IO;
using System.Web;

namespace PianoMelody.Web.Helpers
{
    public static class MultimediaHelper
    {
        public static Multimedia CreateSingle(HttpServerUtilityBase server, HttpPostedFileBase fileBase, string baseUrl)
        {
            string fileName = string.Empty;

            if (fileBase.ContentLength > 0)
            {
                fileName = Path.GetFileName(fileBase.FileName);
                var filePath = Path.Combine(server.MapPath("~/Multimedia"), fileName);
                fileBase.SaveAs(filePath);
            }

            var url = baseUrl + "Multimedia/" + fileName;

            var multimedia = new Multimedia()
            {
                Type = MultimediaType.SingleElement,
                Created = DateTime.Now,
                Url = url,
                Content = string.Empty
            };

            return multimedia;
        }
    }
}