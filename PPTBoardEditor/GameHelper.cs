using System;
using System.Diagnostics;

namespace PPTBoardEditor {
    static class GameHelper {
        static VAMemory Game = new VAMemory("puyopuyotetris");

        public static bool EnsureGame() {
            if (Game == null) {
                if (Process.GetProcessesByName("puyopuyotetris").Length != 0) {
                    Game = new VAMemory("puyopuyotetris");
                } else {
                    return false;
                }

            } else if (Process.GetProcessesByName("puyopuyotetris").Length == 0) {
                Game = null;
                return false;
            }

            return true;
        }

        public static int DirectRead(int address) => Game.ReadInt32(new IntPtr(address));
        public static bool DirectWrite(int address, int value) => Game.WriteInt32(new IntPtr(address), value);

        public static int PlayerCount() {
            int ret = Game.ReadByte(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        0x140473760
                    )) + 0x20
                )) + 0xB4
            ));

            if (ret > 4) ret = 0;
            if (ret < 0) ret = 0;

            return ret;
        }

        public static int LocalSteam() => Game.ReadInt32(new IntPtr(
            0x1405A2010
        ));

        public static int PlayerSteam(int index) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    0x140473760
                )) + 0x20
            )) + 0x118 + index * 0x50
        ));

        public static int FindPlayer() {
            if (PlayerCount() < 2)
                return 0;

            int localSteam = LocalSteam();

            for (int i = 0; i < 2; i++)
                if (localSteam == PlayerSteam(i))
                    return i;

            return 0;
        }

        public static int BoardAddress(int index) {
            switch (index) {
                case 0:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140598A20
                                )) + 0x38
                            )) + 0x3C0
                        )) + 0x18
                    ));

                case 1:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x1405989D8
                                )) + 0x28
                            )) + 0x3C0
                        )) + 0x18
                    ));
            }

            return -1;
        }      
    }
}
