using Microsoft.EntityFrameworkCore;
using LibreriaTienda.Entidades;

namespace LibreriaTienda.DataContext
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //le estoy diciendo que la tabla "Pedido" se va a llamar "Pedidos"
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");

            modelBuilder.Entity<Pedido>()
                //un cliente solo tiene un pedido.
                .HasOne(s => s.Cliente)
                //Indica que un cliente puede tener muchos pedidos. 
                .WithMany(c => c.Pedidos)
                //Define la clave foránea que se utilizará en la tabla de Pedidos.
                .HasForeignKey(c => c.PedidoId);
        }
    }
}
