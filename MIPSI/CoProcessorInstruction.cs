using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class CoProcessorInstruction : IInstruction
    {
        public uint Address { get; set; }
        public Opcode Opcode { get; set; }
        public CoProcessorFormat Format { get; set; }
        public uint Rt { get; set; }
        public uint Rd { get; set; }
        public static CoProcessorInstruction FromInteger(uint v)
        {
            var cp = new CoProcessorInstruction()
            {
                Opcode = (MIPSI.Opcode)(v >> 26),
                Format = (CoProcessorFormat)((v >> 21) & 0x1f),
                Rt = (v >> 16) & 0x1f,
                Rd = (v >> 11) & 0x1f
            };
            return cp;

        }
        public uint ToInteger()
        {
            throw new NotImplementedException();
        }

        public Action<CoProcessorInstruction, IStateAccessor> Executor { get; set; }

        public void Execute(IStateAccessor state)
        {
            Executor(this, state);
        }
    }
}
