using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoTest
{
    [TestClass]
    public class EncryptTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICrypter crypter = new CrypterTest();
            const string dictionary = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var text = "";
            var codeWord = "ABCD";
            string encrypted;

            Console.WriteLine("ТВ 1:	Исходные данные: text – пустая строка, codeWord – любой.");
            Console.WriteLine("Ожидаемый результат: encrypted = пустая строка – невозможно преобразовать.");
            Console.Write("Путь: ");
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(encrypted = crypter.Encrypt(text, codeWord, dictionary)));
            Console.WriteLine();
            Console.WriteLine($"text='{text}'");
            Console.WriteLine($"codeWord='{codeWord}'");
            Console.WriteLine($"Результат='{encrypted}'");
            Console.WriteLine();

            text = "ABCD";
            codeWord = "";

            Console.WriteLine("ТВ 2: 	Исходные данные: text - любой, codeWord – пустая строка.");
            Console.WriteLine("Ожидаемый результат: encrypted = пустая строка – невозможно преобразовать.");
            Console.Write("Путь: ");
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(encrypted = crypter.Encrypt(text, codeWord, dictionary)));
            Console.WriteLine();
            Console.WriteLine($"text='{text}'");
            Console.WriteLine($"codeWord='{codeWord}'");
            Console.WriteLine($"Результат='{encrypted}'");
            Console.WriteLine();

            text = "anv";
            codeWord = "abaf";

            Console.WriteLine("ТВ 3:	Исходные данные: text или/ и codeWord содержат символы, отсутствующие в словаре.");
            Console.WriteLine("Ожидаемый результат: encrypted = пустая строка – невозможно преобразовать.");
            Console.Write("Путь: ");
            Assert.AreEqual(true, string.IsNullOrWhiteSpace(encrypted = crypter.Encrypt(text, codeWord, dictionary)));
            Console.WriteLine();
            Console.WriteLine($"text='{text}'");
            Console.WriteLine($"codeWord='{codeWord}'");
            Console.WriteLine($"Результат='{encrypted}'");
            Console.WriteLine();

            text = "ABCD";
            codeWord = "ABCD";

            Console.WriteLine("ТВ 4:	Исходные данные: text = непустая строка, codeWord = непустая строка той же длины.");
            Console.WriteLine("Ожидаемый результат: encrypted = зашифрованная строка – успешное преобразование.");
            Console.Write("Путь: ");
            Assert.AreEqual(true, !string.IsNullOrWhiteSpace(encrypted = crypter.Encrypt(text, codeWord, dictionary)));
            Console.WriteLine();
            Console.WriteLine($"text='{text}'");
            Console.WriteLine($"codeWord='{codeWord}'");
            Console.WriteLine($"Результат='{encrypted}'");
            Console.WriteLine();


            text = "ABCD";
            codeWord = "AB";

            Console.WriteLine("ТВ 5: 	Исходные данные: text = непустая строка, codeWord = непустая строка отличной от текста длины.");
            Console.WriteLine("Ожидаемый результат: encrypted=зашифрованная строка – успешное преобразование.");
            Console.Write("Путь: ");
            Assert.AreEqual(true, !string.IsNullOrWhiteSpace(encrypted = crypter.Encrypt(text, codeWord, dictionary)));
            Console.WriteLine();
            Console.WriteLine($"text='{text}'");
            Console.WriteLine($"codeWord='{codeWord}'");
            Console.WriteLine($"Результат='{encrypted}'");
            Console.WriteLine();
        }
    }
}
