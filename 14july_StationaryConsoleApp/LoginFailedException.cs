namespace StationeryStoreApp
{
    /// <summary>
    /// Thrown when the user exceeds the maximum number of allowed login attempts.
    /// </summary>
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base("Login failed: maximum attempts exceeded.") { }

        public LoginFailedException(string message) : base(message) { }
    }
}
