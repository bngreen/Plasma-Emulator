using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public enum JumpType : uint
    {
        Jump = Opcode.Jump,
        JumpAndLink = Opcode.JumpAndLink
    }
}
