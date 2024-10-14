using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.Form;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery,List<GetFormQueryResult>>
{
    private readonly IRepository<Domain.Entities.Form> _repository;

    public GetFormQueryHandler(IRepository<Domain.Entities.Form> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetFormQueryResult>> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();

        return result.Select(x => new GetFormQueryResult
        {
            Id = x.Id,
            Explantion = x.Explantion,
            CompanyId = x.CompanyId,
            StartTime = x.StartTime,
            NotBeCandidates = x.NotBeCandidates,
            Job = x.Job,
            Location = x.Location,
            Name = x.Name,
            DueTime = x.DueTime,
            Photo = x.Photo
        }).ToList();
    }
}