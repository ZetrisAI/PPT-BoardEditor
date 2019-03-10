using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PPTBoardEditor {
    public partial class PlayerForm : Form {
        public PlayerForm(int index) {
            InitializeComponent();
            windowIndex = index;
        }

        int windowIndex, playerIndex;
        
        int playerID {
            get => Convert.ToInt32(windowIndex != playerIndex);
        }

        int[,] board = new int[10, 40];
        int[] selectedColor = new int[2] {9, -1};

        int pieces = 0;
        int holdPTR = 0x0;
        bool dropState = false;
        
        private void scanTimer_Tick(object sender, EventArgs e) {
            playerIndex = GameHelper.FindPlayer();

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
            UIHelper.drawSelector(canvasSelector, (int[])selectedColor.Clone(), active);

            Text = (boardAddress >= 0x08000000) ? GameHelper.PlayerName(playerID) : $"Player {windowIndex + 1}";
        }

        bool canvasBoardPressed = false;

        private void canvasBoard_MouseDown(object sender, MouseEventArgs e) {
            canvasBoardPressed = true;
            canvasBoard_MouseMove(sender, e);
        }

        private void canvasBoard_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.None)
                canvasBoardPressed = false;
        }

        private void canvasBoard_MouseMove(object sender, MouseEventArgs e) {
            if (canvasBoardPressed) {
                int x = e.X / 15;
                int y = 39 - e.Y / 15;
                int boardAddress = GameHelper.BoardAddress(playerID);
                
                if (boardAddress >= 0x08000000 && 0 <= x && x <= 9 && 0 <= y && y <= 39 && board[x, y] != -2) {
                    int pixelAddress = GameHelper.DirectRead(
                        boardAddress + x * 0x08
                    ) + y * 0x04;

                    if (e.Button.HasFlag(MouseButtons.Left)) {
                        GameHelper.DirectWrite(pixelAddress, selectedColor[0]);
                    } else if (e.Button.HasFlag(MouseButtons.Right)) {
                        GameHelper.DirectWrite(pixelAddress, selectedColor[1]);
                    }
                   
                }
            }
        }

        bool canvasSelectorPressed = false;

        private void canvasSelector_MouseDown(object sender, MouseEventArgs e) {
            canvasSelectorPressed = true;
            canvasSelector_MouseMove(sender, e);
        }

        private void canvasSelector_MouseMove(object sender, MouseEventArgs e) {
            if (canvasSelectorPressed) {
                int x = e.X / 15;

                if (GameHelper.BoardAddress(playerID) > 0x08000000 && 0 <= x && x <= 9) {
                    if (x == 0) x = -1;
                    else if (x != 9) x--;

                    if (e.Button.HasFlag(MouseButtons.Left)) {
                        selectedColor[0] = x;
                    }
                    if (e.Button.HasFlag(MouseButtons.Right)) {
                        selectedColor[1] = x;
                    }
                }
            }
        }

        private void canvasSelector_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.None)
                canvasSelectorPressed = false;
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

        private void PlayerForm_FormClosing(object sender, EventArgs e) {
            Application.Exit();
        }

        private void buttonLoad_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                Filter = "PPT Board Files|*.tetboard",
            };

            if (ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists) {
                byte[] save = File.ReadAllBytes(ofd.FileName);

                int boardAddress = GameHelper.BoardAddress(playerID);

                int p = 0;
                for (int i = 0; i < 10; i++) {
                    int columnAddress = GameHelper.DirectRead(boardAddress + i * 0x08);
                    for (int j = 0; j < 40; j++) {
                        GameHelper.DirectWrite(columnAddress + j * 0x04, save[p] + ((save[p] > 127)? -256 : 0));
                        p++;
                    }
                }

                listQueue.Items.Clear();

                for (int i = 0; i < save.Length - 401; i++) {
                    listQueue.Items.Add(new Tetromino(save[p++]));
                }

                checkLoop.Checked = save[p++] > 0;
            }

            ofd.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog {
                Filter = "PPT Board Files|*.tetboard",
            };

            if (sfd.ShowDialog() == DialogResult.OK) {
                if (!sfd.CheckFileExists) {
                    File.Create(sfd.FileName).Close();
                }

                byte[] save = new byte[401 + listQueue.Items.Count];

                int p = 0;
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 40; j++) {
                        save[p++] = (byte)board[i,j];
                    }
                }

                for (int i = 0; i < listQueue.Items.Count; i++) {
                    save[p++] = (byte)((Tetromino)listQueue.Items[i]).Index;
                }

                save[p++] = (byte)(checkLoop.Checked? 1 : 0);

                File.WriteAllBytes(sfd.FileName, save);
            }

            sfd.Dispose();
        }

        private void listQueue_MouseUp(object sender, MouseEventArgs e) {
            lHolding = -1;
        }
    }
}
