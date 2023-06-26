using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerce_rocosa.Models.ViewModels
{
    public class ProductoVM
    {

        public Producto Producto { get; set; } //TODO: no entiendo


        public IEnumerable<SelectListItem>? CategoriaList { get; set; }
        public IEnumerable<SelectListItem>? TipoAplicacionList { get; set; }


    }
}
