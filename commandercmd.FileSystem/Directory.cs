using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.FileSystem
{
    public class Directory : FileSystemItem
    {
        public List<FileSystemItem> Content { get; set; }

        public Directory(String name) { 
            Name = name;
        }
    }
}
