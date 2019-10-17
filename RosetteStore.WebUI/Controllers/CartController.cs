using RosetteStore.Domain.Abstract;
using RosetteStore.Domain.Entities;
using RosetteStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosetteStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IRosetteRepository repository;
        public CartController(IRosetteRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int rosetteId, string returnUrl)
        {
            Rosette rosette = repository.Rosettes
                .FirstOrDefault(g => g.RosetteId == rosetteId);

            if (rosette != null)
            {
                cart.AddItem(rosette, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int rosetteId, string returnUrl)
        {
            Rosette rosette = repository.Rosettes
                .FirstOrDefault(g => g.RosetteId == rosetteId);

            if (rosette != null)
            {
                cart.RemoveLine(rosette);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
