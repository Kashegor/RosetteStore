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
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int rosetteId, string returnUrl)
        {
            Rosette rosette = repository.Rosettes
                .FirstOrDefault(g => g.RosetteId == rosetteId);

            if (rosette != null)
            {
                GetCart().AddItem(rosette, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int rosetteId, string returnUrl)
        {
            Rosette rosette = repository.Rosettes
                .FirstOrDefault(g => g.RosetteId == rosetteId);

            if (rosette != null)
            {
                GetCart().RemoveLine(rosette);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
