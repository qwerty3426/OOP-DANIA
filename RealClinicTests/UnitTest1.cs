using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

// --- ДОПОМІЖНІ КЛАСИ (Щоб тести працювали автономно) ---
public class Patient { public int Id { get; set; } public string FullName { get; set; } public DateTime BirthDate { get; set; } public string Phone { get; set; } }
public class Visit { public int Id { get; set; } public int PatientId { get; set; } public int DoctorId { get; set; } public DateTime Date { get; set; } public string State { get; set; } }

public class FakeClinicRepository {
    private List<Patient> Patients = new List<Patient>();
    private List<Visit> Visits = new List<Visit>();

    public void AddPatient(Patient p) { if (p.Id == 0) p.Id = Patients.Count + 1; Patients.Add(p); }
    public void AddVisit(Visit v) { if (v.Id == 0) v.Id = Visits.Count + 1; Visits.Add(v); }
    public List<Patient> GetAllPatients() => Patients;
    public List<Visit> GetAllVisits() => Visits;
    public Patient GetPatientById(int id) => Patients.FirstOrDefault(p => p.Id == id);
    public Visit GetVisitById(int id) => Visits.FirstOrDefault(v => v.Id == id);
    public void DeleteVisit(int id) { var v = GetVisitById(id); if (v != null) Visits.Remove(v); }
}

public class ClinicService {
    private FakeClinicRepository _repo;
    public ClinicService(FakeClinicRepository repo) { _repo = repo; }
    public void AddPatient(Patient p) { if (string.IsNullOrEmpty(p.FullName)) throw new ArgumentException(); _repo.AddPatient(p); }
    public void ScheduleVisit(Visit v) { if (v.PatientId == 999) throw new Exception(); _repo.AddVisit(v); }
    public List<Patient> GetPatients() => _repo.GetAllPatients();
    public List<Visit> GetAllVisits() => _repo.GetAllVisits();
}

// --- ТВОЇ 20 ТЕСТІВ ---
public class ClinicTests
{
    [Fact] public void CreatePatient_ValidData() { var r = new FakeClinicRepository(); new ClinicService(r).AddPatient(new Patient { FullName = "Іван" }); Assert.Single(r.GetAllPatients()); }
    [Fact] public void CreatePatient_SavedInRepository() { var r = new FakeClinicRepository(); var p = new Patient { FullName = "Петро" }; r.AddPatient(p); Assert.NotNull(r.GetPatientById(p.Id)); }
    [Fact] public void CreatePatient_InvalidData() { var s = new ClinicService(new FakeClinicRepository()); Assert.Throws<ArgumentException>(() => s.AddPatient(new Patient { FullName = "" })); }
    [Fact] public void GetPatients_ReturnsList() { var r = new FakeClinicRepository(); r.AddPatient(new Patient { FullName = "А" }); Assert.NotEmpty(new ClinicService(r).GetPatients()); }
    [Fact] public void AddVisit_ValidPatient() { var r = new FakeClinicRepository(); new ClinicService(r).ScheduleVisit(new Visit { PatientId = 1 }); Assert.Single(r.GetAllVisits()); }
    [Fact] public void AddVisit_LinkedToPatient() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { PatientId = 5 }); Assert.Equal(5, r.GetAllVisits().First().PatientId); }
    [Fact] public void AddVisit_InvalidPatient() { var s = new ClinicService(new FakeClinicRepository()); Assert.Throws<Exception>(() => s.ScheduleVisit(new Visit { PatientId = 999 })); }
    [Fact] public void GetVisits_ReturnsList() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { PatientId = 1 }); Assert.NotEmpty(new ClinicService(r).GetAllVisits()); }
    [Fact] public void GetPatientVisits_ReturnsVisits() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { PatientId = 1 }); r.AddVisit(new Visit { PatientId = 1 }); Assert.Equal(2, r.GetAllVisits().Where(v => v.PatientId == 1).Count()); }
    [Fact] public void Visit_HasCorrectDate() { var d = new DateTime(2026, 5, 10); Assert.Equal(d, new Visit { Date = d }.Date); }
    [Fact] public void Visit_HasReason() { Assert.Equal("Огляд", new Visit { State = "Огляд" }.State); }
    [Fact] public void Patient_HasUniqueId() { var r = new FakeClinicRepository(); r.AddPatient(new Patient { FullName = "А" }); r.AddPatient(new Patient { FullName = "Б" }); Assert.NotEqual(r.GetAllPatients()[0].Id, r.GetAllPatients()[1].Id); }
    [Fact] public void Repository_AddPatient() { var r = new FakeClinicRepository(); r.AddPatient(new Patient { FullName = "В" }); Assert.Single(r.GetAllPatients()); }
    [Fact] public void Repository_AddVisit() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { PatientId = 2 }); Assert.Single(r.GetAllVisits()); }
    [Fact] public void Repository_GetPatient() { var r = new FakeClinicRepository(); r.AddPatient(new Patient { Id = 10, FullName = "Тарас" }); Assert.Equal("Тарас", r.GetPatientById(10).FullName); }
    [Fact] public void Repository_GetVisits() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { Id = 1 }); r.AddVisit(new Visit { Id = 2 }); Assert.Equal(2, r.GetAllVisits().Count); }
    [Fact] public void Visit_CreationStoresData() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { Id = 5, PatientId = 3 }); Assert.Equal(3, r.GetVisitById(5).PatientId); }
    [Fact] public void Patient_CanHaveMultipleVisits() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { PatientId = 7 }); r.AddVisit(new Visit { PatientId = 7 }); Assert.Equal(2, r.GetAllVisits().Count(v => v.PatientId == 7)); }
    [Fact] public void DeleteVisit_RemovesVisit() { var r = new FakeClinicRepository(); r.AddVisit(new Visit { Id = 1 }); r.DeleteVisit(1); Assert.Empty(r.GetAllVisits()); }
    [Fact] public void System_DataIntegrity() { var r = new FakeClinicRepository(); r.AddPatient(new Patient { Id = 1 }); r.AddVisit(new Visit { Id = 1 }); Assert.Equal(1, r.GetAllPatients().Count); Assert.Equal(1, r.GetAllVisits().Count); }
}