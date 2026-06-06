using System;
using System.Text.RegularExpressions;

namespace LifeFlowBBMS.DAL
{
    /// <summary>
    /// Input validation helper class for ensuring data integrity and security
    /// </summary>
    public static class InputValidator
    {
        // Email regex pattern (RFC 5322 simplified)
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Phone regex pattern (international formats)
        private static readonly Regex PhoneRegex = new Regex(
            @"^[+]?[\d\s\-\(\)]{7,}$",
            RegexOptions.Compiled);

        // Valid blood group types
        private static readonly string[] ValidBloodGroups = 
        { 
            "O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-" 
        };

        // ─────────────────────────────────────────────────
        //  VALIDATE EMAIL
        // ─────────────────────────────────────────────────
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true; // Optional field

            if (email.Length > 254)
                return false;

            return EmailRegex.IsMatch(email);
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE PHONE
        // ─────────────────────────────────────────────────
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Optional field

            if (phone.Length > 20)
                return false;

            return PhoneRegex.IsMatch(phone);
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE AGE
        // ─────────────────────────────────────────────────
        public static bool IsValidAge(int age)
        {
            // Valid donor age range: 18-75 years
            return age >= 18 && age <= 75;
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE BLOOD GROUP
        // ─────────────────────────────────────────────────
        public static bool IsValidBloodGroup(string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(bloodGroup))
                return false;

            foreach (var group in ValidBloodGroups)
            {
                if (group.Equals(bloodGroup, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE DATE OF BIRTH
        // ─────────────────────────────────────────────────
        public static bool IsValidDateOfBirth(DateTime dob)
        {
            // DOB must be in the past
            if (dob >= DateTime.Now.Date)
                return false;

            // DOB must not be more than 120 years ago
            int age = DateTime.Now.Year - dob.Year;
            if (dob.Date > DateTime.Now.AddYears(-age))
                age--;

            if (age < 0 || age > 120)
                return false;

            return true;
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE LAST DONATION DATE
        // ─────────────────────────────────────────────────
        public static bool IsValidLastDonationDate(DateTime lastDonation)
        {
            // Cannot be in the future
            if (lastDonation > DateTime.Now.Date)
                return false;

            // Cannot be too far in the past (before 2000)
            if (lastDonation.Year < 2000)
                return false;

            return true;
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE BLOOD UNITS (QUANTITY)
        // ─────────────────────────────────────────────────
        public static bool IsValidBloodUnits(int units)
        {
            // Units must be positive
            // Reasonable maximum: 10000 units per blood type at once
            return units > 0 && units <= 10000;
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE FULL NAME
        // ─────────────────────────────────────────────────
        public static bool IsValidFullName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (name.Length < 2 || name.Length > 100)
                return false;

            // Allow letters, spaces, hyphens, apostrophes
            var nameRegex = new Regex(@"^[a-zA-Z\s\-']+$");
            return nameRegex.IsMatch(name.Trim());
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE CITY
        // ─────────────────────────────────────────────────
        public static bool IsValidCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return true; // Optional field

            if (city.Length < 2 || city.Length > 50)
                return false;

            // Allow letters, spaces, hyphens
            var cityRegex = new Regex(@"^[a-zA-Z\s\-']+$");
            return cityRegex.IsMatch(city.Trim());
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE ADDRESS
        // ─────────────────────────────────────────────────
        public static bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return true; // Optional field

            if (address.Length < 5 || address.Length > 200)
                return false;

            // Allow alphanumeric, spaces, commas, hyphens, periods, slashes
            var addressRegex = new Regex(@"^[a-zA-Z0-9\s,\-./]+$");
            return addressRegex.IsMatch(address.Trim());
        }

        // ─────────────────────────────────────────────────
        //  SANITIZE STRING INPUT
        // ─────────────────────────────────────────────────
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input.Trim();
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE USERNAME
        // ─────────────────────────────────────────────────
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (username.Length < 3 || username.Length > 50)
                return false;

            // Allow letters, numbers, underscores, dots
            var usernameRegex = new Regex(@"^[a-zA-Z0-9_.]+$");
            return usernameRegex.IsMatch(username);
        }

        // ─────────────────────────────────────────────────
        //  VALIDATE PASSWORD STRENGTH
        // ─────────────────────────────────────────────────
        public static (bool IsValid, string Message) ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return (false, "Password cannot be empty.");

            if (password.Length < 8)
                return (false, "Password must be at least 8 characters long.");

            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"[\d]");
            bool hasSpecial = Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':"",.\<>?/\\|`~]");

            if (!hasUpper)
                return (false, "Password must contain at least one uppercase letter.");

            if (!hasLower)
                return (false, "Password must contain at least one lowercase letter.");

            if (!hasDigit)
                return (false, "Password must contain at least one digit.");

            if (!hasSpecial)
                return (false, "Password must contain at least one special character.");

            return (true, "Password is strong.");
        }
    }
}
