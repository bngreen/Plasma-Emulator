using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class MemoryData : IMemoryData
    {
        public uint Data { get; set; }
        public void Write(uint data)
        {
            Data = data;
        }

        public uint Read()
        {
            return Data;
        }
    }
}
