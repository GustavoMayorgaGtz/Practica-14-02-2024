using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_14_02_2024.Models
{
    [Table("compradores")] //Definir que este va a ser un model llamada Comprador
    public class Comprador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public Boolean Activo { get; set; }

        public String URLpath { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro {get; set;}

        public int OrdenCompraId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
    }
}
