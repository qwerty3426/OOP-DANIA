using ClinicProject.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicProject.Forms
{
    public partial class AddPatientForm : Form
    {
        private readonly ClinicService _service;

        public AddPatientForm(ClinicService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _service.CreatePatient(txtName.Text, dtpBirth.Value, txtPhone.Text);
                MessageBox.Show("Пацієнта успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}