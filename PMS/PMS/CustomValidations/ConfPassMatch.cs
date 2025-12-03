using PMS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.CustomValidations
{
    public class ConfPassMatch : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as CustomerDTO;
            if (obj.Password != null && value != null) {
                if (value.ToString().Equals(obj.Password))
                {
                    return ValidationResult.Success;
                }
                else
                    return new ValidationResult("Password and Confirm Password Mismatched");
            }
            return new ValidationResult("Check Values");
        }
    }
}