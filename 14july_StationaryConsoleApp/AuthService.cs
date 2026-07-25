namespace StationeryStoreApp
{
    /// <summary>
    /// Module 1: User Login.
    /// </summary>
    public static class AuthService
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "admin123";
        private const int MaxAttempts = 3;

        /// <summary>
        /// Prompts for username/password up to MaxAttempts times.
        /// Throws LoginFailedException once attempts are exhausted.
        /// </summary>
        public static void Login()
        {
            int attemptsLeft = MaxAttempts;

            while (attemptsLeft > 0)
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Password: ");
                string password = Console.ReadLine() ?? string.Empty;

                if (username == ValidUsername && password == ValidPassword)
                {
                    Console.WriteLine("Login Successful!");
                    return;
                }

                attemptsLeft--;
                Console.WriteLine("Invalid Login");
                Console.WriteLine($"Attempts Left : {attemptsLeft}");
            }

            throw new LoginFailedException();
        }
    }
}
