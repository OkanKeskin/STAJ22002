using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.Form;

public class GetFormByCompanyIdQueryHandler : IRequestHandler<GetFormByCompanyIdQuery,List<GetFormQueryResult>>
{
    private readonly IRepository<Domain.Entities.Form> _repository;
    private readonly IRedisCacheServices _redisCacheServices;

    public GetFormByCompanyIdQueryHandler(IRepository<Domain.Entities.Form> repository,IRedisCacheServices redisCacheServices)
    {
        _repository = repository;
        _redisCacheServices = redisCacheServices;
    }
    
    public async Task<List<GetFormQueryResult>> Handle(GetFormByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilterListAsync(f=>f.CompanyId == request.CompanyId);

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