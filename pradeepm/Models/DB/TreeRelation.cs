using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class TreeRelation
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("upperid", TypeName = "numeric(18, 0)")]
        public decimal Upperid { get; set; }
        [Column("accountid", TypeName = "numeric(18, 0)")]
        public decimal Accountid { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal LegNo { get; set; }
        [Column("MLevel", TypeName = "numeric(18, 0)")]
        public decimal Mlevel { get; set; }
    }
}
