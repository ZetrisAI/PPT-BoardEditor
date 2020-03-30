using System;
using System.Diagnostics;

namespace PPTBoardEditor {
    static class GameHelper {
        static ProcessMemory Game = new ProcessMemory("puyopuyotetris");

        public static bool CheckProcess() => Game.CheckProcess();
        public static void SwitchTrust(bool state) => Game.TrustProcess = state;

        public static int DirectRead(int address) => Game.ReadInt32(new IntPtr(address));
        public static bool DirectWrite(int address, int value) => Game.WriteInt32(new IntPtr(address), value);

        public static int PlayerCount() =>
            Math.Max(0, Math.Min(4, Game.TraverseInt32(  // Limit this between 0 and 4.
                new IntPtr(0x140473760),
                new int[] { 0x20, 0xB4 }
            ) ?? 0)
        );
        

        public static int LocalSteam() => 
            Game.ReadInt32(new IntPtr(
                0x1405A2010
            ));

        public static int PlayerSteam(int index) => 
            Game.ReadInt32(new IntPtr(
                Game.TraverseInt32(
                    new IntPtr(0x140473760),
                    new int[] { 0x20, 0x118 + index * 0x50 }
                ) ?? 0
            )
        );

        public static int FindPlayer() {
            if (PlayerCount() < 2)
                return 0;

            int localSteam = LocalSteam();

            for (int i = 0; i < 2; i++)
                if (localSteam == PlayerSteam(i))
                    return i;

            return 0;
        }

        public static string PlayerName(int index) => 
            Game.ReadStringUnicode(new IntPtr(0x140598BD4 + index * 0x68), 0x20);

        public static bool InMatch() => 
            Game.ReadInt32(new IntPtr(0x140573A78)) == 0x0;

        public static bool InSwap() => 
            Game.ReadBoolean(new IntPtr(0x14059894C))
                ? Game.ReadBoolean(new IntPtr(0x1404385C4))
                    ? Game.ReadByte(new IntPtr(0x140438584)) == 3
                    : Game.ReadByte(new IntPtr(0x140573794)) == 2
                : (Game.ReadByte(new IntPtr(0x140451C50)) & 0b11101111) == 4;

        public static int BoardAddress(int index) =>
            Game.TraverseInt32(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 0x8, 0xA8, 0x300, 0x3C0, 0x18 }
                    : new int[] { 0x378 + index * 0x8, 0xC0, 0x10, 0x3C0, 0x18 }
                ) ?? 0;
        

        public static int QueueAddress(int index) =>
            (Game.TraverseInt32(
                new IntPtr(0x140461B20),
                InSwap()
                    ? index == 0
                        ? new int[] { 0x380, 0x18, 0xB8 }
                        : new int[] { 0x378 + index * 0x8, 0x1E0, 0xB8 }
                    : new int[] { 0x378 + index * 0x8, 0xB8 }
            ) ?? 0) + 0x15C;

        public static int CurrentPiece(int index) =>
            Game.TraverseByte(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 0x8, 0x1E0, 0x40, 0x140, 0x110 }
                    : new int[] { 0x378 + index * 0x8, 0xC0, 0x120, 0x110 }
            ) ?? 0;

        public static int RotationPointer(int index) =>
            Game.TraverseByte(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 0x8, 0xA8, 0x300, 0x3C8, 0x18 }
                    : new int[] { 0x378 + index * 0x8, 0xA8, 0x3C8, 0x18 }
            ) ?? 0;

        public static int HoldPointer(int index) =>
            (Game.TraverseInt32(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 0x8, 0x30, 0x300, 0x3D0 }
                    : new int[] { 0x378 + index * 0x8, 0xA8, 0x3D0 }
            ) ?? 0) + 0x8;

        public static bool PieceDropped(int index) =>
            Game.TraverseByte(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 0x8, 0xA8, 0x300, 0x3C8, 0x1C }
                    : new int[] { 0x378 + index * 0x8, 0xA8, 0x3C8, 0x1C }
            ) == 1;

        public static int FrameCount() =>
            Game.TraverseInt32(
                new IntPtr(0x140461B20),
                new int[] { 0x208 }
            ) ?? 0;
    }
}
