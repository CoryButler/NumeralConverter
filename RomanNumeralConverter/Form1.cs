using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RomanNumeralConverter
{
    public partial class Form_numeralConverter : Form
    {
        public Form_numeralConverter()
        {
            InitializeComponent();
        }

        private void TextBox_roman_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[I|i|V|v|X|x|L|l|C|c|D|d|M|m|\b]")) { e.Handled = true; PlayErrorSound(); }
        }

        private void TextBox_arabic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]")) { e.Handled = true; PlayErrorSound(); }
        }

        private void TextBox_roman_KeyUp(object sender, KeyEventArgs e)
        {
            var insertionPoint = textBox_roman.SelectionStart;
            var currentLength = textBox_roman.Text.Length;
            if (NumeralConverter.IsValidRomanValue(textBox_roman.Text, checkBox_strictMode.Checked))
            {
                textBox_arabic.Text = NumeralConverter.RomanToArabic(textBox_roman.Text);
                if (!checkBox_strictMode.Checked) textBox_roman.Text = NumeralConverter.Roman;

                var newInsertionPoint = insertionPoint - (textBox_roman.Text.Length - currentLength);
                if (!checkBox_strictMode.Checked) newInsertionPoint--;
                if (newInsertionPoint < 0) newInsertionPoint += insertionPoint;
                textBox_roman.SelectionStart = insertionPoint;
            }
            else
            {
                textBox_roman.Text = NumeralConverter.Roman;
                PlayErrorSound();

                var newInsertionPoint = insertionPoint - (textBox_roman.Text.Length - currentLength) - 2;
                if (newInsertionPoint < 0) newInsertionPoint += insertionPoint;
                if (newInsertionPoint > textBox_roman.Text.Length) newInsertionPoint = textBox_roman.Text.Length;
                textBox_roman.SelectionStart = newInsertionPoint;
            }
        }

        private void TextBox_arabic_KeyUp(object sender, KeyEventArgs e)
        {
            if (NumeralConverter.IsValidArabicValue(textBox_arabic.Text))
            {
                textBox_roman.Text = NumeralConverter.ArabicToRoman(textBox_arabic.Text);
            }
            else
            {
                var insertionPoint = textBox_arabic.SelectionStart - 1;

                textBox_arabic.Text = NumeralConverter.Arabic;
                PlayErrorSound();

                if (insertionPoint > textBox_arabic.Text.Length) insertionPoint = textBox_arabic.Text.Length;
                textBox_arabic.SelectionStart = insertionPoint;
            }
        }

        private void PlayErrorSound()
        {
            System.Media.SystemSounds.Hand.Play();
        }
    }
}
