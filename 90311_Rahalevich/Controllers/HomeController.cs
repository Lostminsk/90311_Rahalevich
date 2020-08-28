using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _90311_Rahalevich.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace _90311_Rahalevich.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<ListDemo> _listDemo;
        public class ListDemo
        {
            public int ListItemValue { get; set; }
            public string ListItemText { get; set; }
        }
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
            };
        }

      

        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
