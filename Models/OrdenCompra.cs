using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_14_02_2024.Models
{
    [Table("ordenescompra")] //Definir que este va a ser un model llamada Comprador
    public class OrdenCompra
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // auto_increment primary key
        public string Consecutivo { get; set; }
        public string Proyecto { get; set; }
        public int Status { get; set; }// default 1
        public int NoConsecutivo { get; set; }
        public string Referencia { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        public string Empresa { get; set; }
        public string Vendedor { get; set; }
        public string Direccion { get; set; }
        public float Subtotal { get; set; }
        public float Iva { get; set; }
        public float Total { get; set; }
        public string Moneda { get; set; }
        public string CondicionPago { get; set; }
        public string Entrega { get; set; }
        public string TiempoEntrega { get; set; }
        public bool Activo { get; set; } // default true
                                                 // Relación con la tabla Comprador
        public virtual Comprador comprador { get; set; } // Representa la relación con la tabla Comprador
    }
}
