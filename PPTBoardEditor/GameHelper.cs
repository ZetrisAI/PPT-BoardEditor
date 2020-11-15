using System;
using System.Diagnostics;

namespace PPTBoardEditor {
    static class GameHelper {
        static ProcessMemory Game = new ProcessMemory("puyopuyotetris");

        public static bool CheckProcess() => Game.CheckProcess();
        public static void SwitchTrust(bool state) => Game.TrustProcess = state;

        public static long DirectRead(long address) => Game.ReadInt64(new IntPtr(address));
        public static bool DirectWrite(long address, int value) => Game.WriteInt32(new IntPtr(address), value);

        public static string PlayerName(int index) =>
            Game.ReadStringUnicode(new IntPtr(0x140598BD4 + index * 0x68), 0x20);

        public static bool InSwap() =>
            Game.ReadByte(new IntPtr(0x140598BB8)) == 5;

        static long PlayerAddress(int index) =>
            Game.TraverseInt64(
                new IntPtr(0x140461B20),
                InSwap()
                    ? new int[] { 0x378 + index * 8, 0x1E0 }
                    : new int[] { 0x378 + index * 8 }
                ) ?? 0;
        static long TetrisAddress(int index) =>
            Game.ReadInt64(new IntPtr(PlayerAddress(index)) + 0xA8);

        public static long BoardAddress(int index) =>
            Game.TraverseInt64(
                new IntPtr(TetrisAddress(index)) + 0x3C0,
                new int[] { 0x18 }
                ) ?? 0;
        

        public static long QueueAddress(int index) =>
            Game.ReadInt64(new IntPtr(PlayerAddress(index)) + 0xB8) + 0x15C;

        public static int CurrentPiece(int index) =>
            Game.TraverseInt32(
                new IntPtr(TetrisAddress(index)),
                new int[] { 0x3C8, 8 }
            ) ?? 0;

        public static long HeldPiecePointer(int index) =>
            Game.ReadInt64(new IntPtr(TetrisAddress(index)) + 0x3D0) + 0x8;

        public static int GameState(int index) =>
            Game.ReadInt32(new IntPtr(TetrisAddress(index)) + 0x80);

        public static bool PieceDropped(int index) =>
            Game.TraverseByte(
                new IntPtr(TetrisAddress(index)),
                new int[] { 0x3C8, 0x1C }
            ) == 1;

        public static int FrameCount() =>
            Game.TraverseInt32(
                new IntPtr(0x140461B20),
                new int[] { 0x208 }
            ) ?? 0;
    }
}
