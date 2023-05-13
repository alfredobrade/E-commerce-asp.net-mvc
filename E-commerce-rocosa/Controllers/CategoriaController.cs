using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_rocosa.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoriaController(ApplicationDbContext context)
        {
            _dbContext = context;

        }

        //Get
        public IActionResult Index()
        {
            IEnumerable<Categoria> categoriaList = _dbContext.Categoria;

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
            if (ModelState.IsValid) //valido los datos antes de intentar persistirlos
            {
                _dbContext.Categoria.Add(categoria);
                _dbContext.SaveChanges();
                return RedirectToAction("Index"); // asi me tiro el intellisense
                                                  //return RedirectToAction(nameof(Index)); // asi hace en el curso
            }

            return View(categoria);


        }
        // GET: TipoAplicacionController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _dbContext.Categoria.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST: TipoAplicacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria obj) //TODO: aca el le pasa el objeto.. pero porque? averiguar esto
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _dbContext.Categoria.Update(obj);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(obj);
                }
            }
            return View(obj);


        }

        // GET: TipoAplicacionController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _dbContext.Categoria.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST: TipoAplicacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categoria obj)
        {
            
            try
            {
                _dbContext.Categoria.Remove(obj);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(obj);
            }
        }
    }
}
