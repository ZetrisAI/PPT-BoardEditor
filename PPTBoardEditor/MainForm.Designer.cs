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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.canvasBoard = new System.Windows.Forms.PictureBox();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.canvasSelector = new System.Windows.Forms.PictureBox();
            this.listQueue = new System.Windows.Forms.ListBox();
            this.checkLoop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSelector)).BeginInit();
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
            // canvasSelector
            // 
            this.canvasSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.canvasSelector.Location = new System.Drawing.Point(12, 618);
            this.canvasSelector.Name = "canvasSelector";
            this.canvasSelector.Size = new System.Drawing.Size(150, 15);
            this.canvasSelector.TabIndex = 1;
            this.canvasSelector.TabStop = false;
            this.canvasSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvasSelector_MouseClick);
            // 
            // listQueue
            // 
            this.listQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.listQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listQueue.ForeColor = System.Drawing.Color.Gainsboro;
            this.listQueue.FormattingEnabled = true;
            this.listQueue.Location = new System.Drawing.Point(168, 13);
            this.listQueue.Name = "listQueue";
            this.listQueue.Size = new System.Drawing.Size(32, 598);
            this.listQueue.TabIndex = 3;
            this.listQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listQueue_KeyDown);
            this.listQueue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseDoubleClick);
            this.listQueue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseDown);
            this.listQueue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseMove);
            this.listQueue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseUp);
            // 
            // checkLoop
            // 
            this.checkLoop.AutoSize = true;
            this.checkLoop.Location = new System.Drawing.Point(165, 618);
            this.checkLoop.Name = "checkLoop";
            this.checkLoop.Size = new System.Drawing.Size(50, 17);
            this.checkLoop.TabIndex = 4;
            this.checkLoop.Text = "Loop";
            this.checkLoop.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(214, 641);
            this.Controls.Add(this.checkLoop);
            this.Controls.Add(this.listQueue);
            this.Controls.Add(this.canvasSelector);
            this.Controls.Add(this.canvasBoard);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasBoard;
        private System.Windows.Forms.Timer scanTimer;
        private System.Windows.Forms.PictureBox canvasSelector;
        private System.Windows.Forms.ListBox listQueue;
        private System.Windows.Forms.CheckBox checkLoop;
    }
}

