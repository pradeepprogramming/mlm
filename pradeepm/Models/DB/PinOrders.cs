using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class PinOrders
    {
        public PinOrders()
        {
            Pins = new HashSet<Pins>();
        }

        [Column("ID")]
        public short Id { get; set; }
        [Column("OrderByUserID")]
        public int OrderByUserId { get; set; }
        [Column("ProductID")]
        public byte ProductId { get; set; }
        public int PinQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("OrderByUserId")]
        [InverseProperty("PinOrders")]
        public AccountUsers OrderByUser { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("PinOrders")]
        public Products Product { get; set; }
        [InverseProperty("Order")]
        public ICollection<Pins> Pins { get; set; }
    }
}
