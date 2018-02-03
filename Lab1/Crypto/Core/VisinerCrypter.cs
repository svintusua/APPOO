using System;

namespace Core
{
    public class VisinerCrypter : AbstractCrypter
    {
        public VisinerCrypter() : base(true, true) {}

        public override string Encrypt(string text, AdditionalData data = null)
        {
            if (!(data is VisinerData vData))
            {
                throw new ArgumentException("Неверный параметр", nameof(data));
            }

            char[] encrypted = text.ToCharArray();
            var codeWord = new string(vData.Codeword.ToCharArray());
            var dictionary = vData.Dictionary;

            if (vData.Codeword.Length != text.Length)
            {
                codeWord = ResizeCodeWord(codeWord, text.Length);
            }

            for (var i = 0; i < encrypted.Length; i++)
            {
                var index = (dictionary.IndexOf(text[i]) + dictionary.IndexOf(codeWord[i])) % dictionary.Length;
                encrypted[i] = dictionary.AtIndex(index);
            }
            return new string(encrypted);
        }

        public override string Decrypt(string encryptedText, AdditionalData data = null)
        {
            if (!(data is VisinerData vData))
            {
                throw new ArgumentException("Неверный параметр", nameof(data));
            }

            char[] decrypted = encryptedText.ToCharArray();
            var codeWord = new string(vData.Codeword.ToCharArray());
            var dictionary = vData.Dictionary;

            if (codeWord.Length != encryptedText.Length)
            {
                codeWord = ResizeCodeWord(codeWord, encryptedText.Length);
            }

            for (var i = 0; i < decrypted.Length; i++)
            {
                var index = (dictionary.IndexOf(encryptedText[i]) - dictionary.IndexOf(codeWord[i]) + dictionary.Length) % dictionary.Length;
                decrypted[i] = dictionary.AtIndex(index);
            }
            return new string(decrypted);
        }

        private static string ResizeCodeWord(string codeWord, int size)
        {
            var repeats = size / codeWord.Length;
            var resizedCodeWord = codeWord.Substring(0);
            for (var i = 0; i < repeats; i++)
                resizedCodeWord += codeWord;
            return resizedCodeWord.Substring(0, size);
        }
    }
}