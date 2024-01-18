using Microsoft.EntityFrameworkCore;

namespace CrudIntentoDos.Models
{
    public class GestionEmpleadoContext : DbContext
    {
        public GestionEmpleadoContext(DbContextOptions<GestionEmpleadoContext> options)
        : base(options)
        {
        }

        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Empleado> Empleados { get; set;}
    }
}
