﻿using Microsoft.AspNetCore.Mvc;
using Mission_9_conmansp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_conmansp.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController (ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutComplete");
            }
            else
            {
                return View();
            }
        }
    }
}
