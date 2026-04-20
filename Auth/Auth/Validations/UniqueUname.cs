using Auth.EF;
using System.ComponentModel.DataAnnotations;

namespace Auth.Validations
{
    public class UniqueUname : ValidationAttribute
    {
       

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (AuthCSp26Context)validationContext.GetService(typeof(AuthCSp26Context));
            if (value != null) { 
                var u = (from user in db.Users
                        where user.Username.Equals(value.ToString())
                        select user).SingleOrDefault();
                if (u == null) { 
                    return ValidationResult.Success;
                }
                return new ValidationResult("Username Exists");
            }

            return new ValidationResult("Data Required");
        }
    }
}
