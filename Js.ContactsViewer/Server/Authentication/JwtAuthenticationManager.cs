using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Js.ContactsViewer.Server.Authentication;

public class JwtAuthenticationManager
{
    public const string JWT_SECURITY_KEY = "bardzomocnesecurityJK@MODM)(@*!DJ*(@Y!#(*Y";
    private const int JWT_TOKEN_VALIDITY_MINS = 30;
    private readonly UserAccountService _userAccountService;

    public JwtAuthenticationManager(UserAccountService userAccountService)
    {

        _userAccountService = userAccountService;
    }

    public UserSession? GenerateJwtToken(string userName, string password)
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            return null;

        var userAccount = _userAccountService.GetUserAccountByUserName(userName);
        if (userAccount == null || userAccount.Password != password)
            return null;


        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Role ,userAccount.Role.Name)
            });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);


        var securityTokenDescirptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescirptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);


        var userSession = new UserSession
        {
            UserName = userAccount.UserName,
            Role = userAccount.Role,
            Token = token,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
        };

        return userSession;
    }
}
