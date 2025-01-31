using application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace employee_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthEmployeeUseCase _authEmployeeUseCase;
    
    public AuthController(IAuthEmployeeUseCase authEmployeeUseCase)
    {
        _authEmployeeUseCase = authEmployeeUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> AuthEmployee(string email, string password)
    {
        var ucaseReturn = await _authEmployeeUseCase.Execute(email, password);
        
        if(!string.IsNullOrEmpty(ucaseReturn.message))
            return BadRequest(ucaseReturn.message);
        
        return Ok(new
        {
            ucaseReturn.token
        });
    }
}