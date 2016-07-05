namespace PianoMelody.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resources
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(8)]
        public string Culture { get; set; }

        public string Value { get; set; }

    }
}
