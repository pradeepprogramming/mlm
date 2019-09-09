using System.ComponentModel.DataAnnotations;

namespace pradeepm.Models.DB
{
    public class Userbinary
    {
       
        public decimal AccountId { get; set; }
        [Key]
        public decimal Legno { get; set; }
        public int Count { get; set; }
        public int Userid { get; set; }
        public int Usedbinary { get; set; }
        public int Sponser { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Admin { get; set; }
        public decimal Tds { get; set; }

    }
}