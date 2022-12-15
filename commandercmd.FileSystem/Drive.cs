using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.FileSystem
{
    public class Drive
    {
        public char DriveLetter { get; set; }
        public List<FileSystemItem> Content { get; set; }

        public Drive(char driveLetter) {
            DriveLetter = driveLetter;
            Content = new List<FileSystemItem>();
        }
        public Drive(char driveLetter, List<FileSystemItem> content) {
            DriveLetter = driveLetter;
            Content = content;
        }


        public File GetFile(String path)
        {
            if(path != null && path.Length > 3)
            {
                if (path.StartsWith(DriveLetter) && path[1] == ':' && path[2] == '\\')
                {
                    String[] spliitedArray = path.Split('\\');
                    String firstLevel = spliitedArray[1];
                    FileSystemItem fileSystemItem = Content.Where(x => x.Name== firstLevel).FirstOrDefault();
                    if(fileSystemItem.GetType() == typeof(Directory))
                    {
                        if (spliitedArray.Length > 2)
                        {
                            String nextPath = "";
                            for (int i = 2; i < spliitedArray.Length; i++)
                            {
                                nextPath+= $"\\{spliitedArray[i]}";
                            }
                            ((Directory)fileSystemItem).GetFile(nextPath);
                        }
                    } else if(fileSystemItem.GetType() == typeof(File))
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
                if (path.StartsWith(DriveLetter) && path[1] == ':' && path[2] == '\\')
                {
                    String[] spliitedArray = path.Split('\\');
                    String firstLevel = spliitedArray[1];
                    FileSystemItem fileSystemItem = Content.Where(x => x.Name == firstLevel).FirstOrDefault();
                    if (fileSystemItem.GetType() == typeof(Directory))
                    {
                        if(spliitedArray.Length < 2)
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
            }

            throw new DirectoryNotFoundException();
        }

        public void MoveItem(String oldPath, String newPath)
        {

        }
        public void CopyItem(String oldPath, String newPath)
        {

        }
        public void DeleteItem(String path)
        {
            if (ExistsDirectory(path) || ExistsFile(path))
            {
                String[] spliitedArray = path.Split('\\');
                String existingPath = "";
                for (int i = 0; i < spliitedArray.Length - 1; i++)
                {
                    existingPath += $"{spliitedArray[i]}\\";
                }

                if (ExistsDirectory(existingPath))
                {
                    Directory directory = GetDirectory(existingPath);

                    directory.Content.Remove(directory.Content.Where(x => x.Name == spliitedArray[spliitedArray.Length - 1]).First());
                }


            }
        }

        public void CreateFile(String path, String content = "")
        {
            if(!ExistsDirectory(path) && !ExistsFile(path))
            {
                String[] spliitedArray = path.Split('\\');
                String existingPath = ""; 
                for (int i = 0; i < spliitedArray.Length - 1; i++)
                {
                    existingPath += $"{spliitedArray[i]}\\";
                }

                if (ExistsDirectory(existingPath))
                {
                    Directory directory = GetDirectory(existingPath);
                    directory.Content.Add(new File(spliitedArray[spliitedArray.Length - 1], content));
                }

                
            }
        }

        public void Createirectory(String path)
        {
            if (!ExistsDirectory(path) && !ExistsFile(path))
            {
                String[] spliitedArray = path.Split('\\');
                String existingPath = "";
                for (int i = 0; i < spliitedArray.Length - 1; i++)
                {
                    existingPath += $"{spliitedArray[i]}\\";
                }

                if (ExistsDirectory(existingPath))
                {
                    Directory directory = GetDirectory(existingPath);
                    directory.Content.Add(new Directory(spliitedArray[spliitedArray.Length - 1]);
                }


            }
        }

        public bool ExistsFile(String path)
        {
            try
            {
                GetFile(path);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool ExistsDirectory(String path)
        {
            try
            {
                GetDirectory(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}