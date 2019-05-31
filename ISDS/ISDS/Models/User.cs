using System;
using System.Collections.Generic;
using System.Text;

namespace ISDS.Models
{
    public enum QuestionAnswers
    {
        Yes, No, Unknown
    }
    public class User
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public int Gender { get; set; }
        public string DateOfBirth { get; set; }
        public QuestionAnswers Smoker { get; set; }
        public QuestionAnswers Pressuer { get; set; }
        public QuestionAnswers Diabetes { get; set; }

        public DateTime LastLogin { get; set; }
        public DateTime AccessTokenExpiresIn { get; set; }
        public string AccessToken { get; set; }
    }
}
