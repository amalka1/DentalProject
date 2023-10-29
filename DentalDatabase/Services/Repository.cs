using Application.Database.IServices;
using DentalDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Database.Services
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<Tentity> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<Tentity>();
        }
        public IQueryable<Tentity> Table()
        {
            return _entities;
        }
        public IEnumerable<Tentity> GetAll()
        {
            return _entities.ToList();
        }

        public Tentity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Add(Tentity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Tentity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tentity existing = _entities.Find(id);
            if (existing != null)
            {
                _entities.Remove(existing);
                _context.SaveChanges();
            }
        }
    }
}
