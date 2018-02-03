using System;

namespace Core
{
    public class VisinerData : AdditionalData
    {
        public SymbolDictionary Dictionary { get; }
        public string Codeword { get; }

        public VisinerData(string codeword, SymbolDictionary dictionary)
        {
            Codeword = codeword ?? throw new ArgumentNullException(nameof(codeword));
            Dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }
    }
}
