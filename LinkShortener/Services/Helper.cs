using LinkShortener.Interfaces;
using System.Text;

namespace LinkShortener.Services;

public class Helper : IHelper
{
    public string GenerateRandomString()
    {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            return sb.ToString();
    }
}
