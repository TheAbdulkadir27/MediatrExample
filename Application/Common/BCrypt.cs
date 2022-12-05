using AdminKayıt;
using System;

namespace Application.Common
{
    public class BCrypts : ICryPts
    {
        public string Hasher(string Password)
        {
            Random random = new Random();
            var value = random.Next(1000000);
            return BCrypt.Net.BCrypt.HashPassword(value.ToString() + Password, BCrypt.Net.BCrypt.GenerateSalt());
        }
    }
}
