using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EczacibasiHW2.Models.Entity
{
    [Table("Orders")]
    public class Order : BaseEntity<int>
    {

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<OrderItem> Items { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [NotMapped]
        public double? Total => Items?.Sum(x => x.Quantity * x.Price);
    }

    [Table("OrderItems")]
    public class OrderItem  : BaseEntity<int>
    {

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; } 

    }
}
