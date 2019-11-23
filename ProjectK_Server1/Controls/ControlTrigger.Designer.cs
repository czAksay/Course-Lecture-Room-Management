namespace ProjectK_Server1
{
    partial class ControlTrigger
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pbArrow = new System.Windows.Forms.PictureBox();
            this.btnText = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pbArrow);
            this.pnlMain.Controls.Add(this.btnText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(167, 32);
            this.pnlMain.TabIndex = 0;
            // 
            // pbArrow
            // 
            this.pbArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbArrow.Image = global::ProjectK_Server1.Properties.Resources.right;
            this.pbArrow.Location = new System.Drawing.Point(132, 0);
            this.pbArrow.Name = "pbArrow";
            this.pbArrow.Size = new System.Drawing.Size(33, 30);
            this.pbArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArrow.TabIndex = 1;
            this.pbArrow.TabStop = false;
            // 
            // btnText
            // 
            this.btnText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnText.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnText.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnText.Location = new System.Drawing.Point(0, 0);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(132, 30);
            this.btnText.TabIndex = 0;
            this.btnText.TabStop = false;
            this.btnText.Text = "Текст";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.BtnText_Click);
            // 
            // ControlTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ControlTrigger";
            this.Size = new System.Drawing.Size(167, 32);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.PictureBox pbArrow;
    }
}
