using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MIPSI
{
    public class ProgramLoader
    {
        public static Program ReadProgram(ELFSharp.ELF<uint> elf, bool generateMemory=true)
        {
            var state = new State();
            if(generateMemory)
                state.Memory = new byte[1000000];
            var littleEndian = elf.Endianess == ELFSharp.Endianess.LittleEndian;
            var sections = new Dictionary<string, ELFSharp.Sections.ISection>();
            foreach (var x in elf.Sections)
                sections.Add(x.Name, x);
            var text = sections[".text"] as ELFSharp.Sections.ProgBitsSection<uint>;

            var textReader = new BinaryReader(new MemoryStream(text.GetContents()));
            var reader = new InstructionsReader(littleEndian);
            var instructions = reader.ReadInstructions(textReader, littleEndian, text.LoadAddress);
            if (generateMemory)
                Array.Copy(text.GetContents(), 0, state.Memory, text.LoadAddress, text.Size);
            
            var names = new string[]{ ".rodata", ".data", ".sdata" };
            if (generateMemory)
            {
                foreach (var n in names)
                {
                    ELFSharp.Sections.ISection sect;
                    if (sections.TryGetValue(n, out sect))
                    {
                        var section = sect as ELFSharp.Sections.ProgBitsSection<uint>;
                        Array.Copy(section.GetContents(), 0, state.Memory, section.LoadAddress, section.Size);
                    }
                }
            }
            return new Program() { EntryPoint = elf.EntryPoint, Instructions = instructions, State = state, LittleEndian = littleEndian, TextSectionAddress = text.LoadAddress };
        }
    }
}
