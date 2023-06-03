using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EczacibasiHW2.Models.Entity
{
    [Table("Products")]
    public class Product : BaseEntity<int>
    {


        [MaxLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    
    }
}
