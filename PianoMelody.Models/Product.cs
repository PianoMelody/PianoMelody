using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Product
    {
        private ICollection<Multimedia> multimedias;

        public Product()
        {
            this.multimedias = new HashSet<Multimedia>();
        }

        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromoPrice { get; set; }

        public bool IsNew { get; set; }

        public int? ArticleGroupId { get; set; }

        public virtual ArticleGroup ArtilceGroup { get; set; }

        public int? ManufacturerId { get; set; }

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
