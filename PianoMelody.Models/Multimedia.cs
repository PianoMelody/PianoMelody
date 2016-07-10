using PianoMelody.Models.Enumetations;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Multimedia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Path { get; set; }

        public MultimediaType Type { get; set; }
    }
}
