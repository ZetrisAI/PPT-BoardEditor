using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PPTBoardEditor {
    static class Program {
        static PlayerForm[] players = new PlayerForm[1];

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            players[0] = new PlayerForm(0);
            players[0].Show();

            Application.Run();
        }
    }
}
