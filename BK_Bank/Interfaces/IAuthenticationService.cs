namespace BK_Bank.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string pin);
        Task LogoutAsync();
        Task<bool> IsLoggedInAsync();
        Task<User?> GetUserAsync();
        event Action? OnAuthStateChanged;
    }
}
