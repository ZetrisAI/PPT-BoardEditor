namespace PPTBoardEditor {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.canvasBoard = new System.Windows.Forms.PictureBox();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasBoard
            // 
            this.canvasBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.canvasBoard.Location = new System.Drawing.Point(12, 12);
            this.canvasBoard.Name = "canvasBoard";
            this.canvasBoard.Size = new System.Drawing.Size(150, 600);
            this.canvasBoard.TabIndex = 0;
            this.canvasBoard.TabStop = false;
            this.canvasBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasBoard_MouseDown);
            this.canvasBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBoard_MouseMove);
            this.canvasBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasBoard_MouseUp);
            // 
            // scanTimer
            // 
            this.scanTimer.Enabled = true;
            this.scanTimer.Interval = 1;
            this.scanTimer.Tick += new System.EventHandler(this.scanTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(247, 624);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvasBoard);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasBoard;
        private System.Windows.Forms.Timer scanTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

