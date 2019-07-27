using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Magicclub
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("accountid")]
        public int Accountid { get; set; }
        [Column("requestdate", TypeName = "datetime")]
        public DateTime Requestdate { get; set; }
        [Column("joiningdate", TypeName = "datetime")]
        public DateTime? Joiningdate { get; set; }
        [Column("status")]
        public byte Status { get; set; }
    }
}
