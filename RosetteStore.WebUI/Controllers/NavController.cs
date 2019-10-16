using RosetteStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosetteStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IRosetteRepository repository;

        public NavController(IRosetteRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Rosettes
                .Select(rosette => rosette.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}