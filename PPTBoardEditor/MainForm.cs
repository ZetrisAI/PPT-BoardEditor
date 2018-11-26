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
        int selectedColor = 0;

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
                UIHelper.drawSelector(canvasSelector, selectedColor);
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
                int x = e.X / 15;
                int y = 39 - e.Y / 15;
                int boardAddress = GameHelper.BoardAddress(GameHelper.FindPlayer());
                
                if (boardAddress >= 0x08000000 && 0 <= x && x <= 9 && 0 <= y && y <= 39) {
                    GameHelper.DirectWrite(
                        GameHelper.DirectRead(
                            boardAddress + x * 0x08
                        ) + y * 0x04,
                        selectedColor
                    );
                }
            }
        }
    
        private void canvasSelector_MouseClick(object sender, MouseEventArgs e) {
            int x = e.X / 15;
            
            if (0 <= x && x <= 9) {
                if (x == 0) x = -1;
                else if (x != 9) x--;
                selectedColor = x;
            }
        }
    }
}
