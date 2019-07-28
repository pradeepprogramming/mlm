using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Models
{
    public class ModelPin
    {

    }

    public class ModelGenratePin
    {

        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int PinCount { get; set; }
    }

}
