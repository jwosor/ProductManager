using Microsoft.EntityFrameworkCore;
using ProductManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManager.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        DbSet<T> _items;

        ApiDbContext _ctx;
        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }


        public void Delete(int id)
        {
            var tmp = _items.Find(id);
            if (tmp != null)
            {
                _items.Remove(tmp);
                _ctx.SaveChanges();
            }

        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Where(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            if (entity.Id.Equals(0))
            {
                _items.Add(entity);
            }
            else
            {
                _items.Update(entity);
            }

            _ctx.SaveChanges();
            return entity;
        }
    }
}
