namespace Test
{
    partial class TestForm
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
            this.testLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // testLbl
            // 
            this.testLbl.AutoSize = true;
            this.testLbl.Location = new System.Drawing.Point(379, 271);
            this.testLbl.Name = "testLbl";
            this.testLbl.Size = new System.Drawing.Size(119, 13);
            this.testLbl.TabIndex = 0;
            this.testLbl.Text = "Fuck you for testing this";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 850);
            this.Controls.Add(this.testLbl);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testLbl;
    }
}