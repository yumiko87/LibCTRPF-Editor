using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libEditor
{
    public static class Lib
    {
        public static int GetSize(string Version)
        {
            int LibSize = 0;
            
            switch (Version)
            {
                case "v0.7.0":
                    LibSize = 0x1A60FC;
                    break;
            }
            
            return LibSize;
        }
    }
}