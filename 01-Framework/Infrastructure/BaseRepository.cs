using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _01_Framework.Infrastructure
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : DomainBase<Tkey>
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }
        public T Get(Tkey id)
        {
            return _context.Find<T>(id);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}
