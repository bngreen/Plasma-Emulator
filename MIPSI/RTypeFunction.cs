using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public enum RTypeFunction
    {
        Add = 32,
        UnsignedAdd = 33,
        BitwiseAnd = 36,
        Break = 0xd,
        Divide = 26,
        UnsignedDivide = 27,
        JumpAndLinkRegister = 9,
        JumpRegister = 8,
        MoveFromHi = 16,
        MoveFromLo = 18,
        MoveToHi = 17,
        MoveToLo = 19,
        Multiply = 0x18,
        UnsignedMultiply = 25,
        BitwiseNor = 39,
        BitwiseOr = 37,
        ShiftLeftLogical = 0,
        ShiftLeftLogicalVariable = 4,
        SetOnLessThan = 0x2a,
        UnsignedSetOnLessThan = 0x2b,
        ShiftRightArithmetic = 3,
        ShiftRightArithmeticVariable = 7,
        ShiftRightLogical = 2,
        ShiftRightLogicalVariable = 6,
        Subtract = 0x22,
        UnsignedSubtract = 0x23,
        Syscall = 0x0c,
        BitwiseExclusiveOr = 0x26,

    }
}
