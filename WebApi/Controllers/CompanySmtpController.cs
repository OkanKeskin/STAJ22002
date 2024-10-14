using Application.Features.Mediator.Queries.CompanySmtp;
using EBursum.Handler.CommandHandlers.Smtp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/company/{companyId}/smtp")]
public class CompanySmtpController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanySmtpController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSmtp([BindRequired] Guid companyId)
    {
        var smtp = await _mediator.Send(new GetCompanySmtpByIdQuery(companyId));
        return Ok(smtp);
    }
    
    [HttpPost]
    public async Task<IActionResult> SetSmtp([FromBody]CreateCompanySmtpCommand command)
    {
        var smtp = await _mediator.Send(command);
        return Ok(smtp);
    }
    
    [HttpDelete("{companySmtpId}")]
    public async Task<IActionResult> DeleteSmtp(DeleteCompanySmtpCommand command)
    {
        var smtp = await _mediator.Send(command);
        return Ok(smtp);
    }
    
    [HttpPut]
    public async Task<IActionResult> DeleteSmtp([FromBody]UpdateCompanySmtpCommand command)
    {
        var smtp = await _mediator.Send(command);
        return Ok(smtp);
    }
}