namespace CrudIntentoDos.DTOs
{
    public class EmpleadoUpdateDto
    {
        public int EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public int SucursalId { get; set; }
    }
}
