using BdFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BdFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL.Modelo.entityBasicoContext context;

        public HomeController(DAL.Modelo.entityBasicoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var empleado = this.context.Empleado.Include("Empleado");
            return View(empleado);
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