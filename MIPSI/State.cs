using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class State : MIPSI.IState
    {
        public uint Pc { get; set; }
        public uint Hi { get; set; }
        public uint Lo { get; set; }
        public uint Epc { get; set; }
        public IList<uint> Registers { get; set; }
        private IDictionary<uint, IMemoryData> SpecialMemory { get; set; }
        public byte[] Memory { get; set; }
        public byte[] ExternalRam { get; set; }
        public void GetMemoryData(uint address, out byte data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                data = (byte)md.Read();
                return;
            }
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            data = mem[(int)address];
        }
        public void GetMemoryData(uint address, out UInt16 data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                data = (UInt16)(md.Read() << 8);
                return;
            }
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            data = BitConverter.ToUInt16(mem, (int)address);
        }
        public void GetMemoryData(uint address, out UInt32 data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                data = (UInt32)(md.Read() << 24);
                return;
            }
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            data = BitConverter.ToUInt32(mem, (int)address);
        }
        public void SetMemoryData(uint address, byte data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                md.Write(((uint)data));
                return;
            }
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            mem[(int)address] = data;
        }
        public void SetMemoryData(uint address, UInt16 data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                md.Write(((uint)(data)) >> 8 );
                return;
            }
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            var dt = BitConverter.GetBytes(data);
            Array.Copy(dt, 0, mem, (int)address, 2);
        }
        public void SetMemoryData(uint address, UInt32 data)
        {
            IMemoryData md;
            if (SpecialMemory.TryGetValue(address, out md))
            {
                md.Write(((uint)data) >> 24);
                return;
            }
            var addr = address;
            var mem = Memory;
            if (address >= 0x10000000)
            {
                address -= 0x10000000;
                mem = ExternalRam;
            }
            var dt = BitConverter.GetBytes(data);
            Array.Copy(dt, 0, mem, (int)address, 4);
        }/*
        public uint GetMemoryData(uint address)
        {
            var addr1 = address & 0xfffffffc;
            var addr2 = addr1 + 4;
            var val1 = 0u;
            var val2 = 0u;
            IMemoryData val;
            if (SpecialMemory.TryGetValue(addr1, out val))
                val1 = val.Read();
            if (SpecialMemory.TryGetValue(addr2, out val))
                val2 = val.Read();
            var x = (int)(address & 3) * 8;
            var value = (val1 << x) | (val2 >> (32 - x));
            return value;
        }
        public void SetMemoryData(uint address, uint value)
        {
            var addr1 = address & 0xfffffffc;
            var addr2 = addr1 + 4;
            var val1 = 0u;
            var val2 = 0u;
            IMemoryData val;
            if (SpecialMemory.TryGetValue(addr1, out val))
                val1 = val.Read();
            if (SpecialMemory.TryGetValue(addr2, out val))
                val2 = val.Read();
            var x = (int)(address & 3) * 8;

            val1 = (val1 & (0xffffffffu << (32 - x))) | (value >> x);
            val2 = (val2 & (0xffffffffu << x)) | (value >> (32 - x));

            if (!SpecialMemory.TryGetValue(addr1, out val))
            {
                val = new MemoryData();
                SpecialMemory.Add(addr1, val);
            }
            val.Write(val1);
            if (!SpecialMemory.TryGetValue(addr2, out val))
            {
                val = new MemoryData();
                SpecialMemory.Add(addr2, val);
            }
            val.Write(val2);
        }*/
        public State()
        {
            Registers = new uint[32];
            ExternalRam = new byte[64000000];
            SpecialMemory = new Dictionary<uint, IMemoryData>();
            SpecialMemory.Add(0x20000000, new PrintMemoryData());
            SpecialMemory.Add(0x20000010, new MemoryData());
            SpecialMemory.Add(0x20000014, new IRQMaskP4MemoryData());
            SpecialMemory.Add(0x20000020, new IRQMemoryData());
            SpecialMemory.Add(0x20000070, new MemoryData());
            SpecialMemory.Add(0x20000080, new MemoryData());
            SpecialMemory.Add(0x20000090, new MemoryData());
            SpecialMemory.Add(0x200000a0, new MemoryData());
        }
    }
}
