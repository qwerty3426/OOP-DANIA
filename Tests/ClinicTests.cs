using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicTests
{
    // 1. Створення нового пацієнта
    [Fact]
    public void CreatePatient_ValidData()
    {
        var repo = new FakeClinicRepository();
        var service = new ClinicService(repo);
        var patient = new Patient { FullName = "Іванов Іван", BirthDate = new DateTime(1990, 1, 1), Phone = "0991234567" };
        
        service.AddPatient(patient);
        Assert.Single(repo.GetAllPatients());
    }

    // 2. Збереження пацієнта у системі
    [Fact]
    public void CreatePatient_SavedInRepository()
    {
        var repo = new FakeClinicRepository();
        var patient = new Patient { FullName = "Петров Петро", BirthDate = new DateTime(1985, 5, 12) };
        
        repo.AddPatient(patient);
        Assert.NotNull(repo.GetPatientById(patient.Id));
    }

    // 3. Обробка некоректних даних
    [Fact]
    public void CreatePatient_InvalidData()
    {
        var repo = new FakeClinicRepository();
        var service = new ClinicService(repo);
        var invalidPatient = new Patient { FullName = "" }; // Пусте ім'я

        Assert.Throws<ArgumentException>(() => service.AddPatient(invalidPatient));
    }

    // 4. Отримання списку пацієнтів
    [Fact]
    public void GetPatients_ReturnsList()
    {
        var repo = new FakeClinicRepository();
        repo.AddPatient(new Patient { FullName = "Анна" });
        var service = new ClinicService(repo);

        var patients = service.GetPatients();
        Assert.NotEmpty(patients);
    }

    // 5. Створення візиту
    [Fact]
    public void AddVisit_ValidPatient()
    {
        var repo = new FakeClinicRepository();
        var service = new ClinicService(repo);
        var visit = new Visit { PatientId = 1, DoctorId = 2, Date = DateTime.Now, State = "Scheduled" };

        service.ScheduleVisit(visit);
        Assert.Single(repo.GetAllVisits());
    }

    // 6. Зв'язок візиту з пацієнтом
    [Fact]
    public void AddVisit_LinkedToPatient()
    {
        var repo = new FakeClinicRepository();
        var visit = new Visit { PatientId = 5, DoctorId = 1, Date = DateTime.Now };
        
        repo.AddVisit(visit);
        var savedVisit = repo.GetAllVisits().First();
        
        Assert.Equal(5, savedVisit.PatientId);
    }

    // 7. Помилка для неіснуючого пацієнта
    [Fact]
    public void AddVisit_InvalidPatient()
    {
        var repo = new FakeClinicRepository();
        var service = new ClinicService(repo);
        var invalidVisit = new Visit { PatientId = 999, Date = DateTime.Now }; // ID 999 не існує

        Assert.Throws<Exception>(() => service.ScheduleVisit(invalidVisit));
    }

    // 8. Отримання списку візитів
    [Fact]
    public void GetVisits_ReturnsList()
    {
        var repo = new FakeClinicRepository();
        repo.AddVisit(new Visit { PatientId = 1, DoctorId = 1 });
        var service = new ClinicService(repo);

        var visits = service.GetAllVisits();
        Assert.NotEmpty(visits);
    }

    // 9. Історія візитів пацієнта
    [Fact]
    public void GetPatientVisits_ReturnsVisits()
    {
        var repo = new FakeClinicRepository();
        repo.AddVisit(new Visit { PatientId = 1, Date = DateTime.Now.AddDays(-1) });
        repo.AddVisit(new Visit { PatientId = 1, Date = DateTime.Now });

        var patientVisits = repo.GetAllVisits().Where(v => v.PatientId == 1).ToList();
        Assert.Equal(2, patientVisits.Count);
    }

    // 10. Коректність дати візиту
    [Fact]
    public void Visit_HasCorrectDate()
    {
        var date = new DateTime(2026, 5, 10);
        var visit = new Visit { Date = date };

        Assert.Equal(date, visit.Date);
    }

    // 11. Збереження причини звернення
    [Fact]
    public void Visit_HasReason()
    {
        // Примітка: використовуємо поле State як причину/статус для тесту
        var visit = new Visit { State = "Огляд зубів" };
        Assert.Equal("Огляд зубів", visit.State);
    }

    // 12. Унікальність ID пацієнта
    [Fact]
    public void Patient_HasUniqueId()
    {
        var repo = new FakeClinicRepository();
        repo.AddPatient(new Patient { FullName = "Максим" });
        repo.AddPatient(new Patient { FullName = "Олег" });

        var patients = repo.GetAllPatients();
        Assert.NotEqual(patients[0].Id, patients[1].Id);
    }

    // 13. Додавання пацієнта у репозиторій
    [Fact]
    public void Repository_AddPatient()
    {
        var repo = new FakeClinicRepository();
        repo.AddPatient(new Patient { FullName = "Ірина" });
        Assert.Single(repo.GetAllPatients());
    }

    // 14. Додавання візиту
    [Fact]
    public void Repository_AddVisit()
    {
        var repo = new FakeClinicRepository();
        repo.AddVisit(new Visit { PatientId = 2, DoctorId = 1 });
        Assert.Single(repo.GetAllVisits());
    }

    // 15. Отримання пацієнта
    [Fact]
    public void Repository_GetPatient()
    {
        var repo = new FakeClinicRepository();
        var patient = new Patient { Id = 10, FullName = "Тарас" };
        repo.AddPatient(patient);

        var result = repo.GetPatientById(10);
        Assert.Equal("Тарас", result.FullName);
    }

    // 16. Отримання списку візитів
    [Fact]
    public void Repository_GetVisits()
    {
        var repo = new FakeClinicRepository();
        repo.AddVisit(new Visit { Id = 1 });
        repo.AddVisit(new Visit { Id = 2 });

        Assert.Equal(2, repo.GetAllVisits().Count);
    }

    // 17. Коректне збереження даних
    [Fact]
    public void Visit_CreationStoresData()
    {
        var repo = new FakeClinicRepository();
        var visit = new Visit { PatientId = 3, DoctorId = 2, State = "Scheduled" };
        repo.AddVisit(visit);

        var saved = repo.GetVisitById(visit.Id);
        Assert.Equal(3, saved.PatientId);
        Assert.Equal(2, saved.DoctorId);
    }

    // 18. Кілька візитів для пацієнта
    [Fact]
    public void Patient_CanHaveMultipleVisits()
    {
        var repo = new FakeClinicRepository();
        repo.AddVisit(new Visit { PatientId = 7, DoctorId = 1 });
        repo.AddVisit(new Visit { PatientId = 7, DoctorId = 2 });

        var count = repo.GetAllVisits().Count(v => v.PatientId == 7);
        Assert.Equal(2, count);
    }

    // 19. Видалення візиту
    [Fact]
    public void DeleteVisit_RemovesVisit()
    {
        var repo = new FakeClinicRepository();
        var visit = new Visit { Id = 1, PatientId = 1 };
        repo.AddVisit(visit);
        
        repo.DeleteVisit(1); // Припускаємо наявність методу видалення
        Assert.Empty(repo.GetAllVisits());
    }

    // 20. Цілісність даних системи
    [Fact]
    public void System_DataIntegrity()
    {
        var repo = new FakeClinicRepository();
        var service = new ClinicService(repo);
        
        service.AddPatient(new Patient { Id = 1, FullName = "Тест" });
        service.ScheduleVisit(new Visit { Id = 1, PatientId = 1, DoctorId = 1 });

        Assert.Equal(1, repo.GetAllPatients().Count);
        Assert.Equal(1, repo.GetAllVisits().Count);
    }
}