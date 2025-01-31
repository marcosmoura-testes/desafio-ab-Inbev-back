using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using application.Interfaces;
using domain.Entity;
using domain.UoW;
using domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace application.UseCases;

public class AuthEmployeeUseCase:IAuthEmployeeUseCase
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public AuthEmployeeUseCase(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<(string token, string message)> Execute(string email, string password)
    {
        PasswordHasher PasswordHasher = new PasswordHasher();
        
        Employee employee = await _unitOfWork.EmployeesRepository.GetByEmail(email);

        if (employee == null)
            return (string.Empty, "incorrect Email or password");
        
        bool passwordOk = PasswordHasher.VerifyPassword($"{email}{password}", employee.Password);

        if (!passwordOk)
            return (string.Empty, "incorrect Email or password");
        
        return (GenerateJwtToken(employee), string.Empty);
    }
    
    private string GenerateJwtToken(Employee employee)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, employee.Name),
            new Claim(JwtRegisteredClaimNames.Sub, employee.Email),
            new Claim("NivelAcesso", employee.NivelAcesso),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresInMinutes = Convert.ToInt32(_configuration["JWT:ExpiresInMinutes"]);
        var token = new JwtSecurityToken(
            issuer: "employeeapi.com",
            audience: "employeeapi.com",
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiresInMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}