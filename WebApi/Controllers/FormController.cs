using Application.Features.Mediator.Commands.Company;
using Application.Features.Mediator.Commands.Form;
using Application.Features.Mediator.Queries.Form;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/form")]
public class FormController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRedisCacheServices _redisCacheServices;

    public FormController(IMediator mediator,IRedisCacheServices redisCacheServices)
    {
        _mediator = mediator;
        _redisCacheServices = redisCacheServices;
    }
    
    //Get Form
    [HttpGet("{formId}")]
    public async Task<IActionResult> GetForm([BindRequired] Guid formId)
    {
        var cmd = await _mediator.Send(new GetFormByIdQuery(formId));
        return Ok(cmd);
    }
    
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetFormByCompanyId([FromBody] Guid companyId)
    {
        var cmd = await _mediator.Send(new GetFormByCompanyIdQuery(companyId));
        return Ok(cmd);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetForms()
    {
        var cmd = await _mediator.Send(new GetFormQuery());
        return Ok(cmd);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateForms([FromBody]CreateFormCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateForms([FromBody]UpdateFormCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpDelete("{formId}")]
    public async Task<IActionResult> DeleteForms([BindRequired] Guid formId)
    {
        await _mediator.Send(new DeleteFormCommand(formId));
        return Ok("Form Başarıyla silindi");
    }
}