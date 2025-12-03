using PMS.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [UniqueUName]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [ConfPassMatch]
        public string ConfPassword { get; set; }

    }
}