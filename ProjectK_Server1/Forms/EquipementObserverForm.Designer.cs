namespace ProjectK_Server1
{
    partial class EquipementObserverForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpEquips = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(140, 28);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Оборудование";
            // 
            // flpEquips
            // 
            this.flpEquips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpEquips.AutoScroll = true;
            this.flpEquips.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpEquips.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpEquips.Location = new System.Drawing.Point(11, 51);
            this.flpEquips.Name = "flpEquips";
            this.flpEquips.Size = new System.Drawing.Size(539, 482);
            this.flpEquips.TabIndex = 4;
            this.flpEquips.WrapContents = false;
            // 
            // EquipementObserverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 542);
            this.Controls.Add(this.flpEquips);
            this.Controls.Add(this.lblTitle);
            this.Name = "EquipementObserverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpEquips;
    }
}