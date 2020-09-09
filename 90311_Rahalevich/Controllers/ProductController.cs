using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _90311_Rahalevich.DAL.Entities;
using _90311_Rahalevich.Models;
using _90311_Rahalevich.Extensions;
using _90311_Rahalevich.DAL.Data;
using Microsoft.Extensions.Logging;

namespace _90311_Rahalevich.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;
        private ILogger _logger;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var groupMame = group.HasValue ? _context.InsulinGroups.Find(group.Value)?.GroupName : "all groups";
            _logger.LogInformation($"info: group={group}, page={pageNo}");

            var insulinsFiltered = _context.Insulins.Where(d => !group.HasValue || d.InsulinGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.InsulinGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Insulin>.GetModel(insulinsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
           
            }
        }
    }