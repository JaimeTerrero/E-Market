using EMarket.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using EMarket.Core.Application.Helpers;
namespace E_Market.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        public bool HasUser()
        {
            UserViewModel userViewModel = _httpcontextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            if(userViewModel == null)
            {
                return false;
            }

            return true;
        }
    }
}
