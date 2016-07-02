using Resources.Concrete;
using Resources.Utility;
using System;

namespace PianoMelody.I18N.Builder
{
    class Builder
    {
        static void Main()
        {
            var builder = new ResourceBuilder();
            var resourceProvider = new DbResourceProvider(@"Data Source=.;Initial Catalog=PianoMelody;Integrated Security=True;Pooling=False");
            string filePath = builder.Create(resourceProvider, summaryCulture: "en-us");
            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
