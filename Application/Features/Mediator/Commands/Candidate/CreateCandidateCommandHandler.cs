using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand,Guid>
{

    private readonly IRepository<Domain.Entities.Candidate> _userRepository;
    
    public CreateCandidateCommandHandler(IRepository<Domain.Entities.Candidate> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.Candidate
        {
            Surname = request.Surname,
            PhoneNumber = request.PhoneNumber,
            Name = request.Name,
            Email = request.Email,
            AccountsId = request.AccountsId,
            Image = null
        };

        await _userRepository.CreateAsync(user);

        return user.Id;
    }
}