using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Models
{
    public class ArticleGroup
    {
        private ICollection<Article> articles;

        public ArticleGroup()
        {
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

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
