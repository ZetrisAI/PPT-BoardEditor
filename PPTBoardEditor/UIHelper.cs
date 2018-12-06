using System.Drawing;
using System.Windows.Forms;

namespace PPTBoardEditor {
    class UIHelper {
        public static void drawBoard(PictureBox canvas, int[,] board, bool active) {
            if (!active) {
                canvas.Image = null;
                return;
            }

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics gfx = Graphics.FromImage(canvas.Image)) {
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 40; j++) {
                        Rectangle mino = new Rectangle(i * (canvas.Width / 10), (39 - j) * (canvas.Height / 40), canvas.Width / 10, canvas.Height / 40);
                        gfx.FillRectangle(new SolidBrush(Tetromino.BoardColor(board[i, j])), mino);

                        mino.Width--;
                        mino.Height--;
                        gfx.DrawRectangle(new Pen(Color.Black), mino);
                    }
                }

                gfx.DrawLine(new Pen(Color.Red), 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
                gfx.Flush();
            }
        }

        public static void drawSelector(PictureBox canvas, int[] colors, bool active) {
            if (!active) {
                canvas.Image = null;
                return;
            }

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics gfx = Graphics.FromImage(canvas.Image)) {
                for (int i = 0; i < 10; i++) {
                    int j = i;
                    if (j == 0) j = -1;
                    else if (j != 9) j--;

                    Rectangle mino = new Rectangle(i * (canvas.Width / 10), 0, canvas.Width / 10, canvas.Height);
                    gfx.FillRectangle(new SolidBrush(Tetromino.BoardColor(j)), i * (canvas.Width / 10), 0, canvas.Width / 10, canvas.Height);
                    
                    mino.Width--;
                    mino.Height--;
                    gfx.DrawRectangle(new Pen(Color.Black), mino);
                }

                for (int i = 0; i < 2; i++) {
                    if (colors[i] == 8) return;
                    if (colors[i] == -1) colors[i] = 0;
                    else if (colors[i] != 9) colors[i]++;
                }

                gfx.DrawRectangle(new Pen(Color.White), colors[0] * (canvas.Width / 10), 0, canvas.Width / 10 - 1, canvas.Height - 1);
                gfx.DrawRectangle(new Pen(Color.Black), colors[0] * (canvas.Width / 10) + 1, 1, canvas.Width / 10 - 3, canvas.Height - 3);

                gfx.DrawRectangle(new Pen(Color.White), colors[1] * (canvas.Width / 10) + 2, 2, canvas.Width / 10 - 5, canvas.Height - 5);
                gfx.DrawRectangle(new Pen(Color.Black), colors[1] * (canvas.Width / 10) + 3, 3, canvas.Width / 10 - 7, canvas.Height - 7);

                gfx.Flush();
            }
        }
    }
}
