namespace CarPoolingAPI.Services;

public class AuthenticationService
{
    private readonly TokenService _tokenService;

    public AuthenticationService(TokenService tokenService)
    {
        _tokenService = tokenService;
    }
}