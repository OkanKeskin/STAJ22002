using Application.Features.Mediator.Commands.User;
using Application.Features.Mediator.Queries.Candidate;
using Application.Features.Mediator.Queries.CandidateExperiance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/candidate")]
public class CandidateController : ControllerBase
{
    private readonly IMediator _mediator;

    public CandidateController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{candidateId}")]
    public async Task<IActionResult> GetCandidate([BindRequired] Guid candidateId)
    {
        var values = await _mediator.Send(new GetCandidateByIdQuery(candidateId));
        return Ok(values);
    }
    
    [HttpDelete("{candidateId}")]
    public async Task<IActionResult> RemoveCandidate([BindRequired] Guid candidateId)
    {
        await _mediator.Send(new DeleteCandidateCommand(candidateId));
        return Ok("Aday Becerisi Başarıyla silindi");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCandidateExperiance([FromBody]UpdateCandidateCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kategori Başarıyla Güncellendi");
    }
}