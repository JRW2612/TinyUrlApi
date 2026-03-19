

using tinyUrl.Application.Contracts;

namespace tinyUrl.Infrastructure.Services
{
    public class Base62ShortCodeGenerator : IShortCodeGenerator
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random _random = new();

        public async Task<string> Generate(int length)
        {
            var chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = Alphabet[_random.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

    }
}
