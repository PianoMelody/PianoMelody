using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Article
    {
        private ICollection<Multimedia> multimedias;

        public Article()
        {
            this.multimedias = new HashSet<Multimedia>();
        }

        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsNew { get; set; }

        public virtual ArticleGroup ArtilceGroup { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Multimedia> Multimedias
        {
            get
            {
                return this.multimedias;
            }

            set
            {
                this.multimedias = value;
            }
        }
    }
}
