namespace Back_end.Data
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email);
    }
}