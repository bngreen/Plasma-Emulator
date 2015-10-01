using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class ITypeInstruction : IInstruction
    {
        public uint Address { get; set; }
        public Opcode Opcode { get; set; }
        public uint Rs { get; set; }
        public uint Rt { get; set; }
        public uint Immediate { get; set; }
        public static ITypeInstruction FromInteger(uint v)
        {
            var it = new ITypeInstruction()
            {
                Opcode = (MIPSI.Opcode)(v >> 26),
                Rs = (v >> 21) & 0x1f,
                Rt = (v >> 16) & 0x1f,
                Immediate = ((ushort)((v) & 0xFFFF))
            };
            return it;
        }
        public uint ToInteger()
        {
            var v = 0u;
            v |= ((uint)Opcode) << 26;
            v |= (Rs & 0x1f) << 21;
            v |= (Rt & 0x1f) << 16;
            v |= (Immediate & 0xFFFF);
            return v;
        }

        public Action<ITypeInstruction, IStateAccessor> Executor { get; set; }

        public void Execute(IStateAccessor state)
        {
            Executor(this, state);
        }
    }
}
