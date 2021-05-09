namespace Back_end.Controllers
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email);
    }
}