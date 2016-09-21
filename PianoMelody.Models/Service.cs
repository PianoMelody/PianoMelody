using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
