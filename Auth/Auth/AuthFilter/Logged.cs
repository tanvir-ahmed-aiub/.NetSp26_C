using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.AuthFilter
{
    public class Logged : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
