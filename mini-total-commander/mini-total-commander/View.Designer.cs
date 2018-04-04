namespace mini_total_commander
{
    partial class View
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
            this.miniTCPanel2 = new mini_total_commander.MiniTCPanel();
            this.miniTCPanel1 = new mini_total_commander.MiniTCPanel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // miniTCPanel2
            // 
            this.miniTCPanel2.CurrentPath = "";
            this.miniTCPanel2.Dir = null;
            this.miniTCPanel2.Drives = null;
            this.miniTCPanel2.Files = null;
            this.miniTCPanel2.Location = new System.Drawing.Point(353, 12);
            this.miniTCPanel2.Name = "miniTCPanel2";
            this.miniTCPanel2.Selected = null;
            this.miniTCPanel2.Size = new System.Drawing.Size(346, 462);
            this.miniTCPanel2.TabIndex = 1;
            // 
            // miniTCPanel1
            // 
            this.miniTCPanel1.CurrentPath = "";
            this.miniTCPanel1.Dir = null;
            this.miniTCPanel1.Drives = null;
            this.miniTCPanel1.Files = null;
            this.miniTCPanel1.Location = new System.Drawing.Point(1, 12);
            this.miniTCPanel1.Name = "miniTCPanel1";
            this.miniTCPanel1.Selected = null;
            this.miniTCPanel1.Size = new System.Drawing.Size(346, 462);
            this.miniTCPanel1.TabIndex = 0;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(170, 438);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonClicked);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(441, 438);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 3;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonClicked);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(313, 438);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonClicked);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 487);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.miniTCPanel2);
            this.Controls.Add(this.miniTCPanel1);
            this.Name = "View";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MiniTCPanel miniTCPanel1;
        private MiniTCPanel miniTCPanel2;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonCopy;
    }
}

