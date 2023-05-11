using System.ComponentModel.DataAnnotations;

namespace E_commerce_rocosa.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public int MostrarOrden { get; set; }
    }
}
