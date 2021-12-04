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
            this.addButton = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.ErrorListBox = new System.Windows.Forms.ListBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.listBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 295);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.AllowDrop = true;
            this.listBoxFiles.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBoxFiles.ForeColor = System.Drawing.SystemColors.Window;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 31);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxFiles.Size = new System.Drawing.Size(600, 244);
            this.listBoxFiles.TabIndex = 1;
            this.listBoxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragDrop);
            this.listBoxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragEnter);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(93, 295);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(537, 295);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 3;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // ErrorListBox
            // 
            this.ErrorListBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ErrorListBox.ForeColor = System.Drawing.Color.White;
            this.ErrorListBox.FormattingEnabled = true;
            this.ErrorListBox.ItemHeight = 15;
            this.ErrorListBox.Location = new System.Drawing.Point(627, 31);
            this.ErrorListBox.Name = "ErrorListBox";
            this.ErrorListBox.ScrollAlwaysVisible = true;
            this.ErrorListBox.Size = new System.Drawing.Size(431, 244);
            this.ErrorListBox.TabIndex = 4;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.errorLabel.Location = new System.Drawing.Point(627, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(61, 15);
            this.errorLabel.TabIndex = 5;
            this.errorLabel.Text = "Error Texts";
            // 
            // listBoxLabel
            // 
            this.listBoxLabel.AutoSize = true;
            this.listBoxLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.listBoxLabel.Location = new System.Drawing.Point(12, 9);
            this.listBoxLabel.Name = "listBoxLabel";
            this.listBoxLabel.Size = new System.Drawing.Size(132, 15);
            this.listBoxLabel.TabIndex = 6;
            this.listBoxLabel.Text = "Selected files to process";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1076, 346);
            this.Controls.Add(this.listBoxLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.ErrorListBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.addButton);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Load Updating Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addButton;
        private ListBox listBoxFiles;
        private Button removeButton;
        private Button processButton;
        private ListBox ErrorListBox;
        private Label errorLabel;
        private Label listBoxLabel;
    }
}