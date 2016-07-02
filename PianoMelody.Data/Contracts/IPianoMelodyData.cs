namespace PianoMelody.Data.Contracts
{
    using PianoMelody.Models;

    public interface IPianoMelodyData
    {
        IRepository<User> Users { get; }

        IRepository<Resources> Resources { get; }

        int SaveChanges();
    }
}