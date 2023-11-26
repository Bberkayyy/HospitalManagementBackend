using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.RequestDTO;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalsController : BaseController
{
    private readonly IHospitalService _hospitalService;

    public HospitalsController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] HospitalAddRequest hospitalAddRequest)
    {
        var result = _hospitalService.Add(hospitalAddRequest);
        return ActionResultInstance(result);

    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _hospitalService.Delete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _hospitalService.GetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _hospitalService.GetById(id);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] HospitalUpdateRequest hospitalUpdateRequest)
    {
        var result = _hospitalService.Update(hospitalUpdateRequest);
        return ActionResultInstance(result);
    }
}
