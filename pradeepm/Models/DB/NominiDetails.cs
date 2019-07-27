using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class NominiDetails
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountUserID")]
        public int AccountUserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Relation { get; set; }
        public bool Status { get; set; }
        [Column("UDate", TypeName = "datetime")]
        public DateTime Udate { get; set; }

        [ForeignKey("AccountUserId")]
        [InverseProperty("NominiDetails")]
        public AccountUsers AccountUser { get; set; }
    }
}
