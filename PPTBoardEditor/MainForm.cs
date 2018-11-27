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

        int pieces = 0;
        bool dropState = false;

        int[] customQueue = new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 };

        private void scanTimer_Tick(object sender, EventArgs e) {
            if (GameHelper.EnsureGame()) {
                int playerID = GameHelper.FindPlayer();

                int boardAddress = GameHelper.BoardAddress(playerID);
                bool active = boardAddress > 0x08000000;

                if (active) {
                    for (int i = 0; i < 10; i++) {
                        int columnAddress = GameHelper.DirectRead(boardAddress + i * 0x08);
                        for (int j = 0; j < 40; j++) {
                            board[i, j] = GameHelper.DirectRead(columnAddress + j * 0x04);
                        }
                    }

                    bool drop = GameHelper.PieceDropped(playerID);
                    if (drop != dropState) {
                        if (!drop) pieces++;
                        dropState = drop;
                    }

                    int queueAddress = GameHelper.QueueAddress(playerID);
                    int current = GameHelper.CurrentPiece(playerID);
                    if (current == 255 && GameHelper.FrameCount() < 140) {
                        for (int i = 0; i < 5; i++) {
                            GameHelper.DirectWrite(queueAddress + i * 0x04, customQueue[pieces + i]);
                        }
                    }

                    if (current != 255 && pieces + 5 < customQueue.Length) {
                        GameHelper.DirectWrite(queueAddress + 0x10, customQueue[pieces + 5]);
                    }

                } else {
                    int[,] board = new int[10, 40];

                    pieces = 0;
                    dropState = false;
                }

                UIHelper.drawBoard(canvasBoard, board, active);
                UIHelper.drawSelector(canvasSelector, selectedColor, active);

                label1.Text = pieces.ToString();
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
            if (GameHelper.EnsureGame()) {
                int x = e.X / 15;

                if (GameHelper.BoardAddress(GameHelper.FindPlayer()) > 0x08000000 && 0 <= x && x <= 9) {
                    if (x == 0) x = -1;
                    else if (x != 9) x--;
                    selectedColor = x;
                }
            }
        }
    }
}
