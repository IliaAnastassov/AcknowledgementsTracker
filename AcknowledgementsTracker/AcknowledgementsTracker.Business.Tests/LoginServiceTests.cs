using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Interfaces;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using StructureMap.AutoMocking;

    [TestClass]
    public class LoginServiceTests
    {
        // System Under Test: LoginService
        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsEmplty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsWhiteSpace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_IsWhiteSpace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Please fill all textboxes";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenUsername_NotFound()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "bad user";
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void ShouldReturn_ErrorMsg_WhenPassword_IsWrong()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "ianastassov";
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            var expectedErrorMsg = "Failed to authenticate. Please verify username and password";
            Assert.AreEqual(expectedErrorMsg, response.ResponseMessage);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = null;
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = string.Empty;
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenUsername_IsWhiteSpace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = " ";
            settings.Password = "password";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = null;

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = string.Empty;

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Login_SetUserToNull_WhenPassword_IsWhiteSpace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "username";
            settings.Password = " ";

            // ACT
            var response = autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            Assert.IsNull(response.User);
        }

        [TestMethod]
        public void Connect_IsCalledOn_Login_WhenPassedValidInput()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            autoMocker.Get<ILdapServerConnection>().Stub(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));

            // ACT
            autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            autoMocker.Get<ILdapServerConnection>().AssertWasCalled(connection => connection.Connect(Arg<ILdapSettingsService>.Is.TypeOf));
        }

        [TestMethod]
        public void IsAuthenticated_IsSetToTrueIf_ConnectionIsAuthenticated()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            autoMocker.Get<ILdapServerConnection>().Stub(c => c.IsAuthenticated).Return(true);

            // ACT
            autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            autoMocker.Get<ILdapServerConnection>().AssertWasCalled(c => c.IsAuthenticated);
        }

        [TestMethod]
        public void ReadUserData_IsCalledOn_Login_WhenPassedValidInput()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            autoMocker.Get<ILdapServerConnection>().Stub(c => c.IsAuthenticated).Return(true);
            autoMocker.Get<ILdapServerConnection>().Stub(c => c.IsUIDPropertyUsed).Return(true);

            // ACT
            autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            autoMocker.Get<IAccountService>().AssertWasCalled(a => a.ReadUserData(settings.Username));
        }

        [TestMethod]
        public void ReadUserUsername_IsCalledOn_Login_WhenPassedValidInput()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<LoginService>();

            var settings = new LdapSettingsService();
            settings.Username = "user";
            settings.Password = "password";

            autoMocker.Get<ILdapServerConnection>().Stub(c => c.IsAuthenticated).Return(true);
            autoMocker.Get<ILdapServerConnection>().Stub(c => c.IsUIDPropertyUsed).Return(false);

            // ACT
            autoMocker.ClassUnderTest.Login(settings);

            // ASSERT
            autoMocker.Get<IAccountService>().AssertWasCalled(a => a.ReadUserUsername(settings.Username));
        }
    }
}
