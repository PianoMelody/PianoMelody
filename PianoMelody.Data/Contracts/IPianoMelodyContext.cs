namespace PianoMelody.Data.Contracts
{
    using System.Data.Entity;

    using PianoMelody.Models;

    public interface IPianoMelodyContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Resources> Resources { get; set; }
    }
}