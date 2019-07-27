using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    [Table("websitedetails")]
    public partial class Websitedetails
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("columnname")]
        [StringLength(50)]
        public string Columnname { get; set; }
        [Column("value")]
        [StringLength(300)]
        public string Value { get; set; }
        [Column("status")]
        public byte? Status { get; set; }
    }
}
