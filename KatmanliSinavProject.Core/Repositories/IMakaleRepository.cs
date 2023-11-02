using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.Core.Repositories
{
    public interface IMakaleRepository :IBaseRepository<Makale>
    {
        Makale MakaleGetById(int id);
        public IList<Makale> GetUserMakales(string UserId);
        public IList<Makale> GetKonuMakales(int konuId);
        public IList<Makale> GetRastgeleMakale();
    }
}
