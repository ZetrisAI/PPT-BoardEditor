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
                        gfx.FillRectangle(new SolidBrush(new Tetromino(board[i, j]).Color()), mino);

                        mino.Width--;
                        mino.Height--;
                        gfx.DrawRectangle(new Pen(Color.Black), mino);
                    }
                }

                gfx.DrawLine(new Pen(Color.Red), 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
                gfx.Flush();
            }
        }

        public static void drawSelector(PictureBox canvas, int color, bool active) {
            if (!active) {
                canvas.Image = null;
                return;
            }

            if (color == 8) return;
            if (color == -1) color = 0;
            else if (color != 9) color++;

            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics gfx = Graphics.FromImage(canvas.Image)) {
                for (int i = 0; i < 10; i++) {
                    int j = i;
                    if (j == 0) j = -1;
                    else if (j != 9) j--;

                    gfx.FillRectangle(new SolidBrush(new Tetromino(j).Color()), i * (canvas.Width / 10), 0, canvas.Width / 10, canvas.Height);
                }

                gfx.DrawRectangle(new Pen(Color.Black), color * (canvas.Width / 10), 0, canvas.Width / 10 - 1, canvas.Height - 1);
                gfx.Flush();
            }
        }
    }
}
