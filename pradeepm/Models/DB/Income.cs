using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Income
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("userid")]
        public int Userid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("Income", TypeName = "decimal(10, 0)")]
        public decimal Income1 { get; set; }
        [Required]
        [StringLength(50)]
        public string IncomeType { get; set; }
        public int Count { get; set; }

        [ForeignKey("Userid")]
        [InverseProperty("Income")]
        public AccountUsers User { get; set; }
    }
}
