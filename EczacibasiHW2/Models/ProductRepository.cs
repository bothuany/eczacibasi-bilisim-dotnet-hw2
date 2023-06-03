using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EczacibasiHW2.Models.Entity;

namespace EczacibasiHW2.Models
{
    public class ProductRepository
    {
        private readonly CommerceContext _context;

        public ProductRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            var p = _context.Products.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            p.Price = product.Price;
            p.CategoryId = product.CategoryId;
            p.Name = product.Name;
            

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Products.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.Products.Remove(p);

            _context.SaveChanges();
        }

        public List<Product> Search(string name, int? categoryId, double? minPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (categoryId.HasValue)
                query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query.Where(x => x.Price > minPrice);

            return query.ToList();
        }

        public Product GetById(int id, bool withCategory = false)
        {
           var query = _context.Products.AsQueryable();

            if (withCategory)
                query.Include(x => x.Category);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll(int page,int pageSize)
        {
            return _context.Products.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}
