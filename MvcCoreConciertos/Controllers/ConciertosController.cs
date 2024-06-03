using Microsoft.AspNetCore.Mvc;
using MvcCoreConciertos.Models;
using MvcCoreConciertos.Services;

namespace MvcCoreConciertos.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceConciertos service;

        public ConciertosController(ServiceConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            ViewData["categorias"] = await this.service.GetCategoriaAsync();
            return View(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<Evento> evenosFiltered = await this.service.GetEventosByCategoriaAsync(idcategoria);
            ViewData["categorias"] = await this.service.GetCategoriaAsync();
            return View(evenosFiltered);

        }
    }
}
