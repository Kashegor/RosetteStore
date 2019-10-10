using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Concrete;
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

        public RosetteController(IRosetteRepository repository)
        {
            this.repository = repository;
        }

        EFDbContext db = new EFDbContext();

        // GET: Rosette
        public ViewResult List()
        {
            //return View(repository.Rosettes);
            return View(db.Rosettes);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}