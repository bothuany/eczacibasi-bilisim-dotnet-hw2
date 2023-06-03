using EczacibasiHW2.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EczacibasiHW2.Models
{
    public class CategoryRepository
    {
        private readonly CommerceContext _context;

        public CategoryRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);

            _context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var p = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            p.Name = category.Name;
            p.IsActive = category.IsActive;
            

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.Categories.Remove(p);

            _context.SaveChanges();
        }

        public List<Category> Search(string name, bool? isActive)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (isActive.HasValue)
                query.Where(x => x.IsActive == isActive);

            return query.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
