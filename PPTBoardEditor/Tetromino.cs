using System;
using System.Drawing;

namespace PPTBoardEditor {
    public class Tetromino {
        private int _index;

        public int Index {
            get {
                return _index;
            }
        }

        public Color Color() {
            switch (_index) {
                case 0: return System.Drawing.Color.FromArgb(0, 255, 0);
                case 1: return System.Drawing.Color.FromArgb(255, 0, 0);
                case 2: return System.Drawing.Color.FromArgb(0, 0, 255);
                case 3: return System.Drawing.Color.FromArgb(255, 63, 0);
                case 4: return System.Drawing.Color.FromArgb(63, 0, 255);
                case 5: return System.Drawing.Color.FromArgb(255, 255, 0);
                case 6: return System.Drawing.Color.FromArgb(0, 255, 255);
                case 7:
                case 8: return System.Drawing.Color.Goldenrod;
                case 9: return System.Drawing.Color.FromArgb(255, 255, 255);
            }

            return System.Drawing.Color.Transparent;
        }

        public override string ToString() {
            switch (_index) {
                case 0: return "S";
                case 1: return "Z";
                case 2: return "J";
                case 3: return "L";
                case 4: return "T";
                case 5: return "O";
                case 6: return "I";
                case 7: return "M";
                case 8: return "D";
                case 9: return "G";
            }

            return ".";
        }

        public Tetromino(int index) {
            _index = index;
        }
    }
}
