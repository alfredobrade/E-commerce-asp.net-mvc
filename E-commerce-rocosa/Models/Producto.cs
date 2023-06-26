

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_rocosa.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre del producto es Requerido")]
        public string ProductName { get; set; }

        //[Required(ErrorMessage = "El description del producto es Requerido")]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Ingrese un precio")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public string? ImgUrl { get; set; }


        //Foreign key
        public int? CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public virtual Categoria? Categoria { get; set; }

        public int? TipoAplicacionId { get; set; }
        [ForeignKey(nameof(TipoAplicacionId))]
        public virtual TipoAplicacion? TipoAplicacion { get; set; }

    }
}
