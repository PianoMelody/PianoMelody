using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class ArticleGroup
    {
        private ICollection<Product> products;

        public ArticleGroup()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
