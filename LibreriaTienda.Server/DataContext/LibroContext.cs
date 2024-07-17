//ACCESO A BASE DE DATOS
using Microsoft.EntityFrameworkCore;
using LibreriaTienda.Entidades;

namespace LibreriaTienda.DataContext
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>().ToTable("Libros");
            

            //relación con clase autor
            modelBuilder.Entity<Libro>()
                //Esto establece la relación de navegación desde la entidad Libro hacia la entidad Autor.
                //Significa que un libro tiene exactamente un autor. l es una variable que representa
                //cada instancia de Libro.
                .HasOne(l => l.Autor)
                //Indica que la entidad Autor puede tener muchos libros. Esta configuración establece la
                //relación inversa desde Autor hacia Libro. a es una variable que representa cada instancia
                //de Autor, y a.Libros es la propiedad de navegación en Autor que representa
                //la colección de libros escritos por ese autor.
                .WithMany(a => a.Libros)
                // Clave foránea en Libro hacia Autor
                .HasForeignKey(l => l.AutorId);

        }
    }
}
