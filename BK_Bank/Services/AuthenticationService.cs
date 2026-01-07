namespace BK_Bank.Services
{
    /// <summary>
    /// Provides methods for handling user authentication, including login, logout, and retrieving the current user.
    /// Manages authentication state and user data using the IStorageService.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private bool _isLoggedIn;
        private User? _currentUser;

        private readonly User _defaultUser = new("27237");

        public event Action? OnAuthStateChanged;

        // Initialize the authentication service and log that it has started
        public AuthenticationService()
        {
            Console.WriteLine("AuthenticationService INFO: AuthenticationService initialized.");
        }

        // Attempt to log in using provided credentials and store user data if successful
        public Task<bool> LoginAsync(string pin)
        {
            Console.WriteLine($"AuthenticationService INFO: Attempting login user.");
            if (pin == _defaultUser.Pin)
            {
                _isLoggedIn = true;
                _currentUser = _defaultUser;
                OnAuthStateChanged?.Invoke();
                return Task.FromResult(true);
            }
            Console.WriteLine("AuthenticationService INFO: Login failed. Invalid username or PIN.");
            return Task.FromResult(false);
        }

        // Log out the current user and clear stored authentication data
        public Task LogoutAsync()
        {
            Console.WriteLine("AuthenticationService INFO: Logging out user.");
            _isLoggedIn = false;
            _currentUser = null;
            OnAuthStateChanged?.Invoke();
            return Task.CompletedTask;
        }

        // Check if a user is currently logged in based on stored authentication state
        public Task<bool> IsLoggedInAsync()
        {
            return Task.FromResult(_isLoggedIn);
        }

        // Retrieve the currently logged-in user's data from storage
        public Task<User?> GetUserAsync()
        {
            return Task.FromResult(_currentUser);
        }
    }
}
