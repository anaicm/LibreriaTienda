
using System.ComponentModel.DataAnnotations;

namespace LibreriaTienda.Entidades
{
    public class Cliente
    {
        [Key]
        public Guid ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}