﻿using System.Runtime.CompilerServices;

namespace Aeon.Emulator.Instructions.BitwiseLogic
{
    internal static class Bsr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Opcode("0FBD/r rw,rmw", OperandSize = 16, AddressSize = 16 | 32)]
        public static void BitScanReverse16(Processor p, ref ushort index, ushort value)
        {
            for (int i = 15; i >= 0; i--)
            {
                if ((value & (1 << i)) != 0)
                {
                    index = (ushort)i;
                    p.Flags.Zero = false;
                    return;
                }
            }

            index = 0;
            p.Flags.Zero = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Alternate(nameof(BitScanReverse16), OperandSize = 32, AddressSize = 16 | 32)]
        public static void BitScanReverse32(Processor p, ref uint index, uint value)
        {
            for (int i = 31; i >= 0; i--)
            {
                if ((value & (1 << i)) != 0)
                {
                    index = (uint)i;
                    p.Flags.Zero = false;
                    return;
                }
            }

            index = 0;
            p.Flags.Zero = true;
       }
    }
}
