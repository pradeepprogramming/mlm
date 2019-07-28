using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Models
{
    public class ModelUserJoin
    {
        [Required]
        public string Pincode { get; set; }
        [Required]
        public string Sponserid { get; set; }
        [Required]
        public string RootId { get; set; }
        [Required]
        public int JoiningSide { get; set; }
        [Required]
        public string ApplicationName { get; set; }
        
        public string PanCard { get; set; }
        [Required]
        public string Dateofbirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Mobile { get; set; }
        [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password Not Matched")]
        public string RetypePassword { get; set; }

    }
}
