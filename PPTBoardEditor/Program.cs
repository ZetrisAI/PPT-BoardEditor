using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PPTBoardEditor {
    static class Program {
        static PlayerForm player;

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            player = new PlayerForm();
            player.Show();

            Application.Run();
        }
    }
}
