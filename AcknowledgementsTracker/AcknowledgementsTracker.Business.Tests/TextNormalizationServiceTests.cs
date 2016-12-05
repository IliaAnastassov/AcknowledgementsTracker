namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Logic;

    [TestClass]
    public class TextNormalizationServiceTests
    {
        [TestMethod]
        public void Verify_TextNormalization()
        {
            INormalizable normalizer = new TextNormalizationService();

            var text = "Français Gaëlle impôt München, Österreich. Úber à dépôt.";
            var normalizedText = normalizer.NormalizeText(text);
            var exprectedText = "francais gaelle impot munchen, osterreich. uber a depot.";

            Assert.AreEqual(normalizedText, exprectedText);
        }

        [TestMethod]
        public void Verify_MultiBlankSpaceRemoval()
        {
            INormalizable normalizer = new TextNormalizationService();

            var text = "This is a          sample      text\r\n       .";
            var normalizedText = normalizer.RemoveMultiSpaces(text);
            var expectedText = "This is a sample text .";

            Assert.AreEqual(normalizedText, expectedText);
        }
    }
}
