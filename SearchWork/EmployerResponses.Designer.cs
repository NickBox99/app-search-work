namespace SearchWork
{
    partial class EmployerResponses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployerResponses));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.education = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.military_registration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_of_applicant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fio,
            this.date_of_birth,
            this.address,
            this.phone,
            this.experience,
            this.resume,
            this.education,
            this.salary,
            this.position,
            this.gender,
            this.military_registration,
            this.type_of_applicant});
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1177, 244);
            this.dataGridView1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Id вакансии: ";
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            // 
            // date_of_birth
            // 
            this.date_of_birth.HeaderText = "Дата рождения";
            this.date_of_birth.Name = "date_of_birth";
            this.date_of_birth.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Адрес";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.HeaderText = "Телефон";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // experience
            // 
            this.experience.HeaderText = "Опыт работы";
            this.experience.Name = "experience";
            this.experience.ReadOnly = true;
            // 
            // resume
            // 
            this.resume.HeaderText = "Резюме";
            this.resume.Name = "resume";
            this.resume.ReadOnly = true;
            // 
            // education
            // 
            this.education.HeaderText = "Образование";
            this.education.Name = "education";
            this.education.ReadOnly = true;
            // 
            // salary
            // 
            this.salary.HeaderText = "Желаемая зарплата";
            this.salary.Name = "salary";
            this.salary.ReadOnly = true;
            // 
            // position
            // 
            this.position.HeaderText = "Желаемая должность";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.HeaderText = "Пол";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // military_registration
            // 
            this.military_registration.HeaderText = "Воинский учет";
            this.military_registration.Name = "military_registration";
            this.military_registration.ReadOnly = true;
            // 
            // type_of_applicant
            // 
            this.type_of_applicant.HeaderText = "Вид соискательства";
            this.type_of_applicant.Name = "type_of_applicant";
            this.type_of_applicant.ReadOnly = true;
            // 
            // EmployerResponses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1206, 302);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployerResponses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отклики";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_of_birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn experience;
        private System.Windows.Forms.DataGridViewTextBoxColumn resume;
        private System.Windows.Forms.DataGridViewTextBoxColumn education;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn military_registration;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_of_applicant;
    }
}