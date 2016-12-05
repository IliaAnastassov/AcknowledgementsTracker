using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Interfaces;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;

    [TestClass]
    public class LoginServiceTests
    {
        // System Under Test: LoginService
        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsEmplty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_NotFound()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "bad user";
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsWrong()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "ianastassov";
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsNull()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsEmpty()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsWhiteSpace()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            var response = loginService.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Connect_IsCalledOn_Login_WhenPassedValidInput()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            mockLdapConnection.Stub(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));

            // ACT
            loginService.Login(settings);

            // ASSERT
            mockLdapConnection.AssertWasCalled(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));
        }

        [TestMethod]
        public void IsAuthenticated_IsSetToTrueIf_ConnectionIsAuthenticated()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockLdapAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockLdapAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            mockLdapConnection.Stub(c => c.IsAuthenticated).Return(true);

            // ACT
            loginService.Login(settings);

            // ASSERT
            mockLdapConnection.AssertWasCalled(c => c.IsAuthenticated);
        }

        [TestMethod]
        public void ReadUserData_IsCalledOn_Login_WhenPassedValidInput()
        {
            // ARRANGE
            var mockLdapConnection = MockRepository.GenerateMock<ILdapServerConnection>();
            var mockAccountService = MockRepository.GenerateMock<IAccountService>();
            var loginService = new LoginService(mockLdapConnection, mockAccountService);

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            mockAccountService.Stub(a => a.ReadUserData(Arg<string>.Is.TypeOf));

            // ACT
            loginService.Login(settings);

            // ASSERT
            mockAccountService.AssertWasCalled(a => a.ReadUserData(Arg<string>.Is.TypeOf));
        }
    }
}
