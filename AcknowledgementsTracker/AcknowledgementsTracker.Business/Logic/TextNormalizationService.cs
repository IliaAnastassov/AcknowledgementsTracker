namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public class TextNormalizationService : INormalizable
    {
        public string NormalizeText(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            text = text.ToLower();
            text = RemoveDiacritics(text);

            return text;
        }

        public string RemoveMultiSpaces(string text)
        {
            text = Regex.Replace(text, @"\s+", " ");

            return text;
        }

        private string RemoveDiacritics(string text)
        {
            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();

            return new string(chars).Normalize();
        }
    }
}
