namespace ClinicProject
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewVisits;
        private System.Windows.Forms.Button btnStartVisit;
        private System.Windows.Forms.Button btnCompleteVisit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.DateTimePicker dtpSearchDate;
        private System.Windows.Forms.CheckBox chkEnableDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Button btnCreateVisit;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnAddDoctor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewVisits = new System.Windows.Forms.DataGridView();
            this.btnStartVisit = new System.Windows.Forms.Button();
            this.btnCompleteVisit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCreateVisit = new System.Windows.Forms.Button();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.chkEnableDate = new System.Windows.Forms.CheckBox();
            this.dtpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVisits)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();

            // 
            // dataGridViewVisits
            // 
            this.dataGridViewVisits.AllowUserToAddRows = false;
            this.dataGridViewVisits.AllowUserToDeleteRows = false;
            this.dataGridViewVisits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVisits.Location = new System.Drawing.Point(0, 100); // Відступ зверху (50 кнопок + 50 пошук)
            this.dataGridViewVisits.Name = "dataGridViewVisits";
            this.dataGridViewVisits.ReadOnly = true;
            this.dataGridViewVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVisits.Size = new System.Drawing.Size(800, 350);
            this.dataGridViewVisits.TabIndex = 0;

            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAddDoctor);
            this.panelButtons.Controls.Add(this.btnAddPatient);
            this.panelButtons.Controls.Add(this.btnCreateVisit);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnStartVisit);
            this.panelButtons.Controls.Add(this.btnCompleteVisit);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 50);
            this.panelButtons.TabIndex = 2;

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(118, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "🔄 Оновити";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnStartVisit
            // 
            this.btnStartVisit.Location = new System.Drawing.Point(224, 12);
            this.btnStartVisit.Name = "btnStartVisit";
            this.btnStartVisit.Size = new System.Drawing.Size(130, 30);
            this.btnStartVisit.TabIndex = 1;
            this.btnStartVisit.Text = "▶ Розпочати візит";
            this.btnStartVisit.UseVisualStyleBackColor = true;
            this.btnStartVisit.Click += new System.EventHandler(this.btnStartVisit_Click);

            // 
            // btnCompleteVisit
            // 
            this.btnCompleteVisit.Location = new System.Drawing.Point(360, 12);
            this.btnCompleteVisit.Name = "btnCompleteVisit";
            this.btnCompleteVisit.Size = new System.Drawing.Size(130, 30);
            this.btnCompleteVisit.TabIndex = 2;
            this.btnCompleteVisit.Text = "✔ Завершити візит";
            this.btnCompleteVisit.UseVisualStyleBackColor = true;
            this.btnCompleteVisit.Click += new System.EventHandler(this.btnCompleteVisit_Click);

            // 
            // btnCreateVisit
            // 
            this.btnCreateVisit.Location = new System.Drawing.Point(12, 12);
            this.btnCreateVisit.Name = "btnCreateVisit";
            this.btnCreateVisit.Size = new System.Drawing.Size(100, 30);
            this.btnCreateVisit.TabIndex = 3;
            this.btnCreateVisit.Text = "➕ Новий запис";
            this.btnCreateVisit.UseVisualStyleBackColor = true;
            this.btnCreateVisit.Click += new System.EventHandler(this.btnCreate_Click);

            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Location = new System.Drawing.Point(540, 12);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(100, 30);
            this.btnAddPatient.TabIndex = 4;
            this.btnAddPatient.Text = "➕ Пацієнт";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);

            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Location = new System.Drawing.Point(650, 12);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(100, 30);
            this.btnAddDoctor.TabIndex = 5;
            this.btnAddDoctor.Text = "➕ Лікар";
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);

            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSearch.Controls.Add(this.btnResetSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.chkEnableDate);
            this.panelSearch.Controls.Add(this.dtpSearchDate);
            this.panelSearch.Controls.Add(this.txtSearchName);
            this.panelSearch.Controls.Add(this.lblSearchName);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Height = 50;
            this.panelSearch.Location = new System.Drawing.Point(0, 50); // Під panelButtons
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(800, 50);
            this.panelSearch.TabIndex = 1;

            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(12, 15);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(55, 15);
            this.lblSearchName.TabIndex = 0;
            this.lblSearchName.Text = "Пацієнт:";

            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(70, 12);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(150, 23);
            this.txtSearchName.TabIndex = 1;

            // 
            // chkEnableDate
            // 
            this.chkEnableDate.AutoSize = true;
            this.chkEnableDate.Location = new System.Drawing.Point(240, 14);
            this.chkEnableDate.Name = "chkEnableDate";
            this.chkEnableDate.Size = new System.Drawing.Size(54, 19);
            this.chkEnableDate.TabIndex = 2;
            this.chkEnableDate.Text = "Дата:";
            this.chkEnableDate.UseVisualStyleBackColor = true;

            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchDate.Location = new System.Drawing.Point(300, 12);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.Size = new System.Drawing.Size(100, 23);
            this.dtpSearchDate.TabIndex = 3;

            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(420, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍 Знайти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Location = new System.Drawing.Point(510, 10);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(80, 25);
            this.btnResetSearch.TabIndex = 5;
            this.btnResetSearch.Text = "❌ Скинути";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.Controls.Add(this.dataGridViewVisits);  
            this.Controls.Add(this.panelSearch);          
            this.Controls.Add(this.panelButtons);        

            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewVisits.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АРМ Реєстратури Клініки";
            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVisits)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}