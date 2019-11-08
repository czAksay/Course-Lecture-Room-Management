namespace ProjectK
{
    partial class ComputerExplorer
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
            this.flpComputerHardware = new System.Windows.Forms.FlowLayoutPanel();
            this.flpComputerSoftware = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.trgHardSowt = new ProjectK.ControlTrigger();
            this.SuspendLayout();
            // 
            // flpComputerHardware
            // 
            this.flpComputerHardware.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpComputerHardware.AutoScroll = true;
            this.flpComputerHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.flpComputerHardware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpComputerHardware.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpComputerHardware.Location = new System.Drawing.Point(7, 48);
            this.flpComputerHardware.Name = "flpComputerHardware";
            this.flpComputerHardware.Size = new System.Drawing.Size(472, 463);
            this.flpComputerHardware.TabIndex = 13;
            this.flpComputerHardware.Visible = false;
            this.flpComputerHardware.WrapContents = false;
            // 
            // flpComputerSoftware
            // 
            this.flpComputerSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpComputerSoftware.AutoScroll = true;
            this.flpComputerSoftware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.flpComputerSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpComputerSoftware.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpComputerSoftware.Location = new System.Drawing.Point(7, 48);
            this.flpComputerSoftware.Name = "flpComputerSoftware";
            this.flpComputerSoftware.Size = new System.Drawing.Size(472, 463);
            this.flpComputerSoftware.TabIndex = 15;
            this.flpComputerSoftware.WrapContents = false;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblCount.Location = new System.Drawing.Point(323, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(158, 35);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "Количество: 0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trgHardSowt
            // 
            this.trgHardSowt._BackColor1 = System.Drawing.Color.WhiteSmoke;
            this.trgHardSowt._BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.trgHardSowt._Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.trgHardSowt._Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.trgHardSowt._CurrentState = true;
            this.trgHardSowt._Text1 = "ПО";
            this.trgHardSowt._Text2 = "Комплектующие";
            this.trgHardSowt.Location = new System.Drawing.Point(7, 10);
            this.trgHardSowt.Name = "trgHardSowt";
            this.trgHardSowt.Size = new System.Drawing.Size(157, 32);
            this.trgHardSowt.TabIndex = 14;
            // 
            // ComputerExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpComputerSoftware);
            this.Controls.Add(this.trgHardSowt);
            this.Controls.Add(this.flpComputerHardware);
            this.Name = "ComputerExplorer";
            this.Size = new System.Drawing.Size(486, 519);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlTrigger trgHardSowt;
        private System.Windows.Forms.FlowLayoutPanel flpComputerHardware;
        private System.Windows.Forms.FlowLayoutPanel flpComputerSoftware;
        private System.Windows.Forms.Label lblCount;
    }
}
