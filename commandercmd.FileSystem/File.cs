using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.FileSystem
{
    public class File : FileSystemItem
    {
        public String Content { get; set; }
        public File(String name) { 
            Name = name.Trim();
        }
    }
}