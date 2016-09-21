using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Manufacturer
    {
        private ICollection<Product> products;

        public Manufacturer()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public bool AreWeAgent { get; set; }

        public string UrlAddress { get; set; }

        public virtual Multimedia Multimedia { get; set; }

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
