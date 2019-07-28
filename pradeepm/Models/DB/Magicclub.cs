using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Magicclub
    {
        [Column("id")]
        [Display(Name ="ID")]
        public int Id { get; set; }
        [Column("accountid")]
        [Display(Name = "Account ID")]
        public int Accountid { get; set; }
        [Column("requestdate", TypeName = "datetime")]
        [Display(Name = "Request Date")]
        public DateTime Requestdate { get; set; }
        [Column("joiningdate", TypeName = "datetime")]
        [Display(Name = "Approve Date")]
        public DateTime? Joiningdate { get; set; }
        [Column("status")]
        public byte Status { get; set; }
    }
}
