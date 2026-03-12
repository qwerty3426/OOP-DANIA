namespace ClinicProject.Forms
{
    partial class AddPatientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName, lblPhone, lblBirth;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();

            // ПІБ
            this.lblName.Text = "ПІБ Пацієнта:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(20, 40);
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // Дата народження
            this.lblBirth.Text = "Дата народження:";
            this.lblBirth.Location = new System.Drawing.Point(20, 70);
            this.lblBirth.AutoSize = true;
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirth.Location = new System.Drawing.Point(20, 90);
            this.dtpBirth.Size = new System.Drawing.Size(200, 23);

            // Телефон
            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Location = new System.Drawing.Point(20, 120);
            this.lblPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(20, 140);
            this.txtPhone.Size = new System.Drawing.Size(200, 23);

            // Кнопка
            this.btnSave.Text = "💾 Зберегти";
            this.btnSave.Location = new System.Drawing.Point(20, 180);
            this.btnSave.Size = new System.Drawing.Size(200, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Налаштування форми
            this.ClientSize = new System.Drawing.Size(250, 240);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Text = "Новий пацієнт";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}