using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class IRQMaskP4MemoryData : IMemoryData
    {
        public uint Data { get; set; }

        public void Write(uint data)
        {
            throw new NotImplementedException();
        }

        public uint Read()
        {
            System.Threading.Thread.Sleep(20);
            return 0;
        }
    }
}
