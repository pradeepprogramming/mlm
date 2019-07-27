using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class UserLogins
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountUserID")]
        public int AccountUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoginDatetime { get; set; }
        [Required]
        [Column("IP")]
        [StringLength(15)]
        public string Ip { get; set; }

        [ForeignKey("AccountUserId")]
        [InverseProperty("UserLogins")]
        public AccountUsers AccountUser { get; set; }
    }
}
