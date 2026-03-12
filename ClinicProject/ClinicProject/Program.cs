using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using ClinicProject.Data;
using ClinicProject.Repositories;
using ClinicProject.Services;

namespace ClinicProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var options = new DbContextOptionsBuilder<ClinicDbContext>()
                .UseSqlite("Data Source=clinic.db")
                .Options;

            using var context = new ClinicDbContext(options);

            context.Database.EnsureCreated();

            var repository = new ClinicRepository(context);
            var clinicService = new ClinicService(repository);

            Application.Run(new MainForm(clinicService));
        }
    }
}