using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
