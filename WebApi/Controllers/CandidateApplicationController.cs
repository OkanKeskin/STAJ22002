using Application.Features.Mediator.Commands.CandidateApplication;
using Application.Features.Mediator.Queries.CandidateApplication;
using Application.Features.Mediator.Queries.Form;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/candidate/{candidateId}/application")]
public class CandidateApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public CandidateApplicationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    //Get Form
    [HttpGet("{applicationId}")]
    public async Task<IActionResult> GetCandidateApplication([BindRequired] Guid applicationId)
    {
        var cmd = await _mediator.Send(new GetCandidateApplicationByIdQuery(applicationId));
        return Ok(cmd);
    }
    
    //Get Form
    [HttpGet]
    public async Task<IActionResult> GetCandidateApplications([BindRequired] Guid candidateId)
    {
        var cmd = await _mediator.Send(new GetCandidateApplicationsQuery(candidateId));
        return Ok(cmd);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCandidateApplication([FromBody]CreateCandidateApplicationCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateForms([FromBody]UpdateCandidateApplicationCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpDelete("{applicationId}")]
    public async Task<IActionResult> UpdateForms([BindRequired] Guid applicationId)
    {
        await _mediator.Send(new DeleteCandidateApplicationCommand(applicationId));
        return Ok("Aday Başvurusu Başarıyla silindi");
    }
    
    //CreateApplication
    //DeleteApp
    //UpdateApplication
}