namespace PianoMelody.Data.Contracts
{
    using PianoMelody.Models;

    public interface IPianoMelodyData
    {
        IRepository<User> Users { get; }

        void SaveChanges();
    }
}