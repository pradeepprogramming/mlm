using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class UserClosing
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ClosingDate { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        public int TotalBinary { get; set; }
        public int Binary { get; set; }
        public int UsedBinary { get; set; }
        public int LeftCarry { get; set; }
        public int RightCarry { get; set; }
        public int Sponser { get; set; }
        public int Level { get; set; }
        public short ForLevelCut { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Column("leftcount")]
        public int Leftcount { get; set; }
        [Column("rightcount")]
        public int Rightcount { get; set; }
        [Column("leftused")]
        public int Leftused { get; set; }
        [Column("rightused")]
        public int Rightused { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserClosing")]
        public AccountUsers User { get; set; }
    }
}
