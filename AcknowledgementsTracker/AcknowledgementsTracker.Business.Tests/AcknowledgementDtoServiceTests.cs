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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var acknowledgementDto = new AcknowledgementDTO();
            var tags = new List<string> { "someTag", "otherTag" };

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            AcknowledgementDTO acknowledgementDto = null;
            var tags = new List<string> { "someTag", "otherTag" };

            // ACT
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsNull()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = null;

            // ACT
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_AcknowledgementCreationWhen_TagsIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var acknowledgementDto = new AcknowledgementDTO();
            List<string> tags = new List<string>();

            // ACT
            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        [TestMethod]
        public void Verify_GetReceived_IsCalledOn_ReadReceived()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = null;

            // ACT
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = string.Empty;

            // ACT
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = " ";

            // ACT
            acknowledgementDtoService.ReadReceived(username);
        }

        [TestMethod]
        public void Verify_GetGiven_IsCalledOn_ReadGiven()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = null;

            // ACT
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = string.Empty;

            // ACT
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadGivenWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = " ";

            // ACT
            acknowledgementDtoService.ReadGiven(username);
        }

        [TestMethod]
        public void Verify_GetLast_IsCalledOn_ReadLast()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadLast();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetLastAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetTodays_IsCalledOn_ReadTodays()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadTodays();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetTodaysAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisWeek_IsCalledOn_ReadThisWeek()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadThisWeek();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisWeekAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetThisMonth_IsCalledOn_ReadThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadThisMonth();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisMonthAcknowledgements());
        }

        [TestMethod]
        public void Verify_GetAllTimeChampion_IsCalledOn_ReadAllTimeChampion()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadAllTimeChampion();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetAllTimeChampion());
        }

        [TestMethod]
        public void Verify_GetAllTimeTopTen_IsCalledOn_ReadAllTimeTopTen()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadAllTimeTopTen();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetAllTimeTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthTopTen_IsCalledOn_ReadThisMonthTopTen()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);

            // ACT
            acknowledgementDtoService.ReadThisMonthTopTen();

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.GetThisMonthTopTen());
        }

        [TestMethod]
        public void Verify_GetThisMonthsByUser_IsCalledOn_ReadReceivedThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var username = "user";

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = null;

            // ACT
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = string.Empty;

            // ACT
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadReceivedThisMonthWhen_UsernameIsWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string username = " ";

            // ACT
            acknowledgementDtoService.ReadReceivedThisMonth(username);
        }

        [TestMethod]
        public void Verify_GetByTag_IsCalledOn_ReadByTag()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tagTitle = "tag";

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = null;

            // ACT
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = string.Empty;

            // ACT
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagWhen_TagisWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = " ";

            // ACT
            acknowledgementDtoService.ReadByTag(tagTitle);
        }

        [TestMethod]
        public void Verify_GetByTagThisMonth_IsCalledOn_ReadByTagThisMonth()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tagTitle = "tag";

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = null;

            // ACT
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisEmpty()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = string.Empty;

            // ACT
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Verify_ExceptionIsThrownOn_ReadByTagThisMonthWhen_TagisWhitespace()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            string tagTitle = " ";

            // ACT
            acknowledgementDtoService.ReadByTagThisMonth(tagTitle);
        }

        [TestMethod]
        public void Verify_Edit_IsCalledOn_Update()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var acknowledgementDto = new AcknowledgementDTO();

            // ACT
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
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var id = 47;

            // ACT
            acknowledgementDtoService.Delete(id);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.Remove(id));
        }
    }
}
