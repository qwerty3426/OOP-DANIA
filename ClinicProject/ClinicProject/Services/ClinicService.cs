using System;
using System.Collections.Generic;
using ClinicProject.Models;
using ClinicProject.Repositories;

namespace ClinicProject.Services
{
    public class ClinicService
    {
        private readonly IClinicRepository _repository;

        public ClinicService(IClinicRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Visit> Search(string? patientName, int? doctorId, DateTime? date)
        {
            return _repository.SearchVisits(patientName, doctorId, date);
        }

        public void CreatePatient(string fullName, DateTime dob, string phone)
        {
            var patient = new Patient
            {
                FullName = fullName,
                DateOfBirth = dob,
                Phone = phone
            };
            _repository.AddPatient(patient);
        }

        public void CreateDoctor(string fullName, string login)
        {
            var doctor = new User
            {
                FullName = fullName,
                Login = login,
                Role = Role.Doctor,
                PasswordHash = "12345" 
            };
            _repository.AddUser(doctor);
        }

        public void ScheduleVisit(int patientId, int doctorId, DateTime date)
        {
            var visit = new Visit
            {
                PatientId = patientId,
                DoctorId = doctorId,
                Date = date
            };

            _repository.AddVisit(visit);
        }

        public void StartVisit(int visitId)
        {
            var visit = _repository.GetVisitById(visitId);
            if (visit == null)
                throw new Exception("Візит не знайдено.");

            visit.Start(); 

            _repository.UpdateVisit(visit); 
        }

        public void CompleteVisit(int visitId, string notes)
        {
            var visit = _repository.GetVisitById(visitId);
            if (visit == null)
                throw new Exception("Візит не знайдено.");

            visit.Notes = notes;
            visit.Complete();

            _repository.UpdateVisit(visit);
        }

        public void CancelVisit(int visitId)
        {
            var visit = _repository.GetVisitById(visitId);
            if (visit == null)
                throw new Exception("Візит не знайдено.");

            visit.Cancel(); 

            _repository.UpdateVisit(visit);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _repository.GetAllPatients();
        }

        public IEnumerable<User> GetDoctors()
        {
            return _repository.GetAllDoctors();
        }
    }
}