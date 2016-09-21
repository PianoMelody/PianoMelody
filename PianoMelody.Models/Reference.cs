using System;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public DateTime Created { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
