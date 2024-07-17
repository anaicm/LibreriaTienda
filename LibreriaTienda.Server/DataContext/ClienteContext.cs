using Microsoft.EntityFrameworkCore;
using LibreriaTienda.Entidades;

namespace LibreriaTienda.DataContext
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //le estoy diciendo que la tabla "Cliente" se va a llamar "Clientes"
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Cliente>()
                //Indica que un cliente puede tener muchos pedidos. Esto configura la relación de uno a muchos
                //entre Cliente y Pedido
                .HasMany(c => c.Pedidos)
                //un cliente solo tiene un pedido.
                .WithOne(s => s.Cliente)
                //Define la clave foránea que se utilizará en la tabla de Pedidos para establecer la relación
                //con la tabla de Clientes. En la entidad Clientes, ClienteId es la propiedad que actúa como clave
                //foránea que referencia al cliente correspondiente.
                .HasForeignKey(c => c.ClienteId);
        }
    }
}
