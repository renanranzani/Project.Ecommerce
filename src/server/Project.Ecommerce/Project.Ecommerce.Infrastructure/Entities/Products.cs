using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Ecommerce.Infrastructure.Entities
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public int Inventory { get; set; }
        public decimal Value { get; set; }
        public bool Status { get; set; }

        [Column("Image", TypeName = "BLOB")]
        public byte[] Image { get; set; }
    }
}
