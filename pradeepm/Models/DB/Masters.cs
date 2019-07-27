using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Masters
    {
        [Key]
        [StringLength(50)]
        public string MasterKey { get; set; }
        [Column("value", TypeName = "decimal(6, 2)")]
        public decimal Value { get; set; }
    }
}
