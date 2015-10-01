using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class UndefinedInstruction : IInstruction
    {
        public uint Data { get; set; }

        public static UndefinedInstruction FromInteger(uint data)
        {
            return new UndefinedInstruction() { Data = data };
        }
        public uint ToInteger()
        {
            return Data;
        }


        public void Execute(IStateAccessor state)
        {
            
        }


        public uint Address { get; set; }
    }
}
