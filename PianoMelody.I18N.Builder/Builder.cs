namespace PianoMelody.I18N.Builder
{
    using System;
    using System.IO;
    using System.Drawing;
    using Utility;
    using Concrete;
    using System.Linq;

    class Builder
    {
        static void Main()
        {
            var builder = new ResourceBuilder();
            var resourceProvider = new DbResourceProvider(@"Data Source=.;Initial Catalog=PianoMelody;Integrated Security=True;Pooling=False");
            string path = Directory.GetCurrentDirectory().Replace(".Builder\\bin\\Debug", "\\Resources.cs");
            string filePath = builder.Create(resourceProvider, filePath: path, summaryCulture: "en");
            Console.WriteLine("Resource file {0} created.", filePath);
            //UpdateThumbnails();
        }

        /// <summary>
        /// Update all thumbnails for all images from Multimedia folder
        /// </summary>
        static void UpdateThumbnails()
        {
            var path = Directory.GetCurrentDirectory().Replace("I18N.Builder\\bin\\Debug", "Web\\Multimedia\\");
            DirectoryInfo dir = new DirectoryInfo(path);

            int newWidth = 300;

            foreach (var file in dir.GetFiles().Where(f => !f.ToString().EndsWith(".txt")))
            {
                var filePath = path + file;

                Image imgPhoto = Image.FromFile(filePath);

                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                int calcHeight = sourceHeight * newWidth / sourceWidth;

                imgPhoto = imgPhoto.GetThumbnailImage(newWidth, calcHeight, () => false, IntPtr.Zero);

                imgPhoto.Save(path + "thumbs\\" + file);
                imgPhoto.Dispose();
            }

            Console.WriteLine("Thumbnails has been updated.");
        }
    }
}
