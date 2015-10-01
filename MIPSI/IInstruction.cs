using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public interface IInstruction
    {
        uint ToInteger();
        void Execute(IStateAccessor state);
        uint Address { get; set; }
    }
}
