using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class Program
    {
        public IState State { get; set; }
        public IList<IInstruction> Instructions { get; set; }
        public uint EntryPoint { get; set; }
        public bool LittleEndian { get; set; }
        public uint TextSectionAddress { get; set; }
    }
}
