namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Business.Interfaces;
    using Business.Logic;

    [TestClass]
    public class TextNormalizationServiceTests
    {
        [TestMethod]
        public void VerifyTextNormalization()
        {
            INormalizable normalizer = new TextNormalizationService();

            var text = "Français Gaëlle impôt München, Österreich. Úber à dépôt.";
            var normalizedText = normalizer.NormalizeText(text);
            var exprectedText = "francais gaelle impot munchen, osterreich. uber a depot.";

            Assert.AreEqual(normalizedText, exprectedText);
        }
    }
}
