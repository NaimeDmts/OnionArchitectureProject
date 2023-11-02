using KatmanliSinavProject.Core.Entities.Abstraction;
using KatmanliSinavProject.Core.Enums;
using KatmanliSinavProject.Core.Repositories;
using KatmanliSinavProject.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected DbSet<T> _table;

        public BaseRepository(AppDbContext context)
        {
            this._context = context;
            _table = _context.Set<T>();


        }

        public bool Add(T entity)
        {
            if(entity is not null)
            {
                _table.Add(entity);
                bool kontrol = _context.SaveChanges() > 0;
                if(kontrol)
                {
                    return true;
                }
                else
                {
                    throw new Exception("HATA! Ekleme İşlemi veri tabanına Kaydedilmemiştir.");
                }
            }
            else
            {
                throw new Exception("HATA! Ekleme işlemi için boş data gönderildi");
            }
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
           return _table.Any(expression);
        }

        public bool Delete(T entity)
        {
            bool kontrol = _context.SaveChanges() > 0;
            if (kontrol)
            {
                return true;
            }
            else
            {
                throw new Exception("Silme işlemi Gerçekleşmedi");
            }

        }

        public IList<T> GetAllDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public bool Update(T entity)
        {
           if(entity is not null )
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
                bool kontrol = _context.SaveChanges() > 0;
                if (kontrol)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Herhangi veri güncellemesi olmamıştır");
                }
            }
            else
            {
                throw new Exception("HATA! Boş veri gönderimi");
            }

        }
        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();

        }


        public IList<T> GetNotPassives()
        {
            return _context.Set<T>().Where(e => e.Status != Status.Passive).ToList();
        }



    }
}
