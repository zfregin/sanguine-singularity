using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BankConsole
{
    static class UserLogin
    {
        // Create Account
        public static void CreateAccount(Dictionary<string, User> users)
        {
            // List to hold username and password inputs
            List<string> login = new List<string>();
            Console.WriteLine();
            UsernameInput:
            Console.WriteLine("Creating Account - Enter 'quit' to cancel at any time");
            Console.WriteLine("Enter new username: ");
            string newUserID = Console.ReadLine();
            int idLength = newUserID.Length;
            Console.WriteLine();
            
            if (newUserID == "quit")
            {
                return;
            }
            // Validate username for length and special characters
            else if (!Regex.IsMatch(newUserID, "^[a-zA-Z0-9 ]+$") || idLength < 6)
            {
                Console.WriteLine("Please enter a valid username. Username must be 6 or more characters long and contain alphanumeric characters only.");
                Console.WriteLine();
                // Direct back to input when username invalid
                goto UsernameInput;
            }
            // Check if username available
            else if (users.ContainsKey(newUserID))
            {
                Console.WriteLine("Username already exists. Please try again.");
                goto UsernameInput;
            }
            
            else
            {
                PasswordInput:
                Console.WriteLine("Enter new password: ");
                string newUserPW = Console.ReadLine();
                int pwLength = newUserPW.Length;
                Console.WriteLine();
                if (newUserPW == "quit")
                {
                    return;
                }
                // Validate password for length
                else if (pwLength < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long. Please try again.");
                    // Direct back to input when password invalid
                    goto PasswordInput;
                }
                else
                {
                    // Create new User object and add to users dictionary
                    User _user1 = new User() { Username = newUserID, Password = newUserPW };
                    users.Add(newUserID, _user1);
                    Console.Clear();
                    // Indicate user success
                    Console.WriteLine("Account created. Please log in");
                }
            }
        }

        // Log in
        public static void Login(Dictionary<string, User> users, ref Boolean loginStatus, ref User user)
        {
            // Hold login inputs
            List<String> loginCredentials = new List<string>();
            Console.WriteLine();
            Console.WriteLine("Please enter your username: ");
            loginCredentials.Add(Console.ReadLine());
            Console.WriteLine();
            // Check if username exists
            if (!users.ContainsKey(loginCredentials[0]))
            {
                Console.Clear();
                Console.WriteLine("That is not a valid username. Please try again");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Please enter your password: ");
                loginCredentials.Add(Console.ReadLine());
                Console.WriteLine();
                // Check for correct password to user account
                if (users[loginCredentials[0]].Password == loginCredentials[1])
                {
                    Console.Clear();
                    Console.WriteLine("Login Successful");
                    Console.WriteLine();
                    user = users[loginCredentials[0]];
                    loginStatus = true;
                }
                // Indicate failure
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid username/password combination. Please try again");
                    Console.WriteLine();
                }
            }
        }

        // Log out
        public static void Logout(ref Boolean loginStatus, ref User _user)
        {
            // Set current working profile back to null
            _user = null;
            // Set status back to logged out
            loginStatus = false;
            Console.Clear();
        }
    }
}
