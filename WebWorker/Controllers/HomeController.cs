using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebWorker.Models;
using WebWorker.Services;

namespace WebWorker.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFoodService _foodService;

        public HomeController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _foodService.GetAll();

            list = list.OrderByDescending(x => x.CreatedAt).ToList();

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> CleanDatabase()
        {
            var result = await _foodService.CleanDatabase();

            if (result >= 0)
                return Json($"Deleted: {result}");
            else
                return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
