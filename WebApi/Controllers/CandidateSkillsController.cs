using Application.Features.Mediator.Commands.CandidateSkill;
using Application.Features.Mediator.Queries;
using Application.Features.Mediator.Queries.GetCandidateQueryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/candidate/{candidateId}/skill")]
public class CandidateSkillsController : ControllerBase
{ 
    private readonly IMediator _mediator;
    public CandidateSkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCandidateSkills([BindRequired] Guid candidateId)
    {
        var values = await _mediator.Send(new GetCandidateSkillQueryByIdQuery(candidateId));
        return Ok(values);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostCandidateSkills([FromBody]CreateCandidateSkillCommand command)
    {
        var cmd = await _mediator.Send(command);
        return Ok("Id" + cmd);
    }
    
    [HttpDelete("{candidateSkillId}")]
    public async Task<IActionResult> RemoveCandidateSkills([BindRequired] Guid candidateSkillId)
    {
        await _mediator.Send(new DeleteCandidateSkillCommand(candidateSkillId));
        return Ok("Aday Becerisi Başarıyla silindi");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCandidateSkills([FromBody]UpdateCandidateSkillCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kategori Başarıyla Güncellendi");
    }
}