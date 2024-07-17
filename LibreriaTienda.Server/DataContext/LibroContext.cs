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
            

            //relaci�n con clase autor
            modelBuilder.Entity<Libro>()
                //Esto establece la relaci�n de navegaci�n desde la entidad Libro hacia la entidad Autor.
                //Significa que un libro tiene exactamente un autor. l es una variable que representa
                //cada instancia de Libro.
                .HasOne(l => l.Autor)
                //Indica que la entidad Autor puede tener muchos libros. Esta configuraci�n establece la
                //relaci�n inversa desde Autor hacia Libro. a es una variable que representa cada instancia
                //de Autor, y a.Libros es la propiedad de navegaci�n en Autor que representa
                //la colecci�n de libros escritos por ese autor.
                .WithMany(a => a.Libros)
                // Clave for�nea en Libro hacia Autor
                .HasForeignKey(l => l.AutorId);

        }
    }
}
