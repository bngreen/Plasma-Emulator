using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIPSI
{
    public class Utils
    {
        public static uint ReverseUInt32(uint v)
        {
            return ((v & 0xff) << 24) | (((v >> 8) & 0xff) << 16) | (((v >> 16) & 0xff) << 8) | (v >> 24);
        }

        public static UInt16 ReverseUInt16(UInt16 v)
        {
            return (UInt16)(((v << 8) & 0xff00) | ((v >> 8) & 0xff));
        }

    }
}
