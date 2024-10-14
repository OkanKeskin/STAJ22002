using Domain.Enums;

namespace Application.Features.Mediator.Queries.CandidateApplication;

public class GetCandidateApplicationQueryResult
{
    public Guid FormId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid Id { get; set; }
    public ApplicationStatus ApplicationStatus { get; set; }
}