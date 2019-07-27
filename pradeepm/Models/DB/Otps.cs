using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    [Table("OTPs")]
    public partial class Otps
    {
        [Column("ID")]
        public int Id { get; set; }
        public short Otp1 { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Otps")]
        public AccountUsers User { get; set; }
    }
}
