using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClinicProject.Models; 

namespace Clinic.Tests
{
    [TestClass]
    public class VisitStateTests
    {
        [TestMethod]
        public void NewVisit_ShouldHaveScheduledStatus()
        {
            var visit = new Visit();

            Assert.AreEqual("Scheduled", visit.CurrentStatus, "Новий візит має бути у стані Scheduled");
        }

        [TestMethod]
        public void StartVisit_FromScheduled_ShouldChangeToInProgress()
        {
            var visit = new Visit(); 

            visit.Start();

            Assert.AreEqual("InProgress", visit.CurrentStatus, "Після старту статус має бути InProgress");
        }

        [TestMethod]
        public void CompleteVisit_FromInProgress_ShouldChangeToCompleted()
        {
            var visit = new Visit();
            visit.Start();

            visit.Complete();

            Assert.AreEqual("Completed", visit.CurrentStatus, "Після завершення статус має бути Completed");
        }

        [TestMethod]
        public void CompleteVisit_FromScheduled_ShouldThrowException()
        {
            var visit = new Visit();

            Assert.ThrowsException<InvalidOperationException>(() => visit.Complete());
        }

        [TestMethod]
        public void CancelVisit_FromCompleted_ShouldThrowException()
        {
            var visit = new Visit();
            visit.Start();
            visit.Complete(); 

            Assert.ThrowsException<InvalidOperationException>(() => visit.Cancel());
        }
    }
}