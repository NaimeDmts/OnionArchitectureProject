using KatmanliSinavProject.Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.Core.Repositories
{
    public interface IKonuRepository : IBaseRepository<Konu>
    {
        Konu KonuGetById(int id);
    }
}
