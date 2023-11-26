using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.RequestDTO;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : BaseController
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] EmployeeAddRequest employeeAddRequest)
    {
        var result = _employeeService.Add(employeeAddRequest);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] EmployeeUpdateRequest employeeUpdateRequest)
    {
        var result = _employeeService.Update(employeeUpdateRequest);
        return ActionResultInstance(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _employeeService.Delete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _employeeService.GetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("getbyagerange")]
    public IActionResult GetAllByAgeRange([FromQuery] int min, [FromQuery] int max)
    {
        var result = _employeeService.GetAllByAgeRange(min, max);
        return ActionResultInstance(result);
    }
    [HttpGet("getalldetailbytitleid")]
    public IActionResult GetAllDetailByTitleId([FromQuery] int id)
    {
        var result = _employeeService.GetAllDetailByTitleId(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getalldetails")]
    public IActionResult GetAllEmployeeDetails()
    {
        var result = _employeeService.GetAllEmployeeDetails();
        return ActionResultInstance(result);
    }
    [HttpGet("getbydetailid")]
    public IActionResult GetByDetailId([FromQuery] Guid id)
    {
        var result = _employeeService.GetByDetailId(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _employeeService.GetById(id);
        return ActionResultInstance(result);
    }


}
