using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Core;

namespace Crypto
{
    public partial class MainWindow : Window
    {
        private AbstractCrypter _currentCrypter;
        private AdditionalData _additionalData;
        private readonly SymbolDictionary _dictionary;

        public MainWindow()
        {
            InitializeComponent();

            _dictionary = new SymbolDictionary();
  
            SymbolDictionary.Text = _dictionary.Content;
            VisinerRadioButton.IsChecked = true;
            EncryptionTab.Focus();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptionError.Content = "";
            EncryptionError.Visibility = Visibility.Hidden;
            EncryptedText.Text = "";

            var text = TextToEncrypt.Text;

            if (UpdateData(text, true))
            {
                var encryptedText = _currentCrypter.Encrypt(text, _additionalData);
                EncryptedText.Text = encryptedText;
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            DecryptionError.Content = "";
            DecryptionError.Visibility = Visibility.Hidden;
            DecryptedText.Text = "";

            var text = TextToDecrypt.Text;

            if (UpdateData(text, false))
            {
                var decryptedText = _currentCrypter.Decrypt(text, _additionalData);
                DecryptedText.Text = decryptedText;
            }
        }

        private void SymbolDictionary_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _dictionary.Content = SymbolDictionary.Text;
            SymbolDictionary.Text = _dictionary.Content;
        }

        private void ClearEncryptionTextButton_OnClick(object sender, RoutedEventArgs e)
        {
            TextToEncrypt.Text = "";
        }

        private void ClearEncryptionCodeWordButton_OnClick(object sender, RoutedEventArgs e)
        {
            EncryptionCodeWord.Text = "";
        }

        private void ClearAllEncryptionButton_OnClick(object sender, RoutedEventArgs e)
        {
            EncryptionError.Content = "";
            EncryptionError.Visibility = Visibility.Hidden;

            EncryptedText.Text = "";
            EncryptionCodeWord.Text = "";
            TextToEncrypt.Text = "";
        }

        private void ClearDecryptionTextButton_OnClick(object sender, RoutedEventArgs e)
        {
            TextToDecrypt.Text = "";
        }

        private void ClearDecryptionCodeWordButton_OnClick(object sender, RoutedEventArgs e)
        {
            DecryptionCodeWord.Text = "";
        }

        private void ClearAllDecryptionButton_OnClick(object sender, RoutedEventArgs e)
        {
            DecryptionError.Content = "";
            DecryptionError.Visibility = Visibility.Hidden;

            DecryptedText.Text = "";
            DecryptionCodeWord.Text = "";
            TextToDecrypt.Text = "";
        }

        private void VisinerRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _currentCrypter = new VisinerCrypter();

            UpdateVisibility();
        }

        private void CaesarRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _currentCrypter = new CaesarCrypter();

            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            EncryptionCodeWord.IsEnabled = _currentCrypter.UsesCodeword;
            DecryptionCodeWord.IsEnabled = _currentCrypter.UsesCodeword;

            DictionaryTab.IsEnabled = _currentCrypter.UsesDictionary;
        }

        private bool UpdateData(string text, bool encryption)
        {
            if (string.IsNullOrEmpty(text))
            {
                EncryptionError.Visibility = Visibility.Visible;
                EncryptionError.Content = Constants.TextNullError;
                return false;
            }

            if (VisinerRadioButton.IsChecked ?? true)
            {
                var codeWord = encryption ? EncryptionCodeWord.Text : DecryptionCodeWord.Text;

                if (string.IsNullOrEmpty(codeWord))
                {
                    DecryptionError.Visibility = Visibility.Visible;
                    DecryptionError.Content = Constants.CodeWordNullError;
                    return false;
                }
                if (!_dictionary.ContainsAll(text) || !_dictionary.ContainsAll(codeWord))
                { 
                    var absentSymbols = _dictionary.AbsentSymbols(text) + _dictionary.AbsentSymbols(codeWord);
                    absentSymbols = new string(absentSymbols.Distinct().OrderBy(x => x).ToArray());

                    EncryptionError.Visibility = Visibility.Visible;
                    EncryptionError.Content = $"{Constants.AbsentSymbolsError} '{absentSymbols}'";

                    return false;
                }

                _additionalData = new VisinerData(codeWord, _dictionary);
            }
            else if (CaesarRadioButton.IsChecked ?? true)
            {
                _additionalData = new AdditionalData();
            }

            return true;
        }
    }
}