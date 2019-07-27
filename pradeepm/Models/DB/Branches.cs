using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Branches
    {
        [Column("ID")]
        public short Id { get; set; }
        [Column("BankID")]
        public byte BankId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        public string IfscCode { get; set; }
        public bool Status { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Branches")]
        public Banks Bank { get; set; }
    }
}
