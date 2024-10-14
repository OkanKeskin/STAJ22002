﻿using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class CreateCandidateCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid AccountsId { get; set; }
}