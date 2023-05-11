using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_rocosa.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        //Get
        public IActionResult Index()
        {
            IEnumerable<Categoria> categoriaList = _context.Categoria;

            return View(categoriaList);
        }

        // Get
        public IActionResult NewCategoria() 
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCategoria(Categoria categoria) 
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index"); // asi me tiro el intellisense
            //return RedirectToAction(nameof(Index)); // asi hace en el curso

        }
    }
}
