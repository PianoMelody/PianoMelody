namespace PianoMelody.I18N.Abstract
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);                
    }
}
