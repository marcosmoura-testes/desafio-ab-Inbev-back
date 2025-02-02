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

    /// <summary>
    /// Create a New Employee.
    /// </summary>
    /// <param name="employeeDTO">Object for send employee information</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] EmployeeDTO employeeDTO)
    {
        Employee logaded = CustomAuthorizeAttribute.logadedEmployee;
        
        var createResuErr = await _createEmployeeUseCase.Execute(employeeDTO, logaded.AccessLevel);
        
        if(createResuErr != null)
            return BadRequest(new { errors = createResuErr.ToList() });
        
        return Created();
    }
    
    /// <summary>
    /// Update a exist Employee.
    /// </summary>
    /// <param name="employeeDTO">Object for send employee information</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeDTO employee)
    {
        var updateResuErr = await _updateEmployeeUseCase.Execute(id, employee);
        
        if(updateResuErr != null)
            return BadRequest(new { errors = updateResuErr.ToList() });
        
        return Created();
    }
    
    /// <summary>
    /// Create a New Employee.
    /// </summary>
    /// <param name="page">Number of page</param>
    /// <param name="limit">Number limit of registers</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get(int page, int limit)
    {
        var employeesExec = await _queryEmployeeUseCase.Execute(page, limit);
        if(employeesExec.employees == null)
            return NoContent();
        
        return Ok(new
        {
            list = employeesExec.employees,
            total = employeesExec.totalRecords
        });
    }
    
    /// <summary>
    /// Get employee information by Id.
    /// </summary>
    /// <param name="id">Id employee</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Employee employee = await _consultEmployeeUseCase.Execute(id);
        
        if(employee == null)
            return NoContent();
        
        return Ok(employee);
    }
    
    /// <summary>
    /// Get employee information by Id.
    /// </summary>
    /// <param name="id">Id employee</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteResuErr = await _deleteEmployeeUseCase.Execute(id);
        
        if(deleteResuErr != null)
            return BadRequest(new { errors = deleteResuErr.ToList() });
        
        return Ok();
    }
}