using System;
using System.Collections.Generic;

namespace PasswordValidator
{
    public class Password
    {
        private static List<String> passwords = new List<String>();
        public Password()
        {
            bool run = true;
            string password;
            do
            {
                bool valid = false;
                Console.Clear();
                do
                {
                    System.Console.Write("Password: ");
                    password = Console.ReadLine();
                    valid = passwordMeetsReqs(password, 8, 10, 1, 1, 1, 1);
                }
                while (!valid);
                System.Console.WriteLine("Password is valid!");
                passwords.Add(password);
                System.Console.WriteLine("\nContinue?");
                run = Console.ReadLine().ToLower().Trim() == "yes";
            }
            while (run);
        }
        public static void getPasswords()
        {
            System.Console.WriteLine("\nStored passwords:");
            passwords.ForEach(System.Console.WriteLine);
        }
        bool passwordMeetsReqs(string password, int minLength, int maxLength, int minInstancesOfNums, int minNumOfLower, int minNumOfUpper, int minNumOfSpecial)
        {
            bool valid = true;
            if (!hasNoWhiteSpaces(password))
            {
                valid = false;
            }
            if (!validLength(password, minLength, maxLength))
            {
                valid = false;
            }
            if (!hasNums(password, minInstancesOfNums))
            {
                valid = false;
            }
            if (!hasLowerCaseLetters(password, minNumOfLower))
            {
                valid = false;
            }
            if (!hasupperCaseLetters(password, minNumOfUpper))
            {
                valid = false;
            }
            if (!hasSpecialChars(password, minNumOfSpecial))
            {
                valid = false;
            }
            return valid;
        }
        bool hasSpecialChars(string password, int minNumOfSpecial)
        {
            char[] specialChars = { '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
            int instancesOfSpecial = 0;
            for (int i = 0; i < password.Length; i++)
            {
                foreach (char ch in specialChars)
                {
                    if (password.Substring(i, 1).Equals(Convert.ToString(ch)))
                    {
                        instancesOfSpecial++;
                    }
                }
            }
            if (instancesOfSpecial < minNumOfSpecial)
            {
                System.Console.WriteLine("Password must contain at least {0} special characters!", minNumOfSpecial);
            }
            return (instancesOfSpecial >= minNumOfSpecial);
        }
        bool hasNoWhiteSpaces(string password)
        {
            bool valid = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i].Equals(" "))
                {
                    valid = false;
                    break;
                }
            }
            if (!valid)
            {
                System.Console.WriteLine("Password cannot contain white spaces!");
            }
            return valid;
        }
        bool validLength(string password, int minLength, int maxLength)
        {
            bool valid = false;
            if (password.Length < minLength)
            {
                System.Console.WriteLine("Password cannot have less than {0} characters!", minLength);
            }
            else if (password.Length > maxLength)
            {
                System.Console.WriteLine("Password cannot have more than {0} characters!", maxLength);
            }
            else
            {
                valid = true;
            }
            return valid;
        }
        bool hasupperCaseLetters(string password, int minNumOfUpper)
        {
            int instancesOfUpper = 0;
            string lower = password.ToLower();
            for (int i = 0; i < password.Length; i++)
            {
                if (!(password[i].Equals(lower[i])))
                {
                    instancesOfUpper++;
                }
            }
            if (instancesOfUpper < minNumOfUpper)
            {
                System.Console.WriteLine("Password must have at least {0} uppercase letters!", minNumOfUpper);
            }
            return (instancesOfUpper >= minNumOfUpper);
        }
        bool hasLowerCaseLetters(string password, int minNumOfLower)
        {
            int instancesOfLower = 0;
            string upper = password.ToUpper();
            for (int i = 0; i < password.Length; i++)
            {
                if (!(password[i].Equals(upper[i])))
                {
                    instancesOfLower++;
                }
            }
            if (instancesOfLower < minNumOfLower)
            {
                System.Console.WriteLine("Password must have at least {0} lowercase letters!", minNumOfLower);
            }
            return (instancesOfLower >= minNumOfLower);
        }
        bool hasNums(string password, int minInstancesOfNums)
        {
            int instancesOfNums = 0;
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (password.Substring(i, 1).Equals(Convert.ToString(j)))
                    {
                        instancesOfNums++;
                    }
                }
            }
            if (instancesOfNums < minInstancesOfNums)
            {
                System.Console.WriteLine("Password must have at least {0} numbers!", minInstancesOfNums);
            }
            return (instancesOfNums >= minInstancesOfNums);
        }
    }
}