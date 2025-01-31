using System.IdentityModel.Tokens.Jwt;
using domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace employee_api.Handlers;

public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public static Employee logadedEmployee { get; private set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var token = authorizationHeader.Substring("Bearer ".Length).Trim();

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Preencher o objeto com dados relevantes extraídos do JWT
            logadedEmployee = ExtrairUsuarioDoToken(jwtToken);
        }
        catch
        {
            context.Result = new UnauthorizedResult();
        }
    }

    private Employee ExtrairUsuarioDoToken(JwtSecurityToken jwtToken)
    {
        var employeeIdStr = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
        var employeeName = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
        var employeeEmail = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
        var accessLevel = jwtToken.Claims.FirstOrDefault(c => c.Type == "AccessLevel")?.Value;

        int.TryParse(employeeIdStr, out int employeeId);
        return new Employee
        {
            Id = employeeId,
            Name = employeeName,
            Email = employeeEmail,
            AccessLevel = accessLevel
        };
    }
}