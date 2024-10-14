using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos;
using Application.Features.Mediator.Queries;
using Microsoft.IdentityModel.Tokens;

namespace Application.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(GetCheckAccountQueryResults result)
    {
        var claims = new List<Claim>();
        if(!string.IsNullOrWhiteSpace(result.Type.ToString()))
            claims.Add(new Claim(ClaimTypes.Role, result.Type.ToString()));

        claims.Add(new Claim(ClaimTypes.NameIdentifier, result.UserID.ToString()));

        if (!string.IsNullOrWhiteSpace(result.Email))
            claims.Add(new Claim("Email",result.Email));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

        var signinCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

        JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidAudience,
            claims: claims, notBefore: DateTime.UtcNow, expires: expireDate,
            signingCredentials: signinCredentials);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate, result.UserID,result.Type.ToString(), result.Id);
    }


}