using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosetteStore.Domain.Concrete
{
    public class EFRosetteRepository : IRosetteRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Rosette> Rosettes 
        { 
            get { return context.Rosettes; }
        }
    }
}
