namespace PPTBoardEditor {
    partial class PlayerForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.canvasBoard = new System.Windows.Forms.PictureBox();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.canvasSelector = new System.Windows.Forms.PictureBox();
            this.listQueue = new System.Windows.Forms.ListBox();
            this.checkLoop = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.canvasSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasSelector_MouseDown);
            this.canvasSelector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasSelector_MouseMove);
            this.canvasSelector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasSelector_MouseUp);
            // 
            // listQueue
            // 
            this.listQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.listQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listQueue.ForeColor = System.Drawing.Color.Gainsboro;
            this.listQueue.FormattingEnabled = true;
            this.listQueue.Location = new System.Drawing.Point(168, 13);
            this.listQueue.Name = "listQueue";
            this.listQueue.Size = new System.Drawing.Size(32, 533);
            this.listQueue.TabIndex = 3;
            this.listQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listQueue_KeyDown);
            this.listQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listQueue_KeyUp);
            this.listQueue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseDoubleClick);
            this.listQueue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseDown);
            this.listQueue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseMove);
            this.listQueue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listQueue_MouseUp);
            // 
            // checkLoop
            // 
            this.checkLoop.AutoSize = true;
            this.checkLoop.Location = new System.Drawing.Point(168, 549);
            this.checkLoop.Name = "checkLoop";
            this.checkLoop.Size = new System.Drawing.Size(38, 17);
            this.checkLoop.TabIndex = 4;
            this.checkLoop.Text = "🔁";
            this.checkLoop.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Location = new System.Drawing.Point(168, 573);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(32, 28);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "📂";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(168, 605);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(32, 28);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "💾";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(52, 639);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(90, 639);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(130, 639);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 28);
            this.button4.TabIndex = 9;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(168, 647);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(32, 13);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Player";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(214, 674);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.checkLoop);
            this.Controls.Add(this.listQueue);
            this.Controls.Add(this.canvasSelector);
            this.Controls.Add(this.canvasBoard);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
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
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
    }
}

