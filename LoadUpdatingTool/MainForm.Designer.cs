namespace LoadUpdatingTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.GB_LoadData = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GB_LoadData
            // 
            this.GB_LoadData.Location = new System.Drawing.Point(24, 53);
            this.GB_LoadData.Name = "GB_LoadData";
            this.GB_LoadData.Size = new System.Drawing.Size(474, 278);
            this.GB_LoadData.TabIndex = 1;
            this.GB_LoadData.TabStop = false;
            this.GB_LoadData.Text = "Files to load";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(624, 360);
            this.Controls.Add(this.GB_LoadData);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Load Updating Tool";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GB_LoadData_DragDrop);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private GroupBox GB_LoadData;
    }
}