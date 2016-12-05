namespace AcknowledgementsTracker.Business.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using DataAccess.Interfaces;
    using DTO;
    using Logic;
    using System.Collections.Generic;

    [TestClass]
    public class AcknowledgementDtoServiceTests
    {
        // System Under Test: AcknowledgementDtoServiceTests
        [TestMethod]
        public void Verify_Add_IsCalledOn_AcknowledgementCreation()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDto = new AcknowledgementDTO();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tags = new List<string> { "someTag", "otherTag" };
            acknowledgementDtoService.Create(acknowledgementDto, tags);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.Add(acknowledgementDto, tags));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_AcknowledgementDtoIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            AcknowledgementDTO acknowledgementDto = null;
            var tags = new List<string> { "someTag", "otherTag" };

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = new List<string>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        public void Verify_GetReceived_IsCalledOn_ReadReceived()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";
            acknowledgementDtoService.ReadReceived(username);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetReceived(username));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = string.Empty;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = " ";

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        public void Verify_GetGiven_IsCalledOn_ReadGiven()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";
            acknowledgementDtoService.ReadGiven(username);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetGiven(username));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = string.Empty;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = " ";

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        public void Verify_GetLast_IsCalledOn_ReadLast()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadLast();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetLastAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetTodays_IsCalledOn_ReadTodays()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadTodays();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetTodaysAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisWeek_IsCalledOn_ReadThisWeek()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadThisWeek();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisWeekAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisMonth_IsCalledOn_ReadThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadThisMonth();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisMonthAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetAllTimeChampion_IsCalledOn_ReadAllTimeChampion()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadAllTimeChampion();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetAllTimeChampion());
        }

        [TestMethod]
        public void Verify_GetAllTimeTopTen_IsCalledOn_ReadAllTimeTopTen()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadAllTimeTopTen();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetAllTimeTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthTopTen_IsCalledOn_ReadThisMonthTopTen()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadThisMonthTopTen();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisMonthTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthsByUser_IsCalledOn_ReadReceivedThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";
            acknowledgementDtoService.ReadReceivedThisMonth(username);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisMonthsByUser(username));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = string.Empty;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string username = " ";

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        public void Verify_GetByTag_IsCalledOn_ReadByTag()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tagTitle = "tag";
            acknowledgementDtoService.ReadByTag(tagTitle);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetByTag(tagTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = string.Empty;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = " ";

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        public void Verify_GetByTagThisMonth_IsCalledOn_ReadByTagThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tagTitle = "tag";
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetByTagThisMonth(tagTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = string.Empty;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            string tagTitle = " ";

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        public void Verify_Edit_IsCalledOn_Update()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var acknowledgementDto = new AcknowledgementDTO();
            acknowledgementDtoService.Update(acknowledgementDto);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.Edit(acknowledgementDto));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_UpdateWhen_AcknowledgementDtoIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            AcknowledgementDTO acknowledgementDto = null;

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            acknowledgementDtoService.Update(acknowledgementDto);
        }

        [TestMethod]
        public void Verify_Remove_IsCalledOn_Delete()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var id = 47;
            acknowledgementDtoService.Delete(id);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.Remove(id));
        }
    }
}
