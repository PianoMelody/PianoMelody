using PianoMelody.Models.Enumetations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Multimedia
    {
        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public DateTime Created { get; set; }

        public string Url { get; set; }

        public string DataSize { get; set; }

        public string Content { get; set; }

        public MultimediaType Type { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
