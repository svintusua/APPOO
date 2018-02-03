using System;
using Core;

namespace CryptoConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICrypter crypter = new DefaultCrypter();
            var text = "HEREAISAMYATEXTATOAENCODE";
            var codeWord = "CODEWORD";
            var encrypted = crypter.Encrypt(text, codeWord);
            var decrypted = crypter.Decrypt(encrypted, codeWord);

            Console.WriteLine("Text: " + text);
            Console.WriteLine("Word: " + codeWord);
            Console.WriteLine("Cryp: " + encrypted);
            Console.WriteLine("Decr: " + decrypted);
        }
    }
}