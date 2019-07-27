using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    [Table("payout")]
    public partial class Payout
    {
        [Column("ID")]
        public int Id { get; set; }
        public int Userid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(10, 0)")]
        public decimal? Debit { get; set; }
        [Column(TypeName = "decimal(10, 0)")]
        public decimal? Credit { get; set; }
        [Required]
        [StringLength(50)]
        public string Remark { get; set; }
        [Column(TypeName = "decimal(5, 0)")]
        public decimal Admin { get; set; }
        [Column(TypeName = "decimal(5, 0)")]
        public decimal Tds { get; set; }

        [ForeignKey("Userid")]
        [InverseProperty("Payout")]
        public AccountUsers User { get; set; }
    }
}
