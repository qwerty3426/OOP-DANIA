using ClinicProject.Forms;
using ClinicProject.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class MainForm : Form
    {
        private readonly ClinicService _clinicService;

        public MainForm(ClinicService clinicService)
        {
            InitializeComponent();
            _clinicService = clinicService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadVisits();
        }

        private void LoadVisits()
        {
            try
            {
                var visits = _clinicService.Search(null, null, null).ToList();

                dataGridViewVisits.DataSource = visits.Select(v => new
                {
                    Номер = v.Id,
                    Дата = v.Date.ToString("dd.MM.yyyy HH:mm"),
                    Пацієнт = v.Patient?.FullName ?? "Невідомо",
                    Лікар = v.Doctor?.FullName ?? "Невідомо",
                    Статус = v.CurrentStatus 
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadVisits();
        }

        private void btnStartVisit_Click(object sender, EventArgs e)
        {
            if (dataGridViewVisits.CurrentRow != null)
            {
                int visitId = (int)dataGridViewVisits.CurrentRow.Cells["Номер"].Value;
                try
                {
                    _clinicService.StartVisit(visitId);
                    MessageBox.Show("Візит успішно розпочато!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVisits();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Увага (Патерн State)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCompleteVisit_Click(object sender, EventArgs e)
        {
            if (dataGridViewVisits.CurrentRow != null)
            {
                int visitId = (int)dataGridViewVisits.CurrentRow.Cells["Номер"].Value;
                try
                {
                    _clinicService.CompleteVisit(visitId, "Прийом проведено. Рекомендовано вітаміни.");
                    MessageBox.Show("Візит успішно завершено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVisits();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Увага (Патерн State)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var form = new AddVisitForm(_clinicService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadVisits(); 
                }
            }
        }

        private void LoadVisits(string patientName = null, DateTime? date = null)
        {
            try
            {
                var visits = _clinicService.Search(patientName, null, date).ToList();

                dataGridViewVisits.DataSource = visits.Select(v => new
                {
                    Номер = v.Id,
                    Дата = v.Date.ToString("dd.MM.yyyy HH:mm"),
                    Пацієнт = v.Patient?.FullName ?? "Невідомо",
                    Лікар = v.Doctor?.FullName ?? "Невідомо",
                    Статус = v.CurrentStatus
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearchName.Text.Trim();
            DateTime? date = null;

            if (chkEnableDate.Checked)
            {
                date = dtpSearchDate.Value.Date; 
            }

            System.Diagnostics.Debug.WriteLine($"Пошук: ім'я='{name}', дата={date}");

            LoadVisits(name, date);
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            chkEnableDate.Checked = false;

            LoadVisits();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            using (var form = new AddPatientForm(_clinicService))
            {
                form.ShowDialog();
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            using (var form = new AddDoctorForm(_clinicService))
            {
                form.ShowDialog();
            }
        }
    }
}