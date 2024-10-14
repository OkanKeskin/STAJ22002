using Application.Features.Mediator.Commands.Account;
using Application.Features.Mediator.Commands.Company;
using Application.Features.Mediator.Commands.Queue;
using Application.Features.Mediator.Commands.User;
using Application.Features.Mediator.Queries;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Modals;

namespace WebApi.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("kuyruk")]
    public async Task<IActionResult> Test(QueueCommand command)
    {
        await _mediator.Send(command);
        
        return Ok("ASD");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]GetCheckAccountQuery query)
    {
        var values = await _mediator.Send(query);
        if (values.IsExist)
        {
            return Created("", JwtTokenGenerator.GenerateToken(values));
        }
        else
        {
            return BadRequest("Email veya Şifre hatalıdır");
        }
    }
    
    [HttpPost("company")]
    public async Task<IActionResult> RegisterCompany([FromBody]CompanyRegisterModel query)
    {
        var createAcc = new CreateAccountCommand
        {
            Password = query.Password,
            Email = query.Email,
            Type = Domain.Enums.AccountsType.Company
        };
        var res = await _mediator.Send(createAcc);

        var createCom = new CreateCompanyCommand
        {
            AccountsId = res,
            CompanyName = query.CompanyName,
            Email = query.Email,
            PhoneNumber = query.PhoneNumber,
        };
        var co = await _mediator.Send(createCom);

        return Ok(co);
    }
    
    [HttpPost("customer")]
    public async Task<IActionResult> RegisterCandidate([FromBody]CandidateRegisterModel query)
    {
        //coustomer Oluştur
        //Account Oluştur
        var createAcc = new CreateAccountCommand
        {
            Password = query.Password,
            Email = query.Email,
            Type = Domain.Enums.AccountsType.Candidate
        };
        var res = await _mediator.Send(createAcc);

        var createCus = new CreateCandidateCommand
        {
            AccountsId = res,
            Email = query.Email,
            Name = query.Name,
            PhoneNumber = query.PhoneNumber,
            Surname = query.Surname,
        };
        var cus = await _mediator.Send(createCus);

        return Ok(cus);
    }
}