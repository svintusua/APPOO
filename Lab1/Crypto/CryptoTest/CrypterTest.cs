using System;
using Core;

namespace CryptoTest
{
    public class CrypterTest : ICrypter
    {
        public string Encrypt(string text, string codeWord, string dictionary)
        {
            string encrypted = null;
            Console.Write("1-");
            if (text.Length != 0)
            {
                Console.Write("2-");
                if (codeWord.Length != 0)
                {
                    Console.Write("3-");
                    if (InDictionary(text, codeWord, dictionary))
                    {
                        Console.Write("4-");
                        if (codeWord.Length != text.Length)
                        {
                            Console.Write("5-");
                            codeWord = ResizeCodeWord(codeWord, text.Length);
                        }
                        Console.Write("6-");
                        var tmp = new char[text.Length];
                        for (var i = 1; i <= text.Length; i++)
                        {
                            Console.Write("7-");
                            var index = (IndexOf(text[i - 1], dictionary) + IndexOf(codeWord[i - 1], dictionary)) % dictionary.Length;
                            tmp[i - 1] = dictionary[index];
                            Console.Write("6-");
                        }
                        encrypted = new string(tmp);
                        Console.Write("8-");
                    }
                    Console.Write("9-");
                }
                Console.Write("10-");
            }
            Console.Write("11");
            return encrypted;
        }

        public string Decrypt(string encryptedText, string codeWord, string dictionary)
        {
            return string.Empty;
        }

        private bool InDictionary(string text, string codeWord, string dictionary)
        {
            foreach (var ch in text)
            {
                if (IndexOf(ch, dictionary) < 0)
                {
                    return false;
                }
            }
            foreach (var ch in codeWord)
            {
                if (IndexOf(ch, dictionary) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int IndexOf(char c, string dictionary)
        {
            var index = dictionary.IndexOf(c);
            return index;
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

    public class CrypterTest2 : ICrypter
    {
        public string Encrypt(string text, string codeWord, string dictionary)
        {
            var encrypted = "";
            if (text.Length != 0)
            {
                if (codeWord.Length != 0)
                {
                    if (InDictionary(text, codeWord, dictionary))
                    {
                        if (codeWord.Length != text.Length)
                        {
                            codeWord = ResizeCodeWord(codeWord, text.Length);
                        }
                        var tmp = new char[text.Length];
                        for (var i = 1; i <= text.Length; i++)
                        {
                            var index = (IndexOf(text[i - 1], dictionary) + IndexOf(codeWord[i - 1], dictionary)) % dictionary.Length;
                            tmp[i - 1] = dictionary[index];
                        }
                        encrypted = new string(tmp);
                    }
                }
            }
            return encrypted;
        }

        public string Decrypt(string encryptedText, string codeWord, string dictionary)
        {
            return string.Empty;
        }

        private bool InDictionary(string text, string codeWord, string dictionary)
        {
            foreach (var ch in text)
            {
                if (IndexOf(ch, dictionary) < 0)
                {
                    return false;
                }
            }
            foreach (var ch in codeWord)
            {
                if (IndexOf(ch, dictionary) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int IndexOf(char c, string dictionary)
        {
            var index = dictionary.IndexOf(c);
            return index;
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
