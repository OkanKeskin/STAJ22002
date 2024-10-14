using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.Form;

public class GetFormByIdQueryHandler : IRequestHandler<GetFormByIdQuery,GetFormQueryResult>
{
    private readonly IRepository<Domain.Entities.Form> _repository;

    public GetFormByIdQueryHandler(IRepository<Domain.Entities.Form> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetFormQueryResult> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var x = await _repository.GetByIdAsync(request.Id);

        return new GetFormQueryResult
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
        };
    }
}