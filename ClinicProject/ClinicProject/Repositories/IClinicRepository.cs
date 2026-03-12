using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicProject.Models;

namespace ClinicProject.Repositories
{
    public interface IClinicRepository
    {
        IEnumerable<Visit> SearchVisits(string? patientName, int? doctorId, DateTime? date);
        void AddVisit(Visit visit);
        void UpdateVisit(Visit visit);
        void AddPatient(Patient patient);
        void AddUser(User user);
        Visit? GetVisitById(int id);

        IEnumerable<Patient> GetAllPatients();
        IEnumerable<User> GetAllDoctors();
    }
}