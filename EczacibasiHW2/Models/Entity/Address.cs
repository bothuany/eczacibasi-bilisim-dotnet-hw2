using System.ComponentModel.DataAnnotations.Schema;

namespace EczacibasiHW2.Models.Entity
{
    public class Address : BaseEntity<int>
    {

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string City { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

    }
}
