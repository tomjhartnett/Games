namespace RNGItemsExample1
{
    partial class MainForm
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
            this.fightPanel = new System.Windows.Forms.Panel();
            this.inventoryPanel = new System.Windows.Forms.Panel();
            this.characterPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // fightPanel
            // 
            this.fightPanel.Location = new System.Drawing.Point(41, 128);
            this.fightPanel.Name = "fightPanel";
            this.fightPanel.Size = new System.Drawing.Size(393, 719);
            this.fightPanel.TabIndex = 0;
            // 
            // inventoryPanel
            // 
            this.inventoryPanel.Location = new System.Drawing.Point(466, 169);
            this.inventoryPanel.Name = "inventoryPanel";
            this.inventoryPanel.Size = new System.Drawing.Size(474, 757);
            this.inventoryPanel.TabIndex = 1;
            // 
            // characterPanel
            // 
            this.characterPanel.Location = new System.Drawing.Point(969, 33);
            this.characterPanel.Name = "characterPanel";
            this.characterPanel.Size = new System.Drawing.Size(549, 949);
            this.characterPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 1013);
            this.Controls.Add(this.characterPanel);
            this.Controls.Add(this.inventoryPanel);
            this.Controls.Add(this.fightPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fightPanel;
        private System.Windows.Forms.Panel inventoryPanel;
        private System.Windows.Forms.Panel characterPanel;
    }
}