namespace Application.Dtos;

public class TokenResponseDto
{
    public TokenResponseDto(string token, DateTime expireDate, Guid accountId, string accountsType, Guid id) 
    {
        Token = token;
        ExpireDate = expireDate;
        AccountId = accountId;
        AccountsType = accountsType;
        Id = id;
    }

    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public Guid AccountId { get; set; }
    public Guid Id { get; set; }
    public string AccountsType { get; set; }

}