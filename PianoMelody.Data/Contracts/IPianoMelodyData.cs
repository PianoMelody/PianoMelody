namespace PianoMelody.Data.Contracts
{
    using Models;

    public interface IPianoMelodyData
    {
        IRepository<User> Users { get; }

        IRepository<Resources> Resources { get; }

        IRepository<ArticleGroup> ArticleGroups { get; }

        IRepository<Product> Products { get; }

        IRepository<Service> Services { get; }

        IRepository<News> News { get; }

        IRepository<Information> Informations { get; }

        IRepository<Reference> References { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Multimedia> Multimedia { get; }

        int SaveChanges();
    }
}