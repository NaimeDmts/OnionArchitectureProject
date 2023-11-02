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
    public class KonuRepository : BaseRepository<Konu>, IKonuRepository
    {
        private readonly AppDbContext _context;
        public KonuRepository(AppDbContext context) : base(context)
        {
            _context= context;
        }

        public Konu KonuGetById(int id)
        {
            return _context.Konus.FirstOrDefault(k => k.Status != Status.Passive && k.Id == id);
        }
    }
}
