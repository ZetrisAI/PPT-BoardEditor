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

        public static bool InMatch() {
            return Game.ReadInt32(new IntPtr(0x140573A78)) == 0x0;
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

        public static int QueueAddress(int index) {
            switch (index) {
                case 0:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                0x140461B20
                            )) + 0x378
                        )) + 0xB8
                    )) + 0x15C;

                case 1:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x1405989D0
                                )) + 0x78
                            )) + 0x28
                        )) + 0xB8
                    )) + 0x15C;
            }

            return -1;
        }

        public static int CurrentPiece(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140461B20
                                    )) + 0x378
                                )) + 0x40
                            )) + 0x140
                        )) + 0x110
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x1404611B8
                                    )) + 0x30
                                )) + 0xB0
                            )) + 0x60
                        )) + 0x640
                    ));
            }

            return -1;
        }

        public static int RotationPointer(int index) {
            switch (index) {
                case 0:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140460C08
                                    )) + 0x18
                                )) + 0x268
                            )) + 0x38
                        )) + 0x3C8
                    )) + 0x18;

                case 1:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x1405989D0
                                    )) + 0x78
                                )) + 0x20
                            )) + 0xA8
                        )) + 0x3C8
                    )) + 0x18;
            }

            return -1;
        }

        public static int HoldPointer(int index) {
            switch (index) {
                case 0:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                0x140598A20
                            )) + 0x38
                        )) + 0x3D0
                    )) + 0x8;

                case 1:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x1405989D0
                                )) + 0x270
                            )) + 0x20
                        )) + 0x3D0
                    )) + 0x8;
            }

            return -1;
        }

        public static bool PieceDropped(int index) {
            int ret = 0;

            switch (index) {
                case 0:
                    ret = Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x140460C08
                                        )) + 0x18
                                    )) + 0x268
                                )) + 0x38
                            )) + 0x3C8
                        )) + 0x1C
                    ));
                    break;

                case 1:
                    ret = Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x1405989D0
                                        )) + 0x78
                                    )) + 0x20
                                )) + 0xA8
                            )) + 0x3C8
                        )) + 0x1C
                    ));
                    break;
            }

            return ret != 0;
        }

        public static int FrameCount() => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            0x140598A20
                        )) + 0x138
                    )) + 0x18
                )) + 0x100
            )) + 0x58
        ));
    }
}
