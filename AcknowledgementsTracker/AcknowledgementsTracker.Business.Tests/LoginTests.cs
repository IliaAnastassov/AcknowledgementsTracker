using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Interfaces;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;

    [TestClass]
    public class LoginTests
    {
        // System Under Test: LoginService
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenPasswordIsEmplty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturnErrorMsgWhenUsernameIsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();

            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
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
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenUsernameIsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenUsernameIsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenUsernameIsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenPasswordIsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenPasswordIsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void LoginSetUserToNullWhenPasswordIsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            var loginService = new LoginService(mockLdapConnection, mockAccountService);
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void ConnectIsCalledOnLoginWhenPassedValidInput()
        {
            // ARRANGE
            var stubLdapConnection = MockRepository.GenerateStub<ILdapServerConnection>();
            var stubAccountService = MockRepository.GenerateStub<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            stubLdapConnection.Stub(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));

            // ACT
            var loginService = new LoginService(stubLdapConnection, stubAccountService);
            loginService.Login(settings);

            // ASSERT
            stubLdapConnection.AssertWasCalled(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));
        }

        [TestMethod]
        public void ReadUserDataIsCalledOnLoginWhenPassedValidInput()
        {
            // ARRANGE
            var stubLdapConnection = MockRepository.GenerateStub<ILdapServerConnection>();
            var stubAccountService = MockRepository.GenerateStub<IAccountService>();
            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            stubAccountService.Stub(a => a.ReadUserData(Arg<string>.Is.TypeOf));

            // ACT
            var loginService = new LoginService(stubLdapConnection, stubAccountService);
            loginService.Login(settings);

            // ASSERT
            stubAccountService.AssertWasCalled(a => a.ReadUserData(Arg<string>.Is.TypeOf));
        }
    }
}
