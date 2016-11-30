namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AcknowledgementsTracker.Business.Logic;
    using Interfaces;
    using Rhino.Mocks;

    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void ShouldReturnErrorMsgWhenPasswordIsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenPasswordIsEmplty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = "";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenPasswordIsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenUsernameIsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenUsernameIsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "";
            settings.Password = "password";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenUsernameIsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenUsernameNotFound()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "bad user";
            settings.Password = "password";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenPasswordIsWrong()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "ianastassov";
            settings.Password = "password";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }

        [TestMethod]
        public void ShouldReturnEmptyErrorMsgWhenUsernameAndPasswordAreCorrect()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "ianastassov";
            settings.Password = "HjuwG7Hf";
            settings.ServerPath = "LDAP://ldap.proxiad.corp/dc=proxiad,dc=bg";
            settings.SearchRoot = "LDAP://ldap.proxiad.corp/ou=People,dc=proxiad,dc=bg";

            // ACT
            ILoginService loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = string.Empty;
            Assert.AreEqual(expectedErrorMsg, response.ErrorMessage);
        }
    }
}
