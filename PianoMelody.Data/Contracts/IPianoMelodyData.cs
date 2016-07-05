namespace PianoMelody.Data.Contracts
{
    using Models;

    public interface IPianoMelodyData
    {
        IRepository<User> Users { get; }

        IRepository<Resources> Resources { get; }

        int SaveChanges();
    }
}