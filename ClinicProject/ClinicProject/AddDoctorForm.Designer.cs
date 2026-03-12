namespace ClinicProject.Forms
{
    partial class AddDoctorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName, lblLogin;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();

            // ПІБ
            this.lblName.Text = "ПІБ Лікаря:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(20, 40);
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // Логін
            this.lblLogin.Text = "Логін (для входу):";
            this.lblLogin.Location = new System.Drawing.Point(20, 70);
            this.lblLogin.AutoSize = true;
            this.txtLogin.Location = new System.Drawing.Point(20, 90);
            this.txtLogin.Size = new System.Drawing.Size(200, 23);

            // Кнопка
            this.btnSave.Text = "💾 Зберегти";
            this.btnSave.Location = new System.Drawing.Point(20, 130);
            this.btnSave.Size = new System.Drawing.Size(200, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Налаштування
            this.ClientSize = new System.Drawing.Size(250, 180);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Text = "Новий лікар";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}