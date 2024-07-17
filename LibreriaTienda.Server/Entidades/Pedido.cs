

using System.ComponentModel.DataAnnotations;

namespace LibreriaTienda.Entidades
{
    public class Pedido
    {
        [Key]
        public Guid PedidoId { get; set; }
        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
       
        public DateTime? FechaPedido { get; set; }
        public decimal? CantidadTotal { get; set; }
        // Relación uno a muchos con Libro
        public ICollection<Libro> Libros { get; set; }

    }
}