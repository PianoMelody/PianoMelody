namespace PianoMelody.I18N.Builder
{
    using System;
    using System.IO;

    using Concrete;
    using Utility;

    class Builder
    {
        static void Main()
        {
            var builder = new ResourceBuilder();
            var resourceProvider = new DbResourceProvider(@"Data Source=.;Initial Catalog=PianoMelody;Integrated Security=True;Pooling=False");
            string path = Directory.GetCurrentDirectory().Replace(".Builder\\bin\\Debug", "\\Resources.cs");
            string filePath = builder.Create(resourceProvider, filePath: path, summaryCulture: "en");
            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
