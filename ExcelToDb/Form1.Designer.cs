namespace ExcelToDb
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bInsert = new System.Windows.Forms.Button();
            this.txtBuffer = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bSaveDb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bInsert
            // 
            this.bInsert.Location = new System.Drawing.Point(26, 12);
            this.bInsert.Name = "bInsert";
            this.bInsert.Size = new System.Drawing.Size(247, 23);
            this.bInsert.TabIndex = 0;
            this.bInsert.Text = "Вставить содержимое буфера обмена";
            this.bInsert.UseVisualStyleBackColor = true;
            this.bInsert.Click += new System.EventHandler(this.bInsert_Click);
            // 
            // txtBuffer
            // 
            this.txtBuffer.Location = new System.Drawing.Point(12, 67);
            this.txtBuffer.Multiline = true;
            this.txtBuffer.Name = "txtBuffer";
            this.txtBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBuffer.Size = new System.Drawing.Size(776, 114);
            this.txtBuffer.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 241);
            this.dataGridView1.TabIndex = 2;
            // 
            // bSaveDb
            // 
            this.bSaveDb.Location = new System.Drawing.Point(26, 465);
            this.bSaveDb.Name = "bSaveDb";
            this.bSaveDb.Size = new System.Drawing.Size(141, 23);
            this.bSaveDb.TabIndex = 3;
            this.bSaveDb.Text = "Записать в  Sqlite БД";
            this.bSaveDb.UseVisualStyleBackColor = true;
            this.bSaveDb.Click += new System.EventHandler(this.bSaveDb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "В виде текста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "В виде таблицы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSaveDb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtBuffer);
            this.Controls.Add(this.bInsert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bInsert;
        private System.Windows.Forms.TextBox txtBuffer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bSaveDb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

