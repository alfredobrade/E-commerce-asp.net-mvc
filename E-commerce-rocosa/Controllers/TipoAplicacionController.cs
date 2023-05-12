using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_rocosa.Controllers
{
    public class TipoAplicacionController : Controller
    {
        //creamos la variable dbContext para inyectar la dependencia por constructor
        private readonly ApplicationDbContext _dbContext;

        public TipoAplicacionController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        // GET: TipoAplicacionController
        public ActionResult Index()
        {
            IQueryable<TipoAplicacion> tipoAplicacionList = _dbContext.TipoAplicacion;     
            return View(tipoAplicacionList);
        }

        // GET: TipoAplicacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoAplicacionController/Create
        public ActionResult NewTipoAplicacion()
        {
            return View();
        }

        // POST: TipoAplicacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewTipoAplicacion(TipoAplicacion tipoAplicacion)
        {
            _dbContext.TipoAplicacion.Add(tipoAplicacion);
            await _dbContext.SaveChangesAsync();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoAplicacionController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _dbContext.Categoria.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST: TipoAplicacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TipoAplicacion tipoAplicacion)
        {
            try
            {
                _dbContext.TipoAplicacion.Update(tipoAplicacion);
                _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tipoAplicacion);
            }
        }

        // GET: TipoAplicacionController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0) return NotFound();

            var obj = _dbContext.Categoria.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        // POST: TipoAplicacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TipoAplicacion obj)
        {
            try
            {
                _dbContext.TipoAplicacion.Remove(obj); 
                _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(obj);
            }
        }
    }
}
