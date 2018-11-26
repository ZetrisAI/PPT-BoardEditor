using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPTBoardEditor {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        int[,] board = new int[10, 40];

        private void scanTimer_Tick(object sender, EventArgs e) {
            if (GameHelper.EnsureGame()) {
                int playerID = GameHelper.FindPlayer();
                int boardAddress = GameHelper.BoardAddress(playerID);

                for (int i = 0; i < 10; i++) {
                    int columnAddress = GameHelper.DirectRead(boardAddress + i * 0x08);
                    for (int j = 0; j < 40; j++) {
                        board[i, j] = GameHelper.DirectRead(columnAddress + j * 0x04);
                    }
                }

                UIHelper.drawBoard(canvasBoard, board);
            } else {
                board = new int[10, 40];
            }
        }
    }
}
