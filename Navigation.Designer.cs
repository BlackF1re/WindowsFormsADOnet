namespace WindowsFormsADOnet
{
    partial class Navigation
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGotoAdd = new System.Windows.Forms.Button();
            this.btnGotoFillOrCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(80, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose action.";
            // 
            // btnGotoAdd
            // 
            this.btnGotoAdd.Location = new System.Drawing.Point(284, 126);
            this.btnGotoAdd.Name = "btnGotoAdd";
            this.btnGotoAdd.Size = new System.Drawing.Size(190, 56);
            this.btnGotoAdd.TabIndex = 1;
            this.btnGotoAdd.Text = "Add account";
            this.btnGotoAdd.UseVisualStyleBackColor = true;
            this.btnGotoAdd.Click += new System.EventHandler(this.BtnGotoAdd_Click);
            // 
            // btnGotoFillOrCancel
            // 
            this.btnGotoFillOrCancel.Location = new System.Drawing.Point(284, 227);
            this.btnGotoFillOrCancel.Name = "btnGotoFillOrCancel";
            this.btnGotoFillOrCancel.Size = new System.Drawing.Size(190, 56);
            this.btnGotoFillOrCancel.TabIndex = 2;
            this.btnGotoFillOrCancel.Text = "Create or fill order";
            this.btnGotoFillOrCancel.UseVisualStyleBackColor = true;
            this.btnGotoFillOrCancel.Click += new System.EventHandler(this.BtnGotoFillOrCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(284, 327);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(190, 53);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGotoFillOrCancel);
            this.Controls.Add(this.btnGotoAdd);
            this.Controls.Add(this.label1);
            this.Name = "Navigation";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGotoAdd;
        private System.Windows.Forms.Button btnGotoFillOrCancel;
        private System.Windows.Forms.Button btnExit;
    }
}

