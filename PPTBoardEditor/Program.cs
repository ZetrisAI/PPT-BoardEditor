using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PPTBoardEditor {
    static class Program {
        static PlayerForm[] players = new PlayerForm[2];

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            for (int i = 0; i < 2; i++) {
                players[i] = new PlayerForm(i);
                players[i].Show();
            }

            Application.Run();
        }
    }
}
