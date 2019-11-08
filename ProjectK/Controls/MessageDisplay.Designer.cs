namespace ProjectK
{
    partial class MessageDisplay
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
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.Font = new System.Drawing.Font("Segoe UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(11, 13);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(232, 318);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Текст";
            // 
            // MessageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelText);
            this.Name = "MessageDisplay";
            this.Size = new System.Drawing.Size(254, 343);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelText;
    }
}
