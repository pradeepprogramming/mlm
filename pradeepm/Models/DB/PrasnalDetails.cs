using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class PrasnalDetails
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountUserID")]
        public int AccountUserId { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "decimal(10, 0)")]
        public decimal Mobile { get; set; }
        [StringLength(20)]
        public string PanCard { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Dob { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(15)]
        public string Gender { get; set; }
        [Column("profilepic")]
        [StringLength(100)]
        public string Profilepic { get; set; }

        [ForeignKey("AccountUserId")]
        [InverseProperty("PrasnalDetails")]
        public AccountUsers AccountUser { get; set; }
    }
}
