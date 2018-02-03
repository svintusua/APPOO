namespace Core
{
    public abstract class AbstractCrypter
    {
        public readonly bool UsesCodeword;
        public readonly bool UsesDictionary;

        protected AbstractCrypter(bool usesCodeword, bool usesDictionary)
        {
            UsesCodeword = usesCodeword;
            UsesDictionary = usesDictionary;
        }

        public abstract string Encrypt(string textToEncrypt, AdditionalData data = null);
        public abstract string Decrypt(string encryptedText, AdditionalData data = null);
    }
}