using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.Core.Enums;
using KatmanliSinavProject.Core.Repositories;
using KatmanliSinavProject.DAL.Contexts;
using KatmanliSinavProject.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.DAL.Repositories
{
    public class MakaleRepository : BaseRepository<Makale>, IMakaleRepository
    {
        private readonly AppDbContext _context;

        public MakaleRepository(AppDbContext context) : base(context)
        {
            _context=context;
        }

        public IList<Makale> GetUserMakales(string UserId)
        {
            return _context.Makales.Where(m => m.Status != Status.Passive && m.AppUserId == UserId).ToList();
        }
        public IList<Makale> GetKonuMakales(int konuId)
        {
            return _context.Makales.Where(m => m.Status != Status.Passive && m.KonuId == konuId).ToList();
        }
        public Makale MakaleGetById(int id)
        {
            return _context.Makales.FirstOrDefault(m => m.Status != Status.Passive && m.Id == id);
        }

        public IList<Makale> GetRastgeleMakale()
        {
            return _context.Makales.Where(x => x.Status != Status.Passive).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
        }
    }
}
