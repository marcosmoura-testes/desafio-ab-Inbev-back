using application.Interfaces;
using domain.DTO;
using domain.Entity;
using employee_api.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace employee_api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
[CustomAuthorize]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IConsultEmployeeUseCase _consultEmployeeUseCase;
    private readonly ICreateEmployeeUseCase _createEmployeeUseCase;
    private readonly IUpdateEmployeeUseCase _updateEmployeeUseCase;
    private readonly IDeleteEmployeeUseCase _deleteEmployeeUseCase;
    private readonly IQueryEmployeeUseCase _queryEmployeeUseCase;

    public EmployeeController(ILogger<EmployeeController> logger,
        IConsultEmployeeUseCase consultEmployeeUseCase,
        ICreateEmployeeUseCase createEmployeeUseCase,
        IUpdateEmployeeUseCase updateEmployeeUseCase,
        IDeleteEmployeeUseCase deleteEmployeeUseCase,
        IQueryEmployeeUseCase queryEmployeeUseCase)
    {
        _logger = logger;
        _consultEmployeeUseCase = consultEmployeeUseCase;
        _createEmployeeUseCase = createEmployeeUseCase;
        _updateEmployeeUseCase = updateEmployeeUseCase;
        _deleteEmployeeUseCase = deleteEmployeeUseCase;
        _queryEmployeeUseCase = queryEmployeeUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDTO employeeDTO)
    {
        Employee logaded = CustomAuthorizeAttribute.logadedEmployee;
        
        var createResuErr = await _createEmployeeUseCase.Execute(employeeDTO, logaded.AccessLevel);
        
        if(createResuErr != null)
            return BadRequest(new { errors = createResuErr.ToList() });
        
        return Created();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
    {
        var updateResuErr = await _updateEmployeeUseCase.Execute(id, employee);
        
        if(updateResuErr != null)
            return BadRequest(new { errors = updateResuErr.ToList() });
        
        return Created();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(int pagesize, int limit)
    {
        List<Employee> employees = await _queryEmployeeUseCase.Execute(pagesize, limit);
        
        if(employees == null)
            return NoContent();
        
        return Ok(new
        {
            list = employees,
            totalRecords = 11//Carregar no retorno
        });
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Employee employee = await _consultEmployeeUseCase.Execute(id);
        
        if(employee == null)
            return NoContent();
        
        return Ok(employee);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteResuErr = await _deleteEmployeeUseCase.Execute(id);
        
        if(deleteResuErr != null)
            return BadRequest(new { errors = deleteResuErr.ToList() });
        
        return Ok();
    }
}