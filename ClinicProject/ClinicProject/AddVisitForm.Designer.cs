namespace ClinicProject.Forms
{
    partial class AddVisitForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbPatients;
        private System.Windows.Forms.ComboBox cmbDoctors;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbPatients = new System.Windows.Forms.ComboBox();
            this.cmbDoctors = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Label Patient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(20, 20);
            this.lblPatient.Text = "Оберіть пацієнта:";

            // ComboBox Patient
            this.cmbPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatients.FormattingEnabled = true;
            this.cmbPatients.Location = new System.Drawing.Point(20, 40);
            this.cmbPatients.Size = new System.Drawing.Size(250, 23);
            this.cmbPatients.Name = "cmbPatients";

            // Label Doctor
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(20, 80);
            this.lblDoctor.Text = "Оберіть лікаря:";

            // ComboBox Doctor
            this.cmbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctors.FormattingEnabled = true;
            this.cmbDoctors.Location = new System.Drawing.Point(20, 100);
            this.cmbDoctors.Size = new System.Drawing.Size(250, 23);
            this.cmbDoctors.Name = "cmbDoctors";

            // Label Date
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 140);
            this.lblDate.Text = "Дата та час візиту:";

            // DateTimePicker
            this.dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(20, 160);
            this.dtpDate.Size = new System.Drawing.Size(250, 23);
            this.dtpDate.Name = "dtpDate";

            // Button Save
            this.btnSave.Location = new System.Drawing.Point(20, 210);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "💾 Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Button Cancel
            this.btnCancel.Location = new System.Drawing.Point(170, 210);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form Settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 270);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbDoctors);
            this.Controls.Add(this.cmbPatients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "AddVisitForm";
            this.Text = "Новий запис";
            this.Load += new System.EventHandler(this.AddVisitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}