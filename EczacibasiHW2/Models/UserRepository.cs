using EczacibasiHW2.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EczacibasiHW2.Models
{
    public class UserRepository
    {
        private readonly CommerceContext _context;

        public UserRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void Update(int id, User user)
        {
            var p = _context.Users.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            p.Name = user.Name;
            p.UserType = user.UserType;
            p.Addresses = user.Addresses;
            p.Gender = user.Gender;

            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var p = _context.Users.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.Users.Remove(p);

            _context.SaveChanges();
        }

        public List<User> Search(string name, UserType userType,GenderType gender)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));
            
            if (userType != 0)
                query.Where(x => x.UserType==userType);
            
            if(gender != 0)
                query.Where((x) => x.Gender==gender);

            return query.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
