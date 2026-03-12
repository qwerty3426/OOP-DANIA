using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ClinicProject.Data;
using ClinicProject.Models;

namespace ClinicProject.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ClinicDbContext _context;

        public ClinicRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Visit> SearchVisits(string? patientName, int? doctorId, DateTime? date)
        {
            var visits = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .ToList();

            if (!string.IsNullOrWhiteSpace(patientName))
            {
                string search = patientName.ToLower();
                visits = visits.Where(v => v.Patient?.FullName.ToLower().Contains(search) == true).ToList();
            }

            if (date.HasValue)
            {
                string dateStr = date.Value.ToString("yyyy-MM-dd");
                visits = visits.Where(v => v.Date.ToString("yyyy-MM-dd") == dateStr).ToList();
            }

            visits.ForEach(v => v.InitializeState());
            return visits;
        }

        public void AddVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public void UpdateVisit(Visit visit)
        {
            _context.Visits.Update(visit);
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public Visit? GetVisitById(int id)
        {
            var visit = _context.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .FirstOrDefault(v => v.Id == id);

            visit?.InitializeState();

            return visit;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public IEnumerable<User> GetAllDoctors()
        {
            return _context.Users.Where(u => u.Role == Role.Doctor).ToList();
        }
    }
}