using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Models.DTOs.RequestDTO;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitlesController : BaseController
{
    private readonly ITitleService _titleService;

    public TitlesController(ITitleService titleService)
    {
        _titleService = titleService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] TitleAddRequest titleAddRequest)
    {
        var result = _titleService.Add(titleAddRequest);
        return ActionResultInstance(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] int id)
    {
        var result = _titleService.Delete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _titleService.GetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = _titleService.GetById(id);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] TitleUpdateRequest titleUpdateRequest)
    {
        var result = _titleService.Update(titleUpdateRequest);
        return ActionResultInstance(result);
    }
}
