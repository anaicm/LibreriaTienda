using Microsoft.EntityFrameworkCore;
using LibreriaTienda.Entidades;

namespace LibreriaTienda.DataContext
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //creación de las tablas con ToTable
            modelBuilder.Entity<Autor>().ToTable("Autores");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Libro>().ToTable("Libros");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");

            // Configurar relación uno a muchos entre Autor y Libro
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)//un autor 
                .WithMany(a => a.Libros)//tiene muchos libros 
                .HasForeignKey(l => l.AutorId);//clave foranea

            // Configurar relación uno a muchos entre Cliente y Pedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)//un cliente 
                .WithMany(c => c.Pedidos)//tiene muchos pedidos 
                .HasForeignKey(p => p.ClienteId);//clave foranea

            // Configurar relación uno a muchos entre Pedido y Libro
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Pedido)//un pedido 
                .WithMany(p => p.Libros)//tiene muchos libros
                .HasForeignKey(l => l.PedidoId);//clave foranea
        }
    }
}
