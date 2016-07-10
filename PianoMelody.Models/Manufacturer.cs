using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(64)]
        public string UrlAddress { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
