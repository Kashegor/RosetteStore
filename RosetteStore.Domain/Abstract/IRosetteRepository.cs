using RosetteStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosetteStore.Domain.Abstract
{
    public interface IRosetteRepository
    {
        IEnumerable<Rosette> Rosettes { get; }
    }
}
