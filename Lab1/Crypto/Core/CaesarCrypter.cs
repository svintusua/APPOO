namespace Core
{
    public class CaesarCrypter : AbstractCrypter
    {
        public CaesarCrypter() : base(false, false) {}

        public override string Encrypt(string text, AdditionalData data = null)
        {
            char[] encrypted = text.ToCharArray();
            
            for (var i = 0; i < encrypted.Length; i++)
            {
                encrypted[i] = (char) (encrypted[i] + 1);
            }
            return new string(encrypted);
        }

        public override string Decrypt(string encryptedText, AdditionalData data = null)
        {
            char[] decrypted = encryptedText.ToCharArray();

            for (var i = 0; i < decrypted.Length; i++)
            {
                decrypted[i] = (char)(decrypted[i] - 1);
            }
            return new string(decrypted);
        }
    }
}