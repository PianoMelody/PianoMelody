namespace PianoMelody.Data.Contracts
{
    using System.Data.Entity;

    using Models;

    public interface IPianoMelodyContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Resources> Resources { get; set; }

        IDbSet<ArticleGroup> ArticleGroups { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<Service> Services { get; set; }

        IDbSet<News> News { get; set; }

        IDbSet<Information> Informations { get; set; }

        IDbSet<Reference> References { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Multimedia> Multimedia { get; set; }
    }
}