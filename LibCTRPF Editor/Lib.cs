using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibEditor {
    public static class Lib {
        public static int GetSize(string version) {
            int libSize = 0;
            
            switch (version) {
                case "v0.7.0":
                    libSize = 0x1A60FC;
                    break;
            }
            return libSize;
        }
    }
}