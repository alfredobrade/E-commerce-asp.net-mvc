using System.ComponentModel.DataAnnotations;

namespace E_commerce_rocosa.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nombre de Categoria es Obligatorio")]
        public string NombreCategoria { get; set; }
        
        [Required(ErrorMessage = "Orden de Categoria es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage ="El orden debe ser mayor a cero")]
        public int MostrarOrden { get; set; }
    }
}
