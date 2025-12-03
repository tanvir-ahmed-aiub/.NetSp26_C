using PMS.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.CustomValidations
{
    public class UniqueUName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PMS_Fall25_CEntities db = new PMS_Fall25_CEntities();
            if (value != null)
            {
                var uname = (from c in db.Customers
                             where c.Username.Equals(value.ToString())
                             select c).SingleOrDefault();
                if (uname == null)
                {
                    return ValidationResult.Success;
                }
                else return new ValidationResult("username Exists");
            }
            else  return new ValidationResult("Check Values");
        }
    }
}