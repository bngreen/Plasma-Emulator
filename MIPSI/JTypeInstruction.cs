using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class JTypeInstruction : IInstruction
    {
        public uint Address { get; set; }
        public JumpType JumpType { get; set; }
        public uint Target { get; set; }
        public static JTypeInstruction FromInteger(uint b)
        {
            var jt = new JTypeInstruction()
            {
                JumpType = (JumpType)(b >> 26),
                Target = b & 0x3FFFFFF
            };
            return jt;
        }
        public uint ToInteger()
        {
            uint v = 0;
            v |= ((uint)JumpType) << 26;
            v |= Target & 0x3FFFFFF;
            return v;
        }

        public Action<JTypeInstruction, IStateAccessor> Executor { get; set; }

        public void Execute(IStateAccessor state)
        {
            Executor(this, state);
        }
    }
}
