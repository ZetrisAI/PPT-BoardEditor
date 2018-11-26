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
            // 
            // scanTimer
            // 
            this.scanTimer.Enabled = true;
            this.scanTimer.Interval = 1;
            this.scanTimer.Tick += new System.EventHandler(this.scanTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(174, 624);
            this.Controls.Add(this.canvasBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasBoard;
        private System.Windows.Forms.Timer scanTimer;
    }
}

