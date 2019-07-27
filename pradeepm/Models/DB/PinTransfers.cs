using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class PinTransfers
    {
        [Column("ID")]
        public int Id { get; set; }
        public short PinCount { get; set; }
        [Column("FromUserID")]
        public int FromUserId { get; set; }
        [Column("ToUserID")]
        public int ToUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransferDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("FromUserId")]
        [InverseProperty("PinTransfersFromUser")]
        public AccountUsers FromUser { get; set; }
        [ForeignKey("ToUserId")]
        [InverseProperty("PinTransfersToUser")]
        public AccountUsers ToUser { get; set; }
    }
}
