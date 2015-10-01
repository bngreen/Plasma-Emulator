using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public enum Opcode : uint
    {
        RType = 0,
        AddImmediate = 0x8,
        UnsignedAddImmediate = 9,
        BitwiseAndImmediate = 0xc,
        BranchOnEqual = 4,
        Branch = 1,
        BranchOnGreaterThanZero = 7,
        BranchOnLessThanOrEqualToZero = 6,
        BranchOnNotEqual = 5,
        LoadByte = 0x20,
        UnsignedLoadByte = 0x24,
        LoadHalfword = 0x21,
        UnsignedLoadHalfword = 0x25,
        LoadUpperImmediate = 0xf,
        LoadWord = 0x23,
        BitwiseOrImmediate = 0xd,
        StoreByte = 0x28,
        SetOnLessThanImmediate = 0xa,
        UnsignedSetOnLessThanImmediate = 0xb,
        StoreHalfword = 0x29,
        StoreWord = 0x2b,
        BitwiseExclusiveOrImmediate = 0xe,
        Jump = 2,
        JumpAndLink = 3,
        CoProcessor = 0x10,
    }
}
