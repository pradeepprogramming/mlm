using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Products
    {
        public Products()
        {
            AccountUsers = new HashSet<AccountUsers>();
            PinOrders = new HashSet<PinOrders>();
        }

        [Column("ID")]
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ProductAmount { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal JoiningAmount { get; set; }
        public short BinaryIncome { get; set; }
        public short DirectIncome { get; set; }
        public short LevelIncome { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public bool Status { get; set; }

        [InverseProperty("Product")]
        public ICollection<AccountUsers> AccountUsers { get; set; }
        [InverseProperty("Product")]
        public ICollection<PinOrders> PinOrders { get; set; }
    }
}
