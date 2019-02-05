namespace TRPO
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelExit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDeleteAccount = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelProfile = new System.Windows.Forms.Label();
            this.labelSchedule = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelEvents = new System.Windows.Forms.Label();
            this.labelAdditioanalInf = new System.Windows.Forms.Label();
            this.labelTeacherAndClasses = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelExit);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 42);
            this.panel1.TabIndex = 0;
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExit.ForeColor = System.Drawing.Color.White;
            this.labelExit.Location = new System.Drawing.Point(828, 11);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(120, 13);
            this.labelExit.TabIndex = 2;
            this.labelExit.Text = "Вернуться на главную";
            this.labelExit.Click += new System.EventHandler(this.LabelExit_Click);
            this.labelExit.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelExit.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Меню - Электронный дневник";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.buttonDeleteAccount);
            this.panel2.Location = new System.Drawing.Point(-2, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 72);
            this.panel2.TabIndex = 1;
            // 
            // buttonDeleteAccount
            // 
            this.buttonDeleteAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonDeleteAccount.Location = new System.Drawing.Point(404, 24);
            this.buttonDeleteAccount.Name = "buttonDeleteAccount";
            this.buttonDeleteAccount.Size = new System.Drawing.Size(155, 29);
            this.buttonDeleteAccount.TabIndex = 5;
            this.buttonDeleteAccount.Text = "Удалить аккаунт";
            this.buttonDeleteAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteAccount.Click += new System.EventHandler(this.ButtonDeleteAccount_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelProfile);
            this.panel3.Controls.Add(this.labelSchedule);
            this.panel3.Location = new System.Drawing.Point(-2, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(958, 40);
            this.panel3.TabIndex = 4;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelProfile.Location = new System.Drawing.Point(243, 16);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(53, 13);
            this.labelProfile.TabIndex = 10;
            this.labelProfile.Text = "Профиль";
            this.labelProfile.Click += new System.EventHandler(this.LabelProfile_Click);
            this.labelProfile.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelProfile.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // labelSchedule
            // 
            this.labelSchedule.AutoSize = true;
            this.labelSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSchedule.Location = new System.Drawing.Point(609, 16);
            this.labelSchedule.Name = "labelSchedule";
            this.labelSchedule.Size = new System.Drawing.Size(247, 13);
            this.labelSchedule.TabIndex = 7;
            this.labelSchedule.Text = "Распиание занятий / звонков / факультативов";
            this.labelSchedule.Click += new System.EventHandler(this.LabelSchedule_Click);
            this.labelSchedule.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelSchedule.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelEvents);
            this.panel4.Controls.Add(this.labelAdditioanalInf);
            this.panel4.Controls.Add(this.labelTeacherAndClasses);
            this.panel4.Location = new System.Drawing.Point(-2, 544);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 38);
            this.panel4.TabIndex = 5;
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelEvents.Location = new System.Drawing.Point(873, 11);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(75, 13);
            this.labelEvents.TabIndex = 8;
            this.labelEvents.Text = "Мероприятия";
            this.labelEvents.Click += new System.EventHandler(this.LabelEvents_Click);
            this.labelEvents.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelEvents.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // labelAdditioanalInf
            // 
            this.labelAdditioanalInf.AutoSize = true;
            this.labelAdditioanalInf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAdditioanalInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdditioanalInf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelAdditioanalInf.Location = new System.Drawing.Point(17, 11);
            this.labelAdditioanalInf.Name = "labelAdditioanalInf";
            this.labelAdditioanalInf.Size = new System.Drawing.Size(160, 13);
            this.labelAdditioanalInf.TabIndex = 9;
            this.labelAdditioanalInf.Text = "Дополнительная информация";
            this.labelAdditioanalInf.Click += new System.EventHandler(this.LabelAditionalInf_Click);
            this.labelAdditioanalInf.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelAdditioanalInf.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // labelTeacherAndClasses
            // 
            this.labelTeacherAndClasses.AutoSize = true;
            this.labelTeacherAndClasses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTeacherAndClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeacherAndClasses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelTeacherAndClasses.Location = new System.Drawing.Point(410, 11);
            this.labelTeacherAndClasses.Name = "labelTeacherAndClasses";
            this.labelTeacherAndClasses.Size = new System.Drawing.Size(149, 13);
            this.labelTeacherAndClasses.TabIndex = 6;
            this.labelTeacherAndClasses.Text = "Предметы и преподаватели";
            this.labelTeacherAndClasses.Click += new System.EventHandler(this.LabelTeacherAndClasses_Click);
            this.labelTeacherAndClasses.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.labelTeacherAndClasses.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 636);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню - Электронный дневник";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label labelSchedule;
        private System.Windows.Forms.Label labelAdditioanalInf;
        private System.Windows.Forms.Label labelTeacherAndClasses;
        private System.Windows.Forms.Label labelEvents;
        private System.Windows.Forms.Button buttonDeleteAccount;
    }
}