using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ArticleGroup ArtilceGroup { get; set; }

        public virtual Multimedia Multimedia { get; set; }
    }
}
