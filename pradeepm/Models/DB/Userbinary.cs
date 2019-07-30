using System.ComponentModel.DataAnnotations;

namespace pradeepm.Models.DB
{
    public class Userbinary
    {
       
        public decimal AccountId { get; set; }
        [Key]
        public decimal Legno { get; set; }
        public int Count { get; set; }
    }
}