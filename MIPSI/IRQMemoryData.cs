using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    class IRQMemoryData : IMemoryData
    {
        public void Write(uint data)
        {
            throw new NotImplementedException();
        }

        public uint Read()
        {
            return 2u | (Console.KeyAvailable ? 1u : 0u);
        }
    }
}
