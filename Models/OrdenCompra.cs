using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_14_02_2024.Models
{
    [Table("ordenescompra")] //Definir que este va a ser un model llamada Comprador
    public class OrdenCompra
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // auto_increment primary key
        public string Proyecto { get; set; }
        public int Status { get; set; }// default 1
        public int NoConsecutivo { get; set; }
        public string Referencia { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

    }
}
