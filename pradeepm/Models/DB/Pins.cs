using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Pins
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PinCode { get; set; }
        public int ForUser { get; set; }
        public int? UsedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UsedDate { get; set; }
        [Column("OrderID")]
        public short OrderId { get; set; }
        public bool Status { get; set; }

        [ForeignKey("ForUser")]
        [InverseProperty("PinsForUserNavigation")]
        public AccountUsers ForUserNavigation { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("Pins")]
        public PinOrders Order { get; set; }
        [ForeignKey("UsedBy")]
        [InverseProperty("PinsUsedByNavigation")]
        public AccountUsers UsedByNavigation { get; set; }
    }
}
