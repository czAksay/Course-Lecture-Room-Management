namespace ProjectK
{
    partial class NumberAssign
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
            this.computerNumberInput1 = new ProjectK.Controls.ComputerNumberInput();
            this.SuspendLayout();
            // 
            // computerNumberInput1
            // 
            this.computerNumberInput1._Number = "";
            this.computerNumberInput1.BackColor = System.Drawing.Color.White;
            this.computerNumberInput1.Location = new System.Drawing.Point(22, 15);
            this.computerNumberInput1.Name = "computerNumberInput1";
            this.computerNumberInput1.Size = new System.Drawing.Size(299, 162);
            this.computerNumberInput1.TabIndex = 0;
            // 
            // NumberAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 189);
            this.Controls.Add(this.computerNumberInput1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NumberAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Введите номер";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ComputerNumberInput computerNumberInput1;
    }
}