using RosetteStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosetteStore.WebUI.Models
{
    public class RosettesListViewModel
    {
        public IEnumerable<Rosette> Rosettes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}