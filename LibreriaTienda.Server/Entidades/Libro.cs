
using System.ComponentModel.DataAnnotations;

namespace LibreriaTienda.Entidades
{
    public class Libro
    {
        [Key]
        public Guid LibroId { get; set; }
        public string? Titulo { get; set; }
        public Guid? AutorId { get; set; }//FK con la tabla autor

        //es una propiedad de navegaci�n que permite acceder al autor asociado a un libro.
        //Junto con la clave for�nea AuthorId, establece una relaci�n uno a muchos entre Author y
        //Book en Entity Framework. Esta propiedad facilita el trabajo con datos relacionados
        //en la base de datos y mejora la legibilidad del c�digo.
        public Autor? Autor { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
       
        // Relaci�n uno a muchos con Pedido
        public Guid? PedidoId { get; set; } //FK con la tabla Pedido
        public Pedido? Pedido { get; set; }

    }
}