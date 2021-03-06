using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, User user);
        ClaimsPrincipal ValidateToken(string key, string issuer, string audience, string token);
    }
}
