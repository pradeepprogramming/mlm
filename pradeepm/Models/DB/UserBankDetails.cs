using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class UserBankDetails
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountUserID")]
        public int AccountUserId { get; set; }
        [Required]
        [StringLength(50)]
        public string BankName { get; set; }
        [StringLength(50)]
        public string BranchName { get; set; }
        [StringLength(20)]
        public string IfscCode { get; set; }
        [Column(TypeName = "decimal(26, 0)")]
        public decimal AccountNo { get; set; }
        public bool IsPrimary { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Column("UDate", TypeName = "datetime")]
        public DateTime Udate { get; set; }

        [ForeignKey("AccountUserId")]
        [InverseProperty("UserBankDetails")]
        public AccountUsers AccountUser { get; set; }
    }
}
