using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public interface IStateAccessor
    {
        void WriteRegister(uint address, uint value);
        uint ReadRegister(uint address);
        void SetPc(uint value);
        void SetHi(uint value);
        void SetLo(uint value);
        void SetEpc(uint value);
        uint GetPc();
        uint GetHi();
        uint GetLo();
        uint GetEpc();
        void GetMemoryData(uint address, out byte data);
        void GetMemoryData(uint address, out ushort data);
        void GetMemoryData(uint address, out uint data);
        void SetMemoryData(uint address, byte data);
        void SetMemoryData(uint address, ushort data);
        void SetMemoryData(uint address, uint data);
        void Skip();
        void SetCoprocessorRegister(uint register, uint value);
        uint GetCoprocessorRegister(uint register);
    }
}
