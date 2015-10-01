using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class PrintMemoryData : IMemoryData
    {
        public void Write(uint data)
        {
            Console.Write((char)(data));
        }

        public uint Read()
        {
            return ((uint)Console.ReadKey().KeyChar);
        }
    }
}
