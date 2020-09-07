using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _90311_Rahalevich.DAL.Entities;

namespace _90311_Rahalevich.Controllers
{
    public class ProductController : Controller
    {
        public List<Insulin> _insulins;
        List<InsulinGroup> _insulinGroups;
        int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }
        public IActionResult Index(int pageNo = 1)
        {
            var items = _insulins
           .Skip((pageNo - 1) * _pageSize)
           .Take(_pageSize)
           .ToList();
            return View(items);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _insulinGroups = new List<InsulinGroup>
            {
                new InsulinGroup {InsulinGroupId=1, GroupName="Fast"},
                new InsulinGroup {InsulinGroupId=2, GroupName="Very fast"},
                new InsulinGroup {InsulinGroupId=3, GroupName="Long"},
                new InsulinGroup {InsulinGroupId=4, GroupName="Very long"},
                new InsulinGroup {InsulinGroupId=5, GroupName="Slow"},
                new InsulinGroup {InsulinGroupId=6, GroupName="Normal"}
            };
            _insulins = new List<Insulin>
            {
                new Insulin { InsulinId = 1, InsulinName = "Novorapid", Publisher = "NovoNordisk", Rating = 8, InsulinGroupId = 1, Image = "novorapid.jpg" },
                new Insulin { InsulinId = 2, InsulinName = "Fiasp", Publisher = "NovoNordisk", Rating = 7, InsulinGroupId = 2, Image = "fiasp.jpg" },
                new Insulin { InsulinId = 3, InsulinName = "Levemir", Publisher = "NovoNordisk", Rating = 6, InsulinGroupId = 3, Image = "levemir.jpg" },
                new Insulin { InsulinId = 4, InsulinName = "Tresiba", Publisher = "NovoNordisk", Rating = 9, InsulinGroupId = 4, Image = "tresiba.jpg" },
                new Insulin { InsulinId = 5, InsulinName = "Apidra", Publisher = "Sanofi", Rating = 10, InsulinGroupId = 2, Image = "apidra.jpg" },
                new Insulin { InsulinId = 6, InsulinName = "Lantus", Publisher = "Sanofi", Rating = 6, InsulinGroupId = 5, Image = "lantus.jpg" },
                new Insulin { InsulinId = 7, InsulinName = "Tudgeo", Publisher = "Sanofi", Rating = 9, InsulinGroupId = 6, Image = "tudgeo.jpg" }
            };
        }
    }
}
