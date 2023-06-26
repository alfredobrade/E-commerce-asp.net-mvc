using E_commerce_rocosa.Datos;
using E_commerce_rocosa.Models;
using E_commerce_rocosa.Models.ViewModels;
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
        //para manejar las imagenes creamos una nueva variable read only
        private readonly IWebHostEnvironment _webHostEnvironment; //y la inyectamos por constructor

        public ProductoController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = context;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: ProductoController
        public IActionResult Index()
        {
            IEnumerable<Producto> productosList = _dbContext.Productos.Include(c => c.Categoria)
                .Include(t => t.TipoAplicacion);
            return View(productosList);
        }

      

        // GET: ProductoController/Create
        public IActionResult NewProduct() //este metodo le hice con viewBag y al insertOrUpdate le hice con el VM loco
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
                //todo esto es para manejo de imagenes
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                string upload = webRootPath + WC.ImgRoute;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                
                using (var fileStream = new FileStream(Path.Combine(upload,fileName+extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                producto.ImgUrl = fileName + extension;

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
            //IEnumerable<SelectListItem> categoriaDropDown =
            //    _dbContext.Categoria.Select(p => new SelectListItem
            //    {
            //        Text = p.NombreCategoria,
            //        Value = p.Id.ToString()
            //    });

            //ViewBag.categoriaDD = categoriaDropDown;


            //var producto = new Producto();

            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Producto(),
                CategoriaList = _dbContext.Categoria.Select(p => new SelectListItem
                {
                    Text = p.NombreCategoria,
                    Value = p.Id.ToString()
                }),
                TipoAplicacionList = _dbContext.TipoAplicacion.Select(p => new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.Id.ToString()
                })

            };


            if (id == null)
            {
                try
                {
                    //_dbContext.Productos.Add(producto);
                    _dbContext.Productos.Add(productoVM.Producto);

                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(productoVM);

                }
                //O invocando NewProduct()
            }
            else
            {
                //producto = _dbContext.Productos.Find(id);
                productoVM.Producto = _dbContext.Productos.Find(id);

                //_dbContext.Productos.Update(producto);
                _dbContext.Productos.Update(productoVM.Producto);
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
