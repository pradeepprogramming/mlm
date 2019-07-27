using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class Banks
    {
        public Banks()
        {
            Branches = new HashSet<Branches>();
        }

        [Column("ID")]
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool Status { get; set; }

        [InverseProperty("Bank")]
        public ICollection<Branches> Branches { get; set; }
    }
}
