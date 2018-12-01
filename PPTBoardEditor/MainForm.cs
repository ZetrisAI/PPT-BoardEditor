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
        int holdPTR = 0x0;
        bool dropState = false;

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
                    if (current == 255 && GameHelper.FrameCount() < 140 && listQueue.Items.Count > 0) {
                        for (int i = 0; i < (checkLoop.Checked? 5 : Math.Min(5, listQueue.Items.Count)); i++) {
                            GameHelper.DirectWrite(queueAddress + i * 0x04, ((Tetromino)listQueue.Items[(pieces + i) % listQueue.Items.Count]).Index);
                        }
                    }

                    int hold = GameHelper.HoldPointer(playerID);
                    if (holdPTR != hold && holdPTR < 0x08000000 && hold >= 0x08000000) {
                        int rot = GameHelper.RotationPointer(playerID);
                        if (rot >= 0x08000000) {
                            pieces++;
                        } else {
                            hold = 0x8;
                        }
                    }
                    holdPTR = hold;

                    if (current != 255 && (pieces + 5 < listQueue.Items.Count || (checkLoop.Checked && listQueue.Items.Count > 0))) {
                        GameHelper.DirectWrite(queueAddress + 0x10, ((Tetromino)listQueue.Items[(pieces + 5) % listQueue.Items.Count]).Index);
                    }

                } else {
                    int[,] board = new int[10, 40];

                    pieces = 0;
                    dropState = false;
                }

                UIHelper.drawBoard(canvasBoard, board, active);
                UIHelper.drawSelector(canvasSelector, selectedColor, active);
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

        bool pentomino = false;
        
        private void listQueue_KeyDown(object sender, KeyEventArgs e) {
            int index = listQueue.SelectedIndex;
            if (index == -1) index = listQueue.Items.Count;

            switch (e.KeyCode) {
                case Keys.S:
                    listQueue.Items.Insert(index, new Tetromino(0 + (pentomino? 8 : 0)));
                    break;

                case Keys.Z:
                    listQueue.Items.Insert(index, new Tetromino(1 + (pentomino ? 8 : 0)));
                    break;

                case Keys.J:
                    listQueue.Items.Insert(index, new Tetromino(2 + (pentomino ? 8 : 0)));
                    break;

                case Keys.L:
                    listQueue.Items.Insert(index, new Tetromino(3 + (pentomino ? 8 : 0)));
                    break;

                case Keys.T:
                    listQueue.Items.Insert(index, new Tetromino(4 + (pentomino ? 8 : 0)));
                    break;

                case Keys.O:
                    listQueue.Items.Insert(index, new Tetromino(5 + (pentomino ? 8 : 0)));
                    break;

                case Keys.I:
                    listQueue.Items.Insert(index, new Tetromino(6 + (pentomino ? 8 : 0)));
                    break;

                case Keys.M:
                    listQueue.Items.Insert(index, new Tetromino(7));
                    break;

                case Keys.D5:
                    pentomino = true;
                    break;

                case Keys.Delete:
                    if (index != listQueue.Items.Count) {
                        listQueue.Items.RemoveAt(index);
                        if (index == listQueue.Items.Count) {
                            listQueue.SelectedIndex = index - 1;
                        } else {
                            listQueue.SelectedIndex = index;
                        }
                    }
                    break;
            }
            
            e.SuppressKeyPress = true;
        }

        private void listQueue_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.D5) {
                pentomino = false;
            }

            e.SuppressKeyPress = true;
        }

        private void listQueue_MouseDoubleClick(object sender, MouseEventArgs e) {
            int index = listQueue.IndexFromPoint(e.X, e.Y);

            if (index != -1) {
                listQueue.Items.RemoveAt(index);
            }
        }

        int lHolding = -1;

        private void listQueue_MouseDown(object sender, MouseEventArgs e) {
            int index = listQueue.IndexFromPoint(e.X, e.Y);

            if (index != -1) {
                lHolding = index;
            } else {
                listQueue.SelectedIndex = -1;
            }
        }

        private void listQueue_MouseMove(object sender, MouseEventArgs e) {
            int index = listQueue.IndexFromPoint(e.X, e.Y);

            if (lHolding != -1 && index != -1 && index != lHolding) {
                var item = listQueue.Items[lHolding];
                listQueue.Items.RemoveAt(lHolding);

                listQueue.Items.Insert(index, item);
                lHolding = index;
            }
        }

        private void listQueue_MouseUp(object sender, MouseEventArgs e) {
            lHolding = -1;
        }
    }
}
