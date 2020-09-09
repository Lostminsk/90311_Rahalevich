using _90311_Rahalevich.DAL.Extensions;
using _90311_Rahalevich.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _90311_Rahalevich.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
