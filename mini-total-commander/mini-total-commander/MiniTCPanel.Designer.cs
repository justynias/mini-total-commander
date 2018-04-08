namespace mini_total_commander
{
    partial class MiniTCPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(258, 56);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(50, 21);
            this.comboBoxDrives.TabIndex = 0;
            this.comboBoxDrives.DropDown += new System.EventHandler(this.loadDrives);
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.changeDrive);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(37, 30);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(271, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "F:\\cszar";
            this.textBoxPath.TextChanged += new System.EventHandler(this.PathChanged);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(37, 113);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(271, 277);
            this.listBox.TabIndex = 5;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.SelectedItem);
            this.listBox.DoubleClick += new System.EventHandler(this.ExecutePath);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(37, 82);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(56, 23);
            this.buttonReturn.TabIndex = 6;
            this.buttonReturn.Text = "...";
            this.buttonReturn.UseVisualStyleBackColor = true;
            // 
            // MiniTCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.comboBoxDrives);
            this.Name = "MiniTCPanel";
            this.Size = new System.Drawing.Size(346, 413);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonReturn;
    }
}
