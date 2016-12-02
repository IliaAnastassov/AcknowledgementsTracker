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
        // // System Under Test: AcknowledgementDtoServiceTests
        [TestMethod]
        public void VerifyAddIsCalledOnAcknowledgementCreation()
        {
            // ARRANGE
            var mockAcknowledgementRepository = MockRepository.GenerateMock<IAcknowledgementsRepository>();
            var acknowledgementDto = new AcknowledgementDTO();

            // ACT
            var acknowledgementDtoService = new AcknowledgementDtoService(mockAcknowledgementRepository);
            var tags = new List<string>();
            acknowledgementDtoService.Create(acknowledgementDto, tags);

            // ASSERT
            mockAcknowledgementRepository.AssertWasCalled(repo => repo.Add(acknowledgementDto, tags));
        }

        [TestMethod]
        public void VerifyGetReceivedIsCalledOnReadReceived()
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
        public void VerifyGetGivenIsCalledOnReadGiven()
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
        public void VerifyGetLastIsCalledOnReadLast()
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
        public void VerifyGetTodaysIsCalledOnReadTodays()
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
        public void VerifyGetThisWeekIsCalledOnReadThisWeek()
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
        public void VerifyGetThisMonthIsCalledOnReadThisMonth()
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
        public void VerifyGetAllTimeChampionIsCalledOnReadAllTimeChampion()
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
    }
}
