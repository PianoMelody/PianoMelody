using System;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
