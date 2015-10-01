using System;
namespace MIPSI
{
    public interface IState
    {
        byte[] Memory { get; set; }
        uint Epc { get; set; }
        void GetMemoryData(uint address, out byte data);
        void GetMemoryData(uint address, out ushort data);
        void GetMemoryData(uint address, out uint data);
        uint Hi { get; set; }
        uint Lo { get; set; }
        uint Pc { get; set; }
        System.Collections.Generic.IList<uint> Registers { get; set; }
        void SetMemoryData(uint address, byte data);
        void SetMemoryData(uint address, ushort data);
        void SetMemoryData(uint address, uint data);
    }
}
