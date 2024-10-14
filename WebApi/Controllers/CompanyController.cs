using Application.Features.Mediator.Commands.Company;
using Application.Features.Mediator.Commands.User;
using Application.Features.Mediator.Queries.Candidate;
using Application.Features.Mediator.Queries.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/company")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompany([BindRequired] Guid companyId)
    {
        var values = await _mediator.Send(new GetCompanyByIdQuery(companyId));
        return Ok(values);
    }
    
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> RemoveCompany([BindRequired] Guid companyId)
    {
        await _mediator.Send(new DeleteCompanyCommand(companyId));
        return Ok("Aday Becerisi Başarıyla silindi");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCompany([FromBody]UpdateCompanyCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kategori Başarıyla Güncellendi");
    }
}