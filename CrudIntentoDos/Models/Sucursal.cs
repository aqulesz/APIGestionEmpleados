using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudIntentoDos.Models
{
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SucursalId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
    }
}
