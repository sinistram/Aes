using System;
using System.Linq;

namespace CryptoAes.CLI
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            if (args is null || args.Length < 4)
            {
                return -1;
            }

            try
            {
                if (args[0].Equals("decode"))
                {
                    var cipher = args[1].Split(',').Select(byte.Parse).ToArray();
                    var key = args[2].Split(',').Select(byte.Parse).ToArray();
                    var iv = args[3].Split(',').Select(byte.Parse).ToArray();

                    var result = Decryptor.DecryptAndGetBytes(cipher, key, iv);
                    Console.WriteLine(string.Join(", ", result));
                    return 0;
                }

                if (args[0].Equals("encode"))
                {
                    var original = args[1];
                    var key = args[2].Split(',').Select(byte.Parse).ToArray();
                    var iv = args[1].Split(',').Select(byte.Parse).ToArray();

                    var result = Encryptor.Encrypt(original, key, iv);
                    Console.WriteLine(string.Join(", ", result));
                    return 0;
                }

                Console.WriteLine("Wrong mode");
                return -1;
            }
            catch
            {
                Console.WriteLine("Wrong args");
                return -1;
            }
        }
    }
}
