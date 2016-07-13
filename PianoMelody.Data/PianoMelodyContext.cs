namespace PianoMelody.Data
{
    using System.Data.Entity;

    using Contracts;
    using Migrations;
    using Models;

    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class PianoMelodyContext : IdentityDbContext<User>, IPianoMelodyContext
    {
        public PianoMelodyContext()
            : base("name=PianoMelodyContext")
        {
#if DEBUG
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PianoMelodyContext, Configuration>());
#endif
        }

        public IDbSet<ArticleGroup> ArticleGroups { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Information> Informations { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Multimedia> Multimedia { get; set; }

        public IDbSet<News> News { get; set; }

        public IDbSet<Reference> References { get; set; }

        public IDbSet<Resources> Resources { get; set; }

        public IDbSet<Service> Services { get; set; }

        public static PianoMelodyContext Create()
        {
            return new PianoMelodyContext();
        }
    }
}