using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_commerce_rocosa.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductoController(ApplicationDbContext context)
        {
            _dbContext = context;            
        }

        // GET: ProductoController
        public IActionResult Index()
        {
            IEnumerable<Producto> productosList = _dbContext.Productos.Include(c => c.Categoria)
                .Include(t => t.TipoAplicacion);
            return View(productosList);
        }

      

        // GET: ProductoController/Create
        public IActionResult NewProduct()
        {
            
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProduct(Producto producto)
        {
            try
            {
				_dbContext.Productos.Add(producto);
				_dbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get
        public IActionResult InsertOrUpdate()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertOrUpdate(int? id)
        {
            var producto = new Producto();
            if (id == null)
            {
                try
                {
                    _dbContext.Productos.Add(producto);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
                //O invocando NewProduct()
            }
            else
            {
                producto = _dbContext.Productos.Find(id);

                _dbContext.Productos.Update(producto);
                await _dbContext.SaveChangesAsync();
                return View("Index");
                // o usando metodo Edit
            }

		}


		// GET: ProductoController/Edit/5
		public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
