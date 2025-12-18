namespace BK_Bank.Domain
{
    /// <summary>
    /// Represents the user of BK Bank.
    /// Contains authentication used for local login
    /// </summary>
    public class User
    {
        public string UserName { get; set; }
        public string Pin { get; set; }
        public User(string userName, string pin)
        {
            UserName = userName;
            Pin = pin;
        }
    }
}
