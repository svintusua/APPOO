using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoTest
{
    [TestClass]
    public class EncryptTest2
    {
        private ICrypter _crypter;
        private SymbolDictionary _dictionary;

        [TestInitialize]
        public void Init()
        {    
            _crypter = new CrypterTest2();
            _dictionary = new SymbolDictionary();
        }

        [TestMethod]
        public void AllParamertersRight()
        {
            var text = "HELLO";
            var codeWord = "TVPP";

            var res = _crypter.Encrypt(text, codeWord, _dictionary.Content);

            Assert.AreEqual("AZAAH", res);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Code word: {codeWord}");
            Console.WriteLine($"Result: {res}");
        }

        [TestMethod]
        public void TextIsEmpty()
        {
            var text = "";
            var codeWord = "TVPP";

            var res = _crypter.Encrypt(text, codeWord, _dictionary.Content);

            Assert.AreEqual("", res);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Code word: {codeWord}");
            Console.WriteLine($"Result: {res}");
        }

        [TestMethod]
        public void CodeWordIsEmpty()
        {
            var text = "hello";
            var codeWord = "TVPP";

            var res = _crypter.Encrypt(text, codeWord, _dictionary.Content);

            Assert.AreEqual("", res);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Code word: {codeWord}");
            Console.WriteLine($"Result: {res}");
        }

        [TestMethod]
        public void TextHasUnsuportedCharacters()
        {
            var text = "HELLO";
            var codeWord = "world";

            var res = _crypter.Encrypt(text, codeWord, _dictionary.Content);

            Assert.AreEqual("", res);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Code word: {codeWord}");
            Console.WriteLine($"Result: {res}");
        }

        [TestMethod]
        public void CodeWordHasUnsuportedCharacters()
        {
            var text = "HELLO";
            var codeWord = "";

            var res = _crypter.Encrypt(text, codeWord, _dictionary.Content);

            Assert.AreEqual("", res);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Code word: {codeWord}");
            Console.WriteLine($"Result: {res}");
        }
    }
}
