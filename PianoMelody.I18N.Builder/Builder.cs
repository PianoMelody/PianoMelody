namespace PianoMelody.I18N.Builder
{
    using System;

    using Concrete;
    using Utility;

    class Builder
    {
        static void Main()
        {
            var builder = new ResourceBuilder();
            var resourceProvider = new DbResourceProvider(@"Data Source=.;Initial Catalog=PianoMelody;Integrated Security=True;Pooling=False");
            string filePath = builder.Create(resourceProvider, summaryCulture: "en");
            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
