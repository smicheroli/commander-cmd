using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace commandercmd.FileSystem
{
    public class PersistenceService
    {
        public String FilePath { get; set; }
        private JsonSerializerSettings jsonSerializerSettings;

        public PersistenceService(String filePath) {
            this.FilePath = filePath;
            jsonSerializerSettings = new();
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
        }

        public void Save(IList<Drive> files)
        {
            System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(files,jsonSerializerSettings));
        }

        public IList<Drive> Load() {
            IList<Drive> files = new List<Drive>();
            if (System.IO.File.Exists(FilePath))
            {
                files = JsonConvert.DeserializeObject<List<Drive>>(System.IO.File.ReadAllText(FilePath),jsonSerializerSettings);
            } else
            {
                files= new List<Drive>();
                Drive cDrive = new Drive('C');
                Directory directory1 = new Directory("Verzeichnis1");
                directory1.Content.Add(new File("Text.txt", "Das ist ein Test. Note 6 reicht :)"));
                directory1.Content.Add(new Directory("Verzeichnis1Verzeichnis"));

                cDrive.Content.Add(directory1);


                Directory directory2 = new Directory("Verzeichnis2");
                cDrive.Content.Add(directory2);
                Directory directory3 = new Directory("Verzeichnis3");
                cDrive.Content.Add(directory3);
                files.Add(cDrive);
            }
            return files;
        }
    }
}
