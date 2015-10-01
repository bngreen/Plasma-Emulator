using MIPSI;
using MIPSI.UnPipelined;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pemu
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Usage: pemu binaryFile");
                return;
            }
            var elf = ELFSharp.ELFReader.Load<uint>(args[0]);
            var program = ProgramLoader.ReadProgram(elf);
            var cpu = new Cpu() { Program = program };
            cpu.Run();
        }
    }
}
