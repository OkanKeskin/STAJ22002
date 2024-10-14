using Application.Features.Mediator.Commands.CandidateExperiance;
using Application.Features.Mediator.Commands.CandidateSkill;
using Application.Features.Mediator.Queries.CandidateExperiance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/candidate/{candidateId}/experiance")]
public class CandidateExperianceController : ControllerBase
{
    private readonly IMediator _mediator;
    public CandidateExperianceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCandidateExperiance([BindRequired] Guid candidateId)
    {
        var values = await _mediator.Send(new GetCandidateExperianceByIdQuery(candidateId));
        return Ok(values);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostCandidateExperiance([FromBody]CreateCandidateExperianceCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpDelete("{candidateExperianceId}")]
    public async Task<IActionResult> RemoveCandidateExperiance([BindRequired] Guid candidateExperianceId)
    {
        await _mediator.Send(new DeleteCandidateExperianceCommand(candidateExperianceId));
        return Ok("Aday Becerisi Başarıyla silindi");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCandidateExperiance([FromBody]UpdateCandidateExperianceCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kategori Başarıyla Güncellendi");
    }
}