//ACCESO A BASE DE DATOS
using Microsoft.EntityFrameworkCore;
using LibreriaTienda.Entidades;

namespace LibreriaTienda.DataContext;//uso de todo el proyecto (raiz)


public class AutorContext : DbContext
{
  
    public AutorContext(DbContextOptions<AutorContext> options) : base(options){ }


    
    public DbSet<Autor> Autores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //le estoy diciendo que la tabla "Autor" se va a llamar "Autores"
        modelBuilder.Entity<Autor>().ToTable("Autores");
        //En esta secci�n est�s configurando la relaci�n entre las entidades Autor y Libro. Espec�ficamente
        modelBuilder.Entity<Autor>()
            //Indica que un autor puede tener muchos libros. Esto configura la relaci�n de uno a muchos
            //entre Autor y Libro
            .HasMany(a => a.Libros)
            //Indica que un libro tiene exactamente un autor. Esto establece que la propiedad de navegaci�n
            //Autor en la clase Libro apunta al autor de ese libro
            .WithOne(l => l.Autor)
            //Define la clave for�nea que se utilizar� en la tabla de Libro para establecer la relaci�n
            //con la tabla de Autor. En la entidad Autores, AutorId es la propiedad que act�a como clave
            //for�nea que referencia al Libro correspondiente.
            .HasForeignKey(l => l.AutorId);
    }
}
