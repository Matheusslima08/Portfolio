﻿using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace Domain.Extensions
{
    public static class StringExtension
    {
        public static string Capitalize(this String str)
        {
            string first = str.Substring(0, 1);

            string rest = str.Substring(1);

            return $"{first.ToUpper()}{rest}";
        }

        public static bool ToInteger(this String str, out int result)
        {
            bool success = Int32.TryParse(str, out result);
            return success;
        }

        public static bool ToLong(this String str, out long result)
        {
            bool success = Int64.TryParse(str, out result);
            return success;
        }
        public static string LimitStringLength(this String str, int Limit)
        {
            if (Limit > str.Length)
                return str;

            return str.Substring(0, Limit);
        }

        public static string ToSHA256(this String str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Convert byte to hexadecimal string
                }
                return builder.ToString();
            }
        }

        public static string ToBase64(this String str)
        {
            try
            {
                byte[] textoAsBytes = UTF8Encoding.UTF8.GetBytes(str);
                string resultado = Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw new Exception("Error converting to base64");
            }
        }

        public static string FromBase64(this String str)
        {
            try
            {
                byte[] textoAsBytes = Convert.FromBase64String(str);
                string resultado = UTF8Encoding.UTF8.GetString(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw new Exception("Error converting from base64");
            }
        }

        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public static T? ToObject<T>(this String str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
