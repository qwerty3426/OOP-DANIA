using System;
using System.Windows.Forms;
using ClinicProject.Models;
using ClinicProject.Services;

namespace ClinicProject.Forms
{
    public partial class AddVisitForm : Form
    {
        private readonly ClinicService _service;

        public AddVisitForm(ClinicService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void AddVisitForm_Load(object sender, EventArgs e)
        {
            cmbPatients.DataSource = _service.GetPatients();
            cmbPatients.DisplayMember = "FullName"; 
            cmbPatients.ValueMember = "Id";         

            cmbDoctors.DataSource = _service.GetDoctors();
            cmbDoctors.DisplayMember = "FullName";
            cmbDoctors.ValueMember = "Id";

            dtpDate.Value = DateTime.Now.AddDays(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var patientId = (int)cmbPatients.SelectedValue;
                var doctorId = (int)cmbDoctors.SelectedValue;
                var date = dtpDate.Value;

                _service.ScheduleVisit(patientId, doctorId, date);

                MessageBox.Show("Запис успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення запису: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}