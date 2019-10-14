using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Concrete;
using RosetteStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosetteStore.WebUI.Controllers
{
    public class RosetteController : Controller
    {
        private IRosetteRepository repository;
        public int pageSize = 4;

        public RosetteController(IRosetteRepository repository)
        {
            this.repository = repository;
        }

        EFDbContext db = new EFDbContext();

        // GET: Rosette
        public ViewResult List(int page = 1)
        {
            RosettesListViewModel model = new RosettesListViewModel
            {
                Rosettes = repository.Rosettes
                    .OrderBy(rozette => rozette.RosetteId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Rosettes.Count()
                }
            };
            return View(model);
    }
}
}