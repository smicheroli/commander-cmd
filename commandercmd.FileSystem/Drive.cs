using System;
using System.Collections.Generic;
using System.IO;
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
        public Drive()
        {

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
                        if (spliitedArray.Length > 3)
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
                    String[] splittedArray = path.Split('\\');
                    String firstLevel = splittedArray[1];
                    FileSystemItem fileSystemItem = Content.Where(x => x.Name == firstLevel).FirstOrDefault();
                    if (fileSystemItem.GetType() == typeof(Directory))
                    {
                        if (splittedArray.Length < 3)
                        {
                            return (Directory)fileSystemItem;
                        }
                        else
                        {
                            String nextPath = "";
                            for (int i = 2; i < splittedArray.Length; i++)
                            {
                                if (i == 2)
                                {
                                    nextPath += splittedArray[i];
                                }
                                else
                                {
                                    nextPath += "\\" + splittedArray[i];
                                }

                                ((Directory)fileSystemItem).GetDirectory(nextPath);
                            }
                        } 
                    }
                    
                }
            }
            throw new DirectoryNotFoundException();
        }

        public void MoveItem(String oldPath, String newPath)
        {
            if (ExistsFile(oldPath) || ExistsDirectory(oldPath))
            {

                String[] spliitedArrayOld = oldPath.Split('\\');
                String existingOldPath = "";
                for (int i = 0; i < spliitedArrayOld.Length - 1; i++)
                {
                    existingOldPath += $"{spliitedArrayOld[i]}\\";
                }


                String[] spliitedArrayNew = newPath.Split('\\');
                String existingNewPath = "";
                for (int i = 0; i < spliitedArrayNew.Length - 1; i++)
                {
                    existingNewPath += $"{spliitedArrayNew[i]}\\";
                }

                FileSystemItem item;
                if (ExistsFile(oldPath)) {
                    item = GetFile(oldPath);
                } else
                {
                    item = GetDirectory(oldPath);
                }

                Directory oldDirectory = GetDirectory(existingOldPath);
                Directory newDirectory = GetDirectory(existingNewPath);

                oldDirectory.Content.Remove(item);
                newDirectory.Content.Add(item);

            }
            else
            {
                throw new Exception();
            }
        }
        public void CopyItem(String oldPath, String newPath)
        {
            if (ExistsFile(oldPath) || ExistsDirectory(oldPath))
            {

                String[] spliitedArrayOld = oldPath.Split('\\');
                String existingOldPath = "";
                for (int i = 0; i < spliitedArrayOld.Length - 1; i++)
                {
                    existingOldPath += $"{spliitedArrayOld[i]}\\";
                }


                String[] spliitedArrayNew = newPath.Split('\\');
                String existingNewPath = "";
                for (int i = 0; i < spliitedArrayNew.Length - 1; i++)
                {
                    existingNewPath += $"{spliitedArrayNew[i]}\\";
                }

                FileSystemItem item;
                if (ExistsFile(oldPath))
                {
                    item = GetFile(oldPath);
                }
                else
                {
                    item = GetDirectory(oldPath);
                }

                Directory newDirectory = GetDirectory(existingNewPath);

                newDirectory.Content.Add(item);

            }
            else
            {
                throw new Exception();
            }
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

        public void CreateDirectory(String path)
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
                    directory.Content.Add(new Directory(spliitedArray[spliitedArray.Length - 1]));
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