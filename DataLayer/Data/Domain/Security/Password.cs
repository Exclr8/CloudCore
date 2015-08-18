using System;
using System.Security;
using System.Text.RegularExpressions;


namespace CloudCore.Domain.Security
{
    public class Password
    {
        private readonly string password;

        public Password(string password)
        {
            this.password = password;
        }

        private static string CreateSalt(int userId)
        {
            string stuff = userId + "_____";
            stuff = stuff.Substring(0, 5);
            return stuff;
        }

        public string CreatePasswordHash(int userid)
        {
            return GetPasswordHash(CreateSalt(userid));
        }

        public static string CreatePasswordHash(int userid, string password)
        {
            var pword = new Password(password);
            return pword.CreatePasswordHash(userid);
        }

        private string GetPasswordHash(string salt)
        {
            string saltAndPwd = String.Concat(password, salt);
            return String.Concat(Hash.Calculate(saltAndPwd), salt);
        }

        public bool Compare(int userId, string expectedPasswordHash)
        {
            if (expectedPasswordHash.Length > 5)
            {
                string hashedPasswordAndSalt = GetPasswordHash(CreateSalt(userId));
                if (hashedPasswordAndSalt.Equals(expectedPasswordHash))
                    return (userId > 0);
                else
                    return false;
            }
            else
              return false;
        }

        public bool IsPasswordStrong()
        {
            // TODO: use dictionary of weak passwords
            if (password.ToLower().Equals("password"))
                return false;
            
            // TODO: Write more specific tests for this...
            //At least 7 chars
            //At least 1 uppercase char (A-Z)
            //At least 1 number (0-9)
            //At least one special char
            return Regex.IsMatch(password, @"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$");
        }
    }
}