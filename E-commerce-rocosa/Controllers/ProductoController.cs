using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<SelectListItem> categoriaDropDown =
                _dbContext.Categoria.Select(p => new SelectListItem
                {
                    Text = p.NombreCategoria,
                    Value = p.Id.ToString()
                });

            ViewBag.categoriaDropDown = categoriaDropDown;

            IEnumerable<SelectListItem> tipoApDropDown =
                _dbContext.TipoAplicacion.Select(p => new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.Id.ToString()
                });

            ViewBag.tipoApDropDown = tipoApDropDown;

            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewProduct(Producto producto)
        {
            

            try
            {
				_dbContext.Productos.Add(producto);
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producto);
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
            IEnumerable<SelectListItem> categoriaDropDown =
                _dbContext.Categoria.Select(p => new SelectListItem
                {
                    Text = p.NombreCategoria,
                    Value = p.Id.ToString()
                });

            ViewBag.categoriaDD = categoriaDropDown;

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
