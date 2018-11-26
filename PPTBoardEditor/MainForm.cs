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
                int boardAddress = GameHelper.BoardAddress(GameHelper.FindPlayer());

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

        bool mPressed = false;

        private void canvasBoard_MouseDown(object sender, MouseEventArgs e) {
            mPressed = true;
            canvasBoard_MouseMove(sender, e);
        }

        private void canvasBoard_MouseUp(object sender, MouseEventArgs e) {
            mPressed = false;
        }

        private void canvasBoard_MouseMove(object sender, MouseEventArgs e) {
            if (mPressed && GameHelper.EnsureGame()) {
                int x = e.X, y = e.Y;
                x /= 15; y /= 15;
                y = 39 - y;

                int boardAddress = GameHelper.BoardAddress(GameHelper.FindPlayer());
                
                if (boardAddress >= 0x08000000 && 0 <= x && x <= 9 && 0 <= y && y <= 39)
                    GameHelper.DirectWrite(
                        GameHelper.DirectRead(
                            GameHelper.BoardAddress(
                                GameHelper.FindPlayer()
                            ) + x * 0x08
                        ) + y * 0x04,
                        0x09
                    );

                label1.Text = x.ToString();
                label2.Text = y.ToString();
            }
        }
    }
}
