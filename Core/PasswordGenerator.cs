using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGen
    {
        public static string GenerateStrongPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            using (var rng = new RNGCryptoServiceProvider())
            {
                var passwordChars = new char[length];
                byte[] data = new byte[length];
                rng.GetBytes(data);
                for (int i = 0; i < length; i++)
                {
                    passwordChars[i] = validChars[data[i] % validChars.Length];
                }
                return new string(passwordChars);
            }
        }

        public static bool EvaluatePasswordStrength(string password)
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasNumbers = false;
            bool hasSymbols = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                else if (char.IsLower(c)) hasLowerCase = true;
                else if (char.IsDigit(c)) hasNumbers = true;
                else if (!char.IsLetterOrDigit(c)) hasSymbols = true;
            }

            return password.Length >= 8 && hasUpperCase && hasLowerCase && hasNumbers && hasSymbols;
        }
    }
}