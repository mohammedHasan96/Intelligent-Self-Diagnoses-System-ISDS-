using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace System
{
    public static class Extentions
    {
        public static void ReFill<T>(this ICollection<T> collection, IEnumerable<T> list)
        {
            collection.Clear();
            foreach (var item in list)
                collection.Add(item);
        }

        public static string Sha1Hash(this string pass)
        {
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static bool IsNull(this String str)
            => String.IsNullOrWhiteSpace(str);
    }

    public static class Values
    {
        public static string DBLocation     { get; set; }        = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ISDS.db3");
        public static string AccessToken    { get; set; }


        public const string APIIndex         =      "http://mohammedshoubaki-001-site1.itempurl.com/Diseases";
        public const string APIDetailsAll    =      "http://mohammedshoubaki-001-site1.itempurl.com/Diseases/DetailsAll";
        public const string APIDetails       =      "http://mohammedshoubaki-001-site1.itempurl.com/Diseases/Details/";
        public const string APILogin         =      "http://mohammedshoubaki-001-site1.itempurl.com/Users/Login";
        public const string APISymptoms      =      "http://mohammedshoubaki-001-site1.itempurl.com/Diseases/Symptoms";
        public const string APIRelations     =      "http://mohammedshoubaki-001-site1.itempurl.com/Diseases/Relations";
        public const string APIPredict       =      "http://mohammedshoubaki-001-site1.itempurl.com/SymptomsChecker/Check";

        public const string StateSuccess     =      "Success";
        public const string StateFailed      =      "Failed";

        public const int CodeSuccess         =      1;
        public const int CodeFailed          =      0;
    }
}
