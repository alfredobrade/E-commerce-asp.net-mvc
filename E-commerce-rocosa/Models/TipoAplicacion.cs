

using System.ComponentModel.DataAnnotations;

namespace E_commerce_rocosa.Models
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
