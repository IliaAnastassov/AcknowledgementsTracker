using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Interfaces;
    using DTO;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using StructureMap.AutoMocking;

    [TestClass]
    public class AcknowledgementDtoServiceTests
    {
        // System Under Test: AcknowledgementDtoServiceTests
        [TestMethod]
        public void Verify_Add_IsCalledOn_AcknowledgementCreation()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var acknowledgementDto = new AcknowledgementDTO();
            var tags = new List<string> { "someTag", "otherTag" };

            // ACT
            autoMocker.ClassUnderTest.Create(acknowledgementDto, tags);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.Add(acknowledgementDto, tags));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_AcknowledgementDtoIsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            AcknowledgementDTO acknowledgementDto = null;
            var tags = new List<string> { "someTag", "otherTag" };

            // ACT
            autoMocker.ClassUnderTest.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsNull()
        {
            // ARRANGE
            var automocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = null;

            // ACT
            automocker.ClassUnderTest.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = new List<string>();

            // ACT
            autoMocker.ClassUnderTest.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        public void Verify_GetReceived_IsCalledOn_ReadReceived()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var username = "user";

            // ACT
            autoMocker.ClassUnderTest.ReadReceived(username);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetReceived(username));
        }

        [TestMethod]
        public void Verify_ReadReceived_Returns_ExpectedAcknowledgements()
        {
            // TODO:
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = null;

            // ACT
            autoMocker.ClassUnderTest.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = string.Empty;

            // ACT
            autoMocker.ClassUnderTest.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = " ";

            // ACT
            autoMocker.ClassUnderTest.ReadReceived(username);
        }

        [TestMethod]
        public void Verify_GetGiven_IsCalledOn_ReadGiven()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var username = "user";

            // ACT
            autoMocker.ClassUnderTest.ReadGiven(username);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetGiven(username));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = null;

            // ACT
            autoMocker.ClassUnderTest.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = string.Empty;

            // ACT
            autoMocker.ClassUnderTest.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = " ";

            // ACT
            autoMocker.ClassUnderTest.ReadGiven(username);
        }

        [TestMethod]
        public void Verify_GetLast_IsCalledOn_ReadLast()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadLast();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetLastAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetTodays_IsCalledOn_ReadTodays()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadTodays();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetTodaysAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisWeek_IsCalledOn_ReadThisWeek()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadThisWeek();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetThisWeekAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisMonth_IsCalledOn_ReadThisMonth()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadThisMonth();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetThisMonthAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetAllTimeChampion_IsCalledOn_ReadAllTimeChampion()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadAllTimeChampion();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetAllTimeChampion());
        }

        [TestMethod]
        public void Verify_GetAllTimeTopTen_IsCalledOn_ReadAllTimeTopTen()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadAllTimeTopTen();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetAllTimeTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthTopTen_IsCalledOn_ReadThisMonthTopTen()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();

            // ACT
            autoMocker.ClassUnderTest.ReadThisMonthTopTen();

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetThisMonthTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthsByUser_IsCalledOn_ReadReceivedThisMonth()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var username = "user";

            // ACT
            autoMocker.ClassUnderTest.ReadReceivedThisMonth(username);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetThisMonthsByUser(username));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = null;

            // ACT
            autoMocker.ClassUnderTest.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = string.Empty;

            // ACT
            autoMocker.ClassUnderTest.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string username = " ";

            // ACT
            autoMocker.ClassUnderTest.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        public void Verify_GetByTag_IsCalledOn_ReadByTag()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var tagTitle = "tag";

            // ACT
            autoMocker.ClassUnderTest.ReadByTag(tagTitle);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetByTag(tagTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = null;

            // ACT
            autoMocker.ClassUnderTest.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = string.Empty;

            // ACT
            autoMocker.ClassUnderTest.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisWhitespace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = " ";

            // ACT
            autoMocker.ClassUnderTest.ReadByTag(tagTitle);
        }

        [TestMethod]
        public void Verify_GetByTagThisMonth_IsCalledOn_ReadByTagThisMonth()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var tagTitle = "tag";

            // ACT
            autoMocker.ClassUnderTest.ReadByTagThisMonth(tagTitle);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.GetByTagThisMonth(tagTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = null;

            // ACT
            autoMocker.ClassUnderTest.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisEmpty()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = string.Empty;

            // ACT
            autoMocker.ClassUnderTest.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisWhitespace()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            string tagTitle = " ";

            // ACT
            autoMocker.ClassUnderTest.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        public void Verify_Edit_IsCalledOn_Update()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var acknowledgementDto = new AcknowledgementDTO();

            // ACT
            autoMocker.ClassUnderTest.Update(acknowledgementDto);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.Edit(acknowledgementDto));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_UpdateWhen_AcknowledgementDtoIsNull()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            AcknowledgementDTO acknowledgementDto = null;

            // ACT
            autoMocker.ClassUnderTest.Update(acknowledgementDto);
        }

        [TestMethod]
        public void Verify_Remove_IsCalledOn_Delete()
        {
            // ARRANGE
            var autoMocker = new RhinoAutoMocker<AcknowledgementDtoService>();
            var id = 47;

            // ACT
            autoMocker.ClassUnderTest.Delete(id);

            // ASSERT
            autoMocker.Get<IAcknowledgementsRepository>().AssertWasCalled(repo => repo.Remove(id));
        }
    }
}
