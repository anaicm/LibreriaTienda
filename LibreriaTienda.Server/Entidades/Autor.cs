
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibreriaTienda.Entidades
{
    public class Autor
    {
        [Key]
        public Guid AutorId { get; set; }
        public string? Nombre { get; set; }

        //Para unirlo con la tabla libros
        public ICollection<Libro> Libros { get; set; }
    }
}