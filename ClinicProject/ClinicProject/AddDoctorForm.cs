using ClinicProject.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicProject.Forms
{
    public partial class AddDoctorForm : Form
    {
        private readonly ClinicService _service;

        public AddDoctorForm(ClinicService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _service.CreateDoctor(txtName.Text, txtLogin.Text);
                MessageBox.Show("Лікаря успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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