using System;
using System.Linq;

namespace UtopiaCity.Utils
{
    public static class RandomUtil
    {
        private const string numbers = "0123456789";

        private static readonly Random random;

        static RandomUtil()
        {
            random = new Random();
        }

        public static string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(numbers, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GenerateRandomThreePointInteger()
        {
            var intVar = GenerateRandomString(50).Substring(0, 3);
            try
            {
                return int.Parse(intVar);
            }
            catch (FormatException)
            {

                throw;
            }
        }
    }
}
