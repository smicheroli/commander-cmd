using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.FileSystem
{
    public class Drive
    {
        public String DriveLetter { get; set; }
        public List<FileSystemItem> Content { get; set; }

        public Drive() { 
            
        }

    }
}
