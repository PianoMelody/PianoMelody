using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class Manufacturer
    {
        private ICollection<Article> articles;

        public Manufacturer()
        {
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string UrlAddress { get; set; }

        public virtual Multimedia Multimedia { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }

            set
            {
                this.articles = value;
            }
        }
    }
}
