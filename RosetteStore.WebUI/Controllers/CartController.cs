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
        private IOrderProcessor orderProcessor;
        public CartController(IRosetteRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
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
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}
