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

        public Directory(String name)
        {
            Name = name;
            Content = new List<FileSystemItem>();
        }
        public Directory(String name, List<FileSystemItem> content)
        {
            Name = name;
            Content = content;
        }

        public File GetFile(String path)
        {
            if (path != null && path.Length > 0)
            {
                String[] spliitedArray = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);
                if (spliitedArray.Length > 0)
                {
                    String firstLevel = spliitedArray[0];
                    FileSystemItem fileSystemItem = Content.Where(x => x.Name == firstLevel).FirstOrDefault();
                    if (fileSystemItem.GetType() == typeof(Directory))
                    {
                        if (spliitedArray.Length > 1)
                        {
                            String nextPath = "";
                            for (int i = 1; i < spliitedArray.Length; i++)
                            {
                                nextPath += $"\\{spliitedArray[i]}";
                            }
                            ((Directory)fileSystemItem).GetFile(nextPath);
                        }
                    }
                    else if (fileSystemItem.GetType() == typeof(File))
                    {
                        return (File)fileSystemItem;
                    }
                }
            }

            throw new FileNotFoundException(path);
        }

        public Directory GetDirectory(String path)
        {
            if (path != null && path.Length > 3)
            {

                String[] spliitedArray = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);
                if (spliitedArray.Length > 0) { }
                String firstLevel = spliitedArray[0];
                FileSystemItem fileSystemItem = Content.Where(x => x.Name == firstLevel).FirstOrDefault();
                if (fileSystemItem.GetType() == typeof(Directory))
                {
                    if (spliitedArray.Length == 1)
                    {
                        return (Directory)fileSystemItem;
                    }
                    else
                    {
                        String nextPath = "";
                        for (int i = 2; i < spliitedArray.Length; i++)
                        {
                            nextPath += $"\\{spliitedArray[i]}";
                        }
                        ((Directory)fileSystemItem).GetDirectory(nextPath);
                    }
                }
            }
            throw new DirectoryNotFoundException();
        }

    }
}
