using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ClinicProject.Models;
using ClinicProject.Repositories;
using ClinicProject.Services;

namespace Clinic.Tests
{
    [TestClass]
    public class ClinicServiceTests
    {
        [TestMethod]
        public void Search_ShouldReturnVisits_WhenRepositoryReturnsData()
        {
            var mockRepo = new Mock<IClinicRepository>();

            mockRepo.Setup(repo => repo.SearchVisits(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<DateTime?>()))
                    .Returns(new List<Visit>
                    {
                        new Visit { Id = 1, StatusDb = "Scheduled" },
                        new Visit { Id = 2, StatusDb = "Completed" }
                    });

            var service = new ClinicService(mockRepo.Object);

            var result = service.Search("Test", null, null).ToList();

            Assert.AreEqual(2, result.Count, "Повинно повернутися 2 візити");

            mockRepo.Verify(r => r.SearchVisits(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<DateTime?>()), Times.Once);
        }

        [TestMethod]
        public void CreatePatient_ShouldCallRepositoryAddPatient()
        {
            var mockRepo = new Mock<IClinicRepository>();
            var service = new ClinicService(mockRepo.Object);

            string name = "Тестовий Пацієнт";
            var dob = DateTime.Now;
            string phone = "123456";

            service.CreatePatient(name, dob, phone);

            mockRepo.Verify(r => r.AddPatient(It.Is<Patient>(p =>
                p.FullName == name &&
                p.Phone == phone
            )), Times.Once);
        }

        [TestMethod]
        public void StartVisit_ShouldUpdateVisitStatus_AndSaveToRepo()
        {
            var mockRepo = new Mock<IClinicRepository>();
            var visit = new Visit { Id = 10, StatusDb = "Scheduled" };
            visit.InitializeState(); 

            mockRepo.Setup(r => r.GetVisitById(10)).Returns(visit);

            var service = new ClinicService(mockRepo.Object);

            service.StartVisit(10);

            Assert.AreEqual("InProgress", visit.CurrentStatus);

            mockRepo.Verify(r => r.UpdateVisit(visit), Times.Once);
        }
    }
}