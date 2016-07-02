namespace PianoMelody.Data
{
    using System.Data.Entity;

    using PianoMelody.Data.Contracts;
    using PianoMelody.Data.Migrations;
    using PianoMelody.Models;

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

        public IDbSet<Resources> Resources { get; set; }

        public static PianoMelodyContext Create()
        {
            return new PianoMelodyContext();
        }
    }
}