using EczacibasiHW2.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EczacibasiHW2.Models
{
    public class OrderRepository
    {
        private readonly CommerceContext _context;

        public OrderRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);

            _context.SaveChanges();
        }

        public void Update(int id, Order order)
        {
            var p = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            p.UserId = order.UserId;
            p.Items = order.Items;
            p.AddressId = order.AddressId;
            p.Note = order.Note;
           
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.Orders.Remove(p);

            _context.SaveChanges();
        }

        public List<Order> Search(int? userId, int? addressId)
        {
            var query = _context.Orders.AsQueryable();

            if (userId.HasValue)
                query.Where(x => x.UserId == userId);

            if (addressId.HasValue)
                query.Where(x => x.AddressId == addressId);

            return query.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }
    }

    public class OrderItemRepository
    {
        private readonly CommerceContext _context;

        public OrderItemRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);

            _context.SaveChanges();
        }

        public void Update(int id, OrderItem orderItem)
        {
            var p = _context.OrderItems.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            p.ProductId = orderItem.ProductId;
            p.Quantity = orderItem.Quantity;
            p.Price = orderItem.Price;
           
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.OrderItems.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.OrderItems.Remove(p);

            _context.SaveChanges();
        }

        public List<OrderItem> Search(int? productId)
        {
            var query = _context.OrderItems.AsQueryable();

            if (productId.HasValue)
                query.Where(x => x.ProductId == productId);

            return query.ToList();
        }

        public OrderItem GetById(int id)
        {
            return _context.OrderItems.FirstOrDefault(x => x.Id == id);
        }
    }
}
